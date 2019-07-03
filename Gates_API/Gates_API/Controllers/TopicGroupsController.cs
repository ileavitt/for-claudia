using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gates_API.Models;

namespace Gates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicGroupsController : ControllerBase
    {
        private readonly GatesGrantsContext _context;

        public TopicGroupsController(GatesGrantsContext context)
        {
            _context = context;
        }

        // GET: api/TopicGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicGroupDTO>>> GetTopicGroup()
        {
            var topics = await _context.TopicGroup.Select(r =>
                new TopicGroupDTO()
                {
                    Id = r.Id,
                    Name = r.Name,
                    TotalGrants = (from topic in r.Topic
                                   join GrantTopic in _context.GrantTopic on topic.Id equals GrantTopic.TopicId
                                   select new { grantId = GrantTopic.GrantId, topicId = topic.Id, grantTopicId = GrantTopic.Id }).Count(),
                    TotalAmount = (from topic in r.Topic
                                   join granttopic in _context.GrantTopic on topic.Id equals granttopic.TopicId
                                   join grant in _context.Grant on granttopic.GrantId equals grant.Id
                                   select new { grantId = granttopic.GrantId, topicId = topic.Id, grantTopicId = granttopic.Id, amount = grant.Amount })
                                   .Sum(x => x.amount)
                }).ToListAsync();
            return topics;
        }

        // GET: api/TopicGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicGroup>> GetTopicGroup(int id)
        {
            var topicGroup = await _context.TopicGroup.Include(tg => tg.Topic).ThenInclude(t => t.GrantTopic).ThenInclude(gt => gt.Grant).Where(tg => tg.Id == id).FirstAsync();

            if (topicGroup == null)
            {
                return NotFound();
            }

            return topicGroup;
        }

        // PUT: api/TopicGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopicGroup(int id, TopicGroup topicGroup)
        {
            if (id != topicGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(topicGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TopicGroups
        [HttpPost]
        public async Task<ActionResult<TopicGroup>> PostTopicGroup(TopicGroup topicGroup)
        {
            _context.TopicGroup.Add(topicGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopicGroup", new { id = topicGroup.Id }, topicGroup);
        }

        // DELETE: api/TopicGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TopicGroup>> DeleteTopicGroup(int id)
        {
            var topicGroup = await _context.TopicGroup.FindAsync(id);
            if (topicGroup == null)
            {
                return NotFound();
            }

            _context.TopicGroup.Remove(topicGroup);
            await _context.SaveChangesAsync();

            return topicGroup;
        }

        private bool TopicGroupExists(int id)
        {
            return _context.TopicGroup.Any(e => e.Id == id);
        }
    }
}
