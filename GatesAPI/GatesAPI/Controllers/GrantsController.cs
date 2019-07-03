using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GatesAPI.Models;
using PagedList;

namespace GatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrantsController : ControllerBase
    {
        private readonly GatesGrantsContext _context;

        public GrantsController(GatesGrantsContext context)
        {
            _context = context;
        }

        // GET: api/Grants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grant>>> GetGrant()
        {
            return await _context.Grant.OrderByDescending(q => q.StartDate).Include(g => g.Organization).ToListAsync();
        }

        // GET: api/Grants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrantDTO>> GetGrant(int id)
        {
            var RegionList = (from grants in _context.Grant
                             join gregions in _context.GrantRegion on grants.Id equals gregions.GrantId
                             join regions in _context.Region on gregions.RegionId equals regions.Id
                             where grants.Id == id
                             select new Region { Id = regions.Id, Name = regions.Name }).ToList();
            var TopicList = (from grants in _context.Grant
                             join gtopic in _context.GrantTopic on grants.Id equals gtopic.GrantId
                             join topic in _context.Topic on gtopic.TopicId equals topic.Id
                             join topicgroup in _context.TopicGroup on topic.TopicGroupId equals topicgroup.Id
                             where grants.Id == id
                             select new TopicGroup { Id = topicgroup.Id, Name = topicgroup.Name }).ToList();

            var grant = await _context.Grant.Include(g => g.Organization).Select(g =>
                new GrantDTO()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Amount = g.Amount,
                    StartDate = g.StartDate,
                    Organization = g.Organization,
                    Region = RegionList,
                    TopicGroup = TopicList
                }).Where(g => g.Id == id).FirstAsync();

            if (grant == null)
            {
                return NotFound();
            }

            return grant;
        }

        // Get: api/Grants/Counts
        [HttpGet("TotalCount")]
        public async Task<ActionResult<GrantListDTO>> GetCountedGrants()
        {
            var grantList = await _context.Grant.ToListAsync();

            var result = new GrantListDTO()
            {
                TotalAmount = (from grant in grantList
                               select grant.Amount).Sum(),
                TotalGrants = grantList.Count(),
            };

            return result;
        }

        // Post: api/Grants/Filter
        [HttpPost("Filter")]
        public async Task<ActionResult<GrantListDTO>> FilterGrant([FromBody]FilterCriteria fc)
        {
            var grantList = await _context.Grant.OrderByDescending(q => q.StartDate).Include(g => g.Organization).ToListAsync();

            if (!string.IsNullOrEmpty(fc.Year))
            {
                if(fc.Year == "<- 1999")
                {
                    int year = 1999;
                    grantList = grantList.Where(grant => grant.StartDate.Year <= year).ToList();
                }
                else
                {
                    int year = Int32.Parse(fc.Year);
                    grantList = grantList.Where(grant => grant.StartDate.Year == year).ToList();
                }
            }

            if (fc.RegionId > 0)
            {
                grantList = (from grant in grantList
                            join grantregion in _context.GrantRegion
                                on grant.Id equals grantregion.GrantId
                             where grantregion.RegionId == fc.RegionId
                             select grant).ToList();
            }
            if(fc.TopicId > 0)
            {
                grantList = (from grant in grantList
                             join granttopic in _context.GrantTopic
                                 on grant.Id equals granttopic.GrantId
                             join topic in _context.Topic
                                on granttopic.TopicId equals topic.Id
                             where topic.TopicGroupId == fc.TopicId
                             select grant).ToList();
            }

            var result = new GrantListDTO()
                        {
                            TotalAmount = (from grant in grantList
                                           select grant.Amount).Sum(),
                            TotalGrants = grantList.Count(),
                            Grants = grantList
                        };
            return result;
        }

        // Post: api/Grants/Search
        [HttpPost("Search")]
        public async Task<ActionResult<GrantListDTO>> GetSearchedGrants([FromBody]SearchCriteria sc)
        {
            var grantList = await _context.Grant.OrderByDescending(q => q.StartDate).Include(g => g.Organization).Where(grant => grant.Organization.Name.Contains(sc.Keyword)).ToListAsync();

            var result = new GrantListDTO()
            {
                TotalAmount = (from grant in grantList
                               select grant.Amount).Sum(),
                TotalGrants = grantList.Count(),
                Grants = grantList
            };

            return result;
        }

        // PUT: api/Grants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrant(int id, Grant grant)
        {
            if (id != grant.Id)
            {
                return BadRequest();
            }

            _context.Entry(grant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrantExists(id))
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

        // POST: api/Grants
        [HttpPost]
        public async Task<ActionResult<Grant>> PostGrant(Grant grant)
        {
            _context.Grant.Add(grant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrant", new { id = grant.Id }, grant);
        }

        // DELETE: api/Grants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grant>> DeleteGrant(int id)
        {
            var grant = await _context.Grant.FindAsync(id);
            if (grant == null)
            {
                return NotFound();
            }

            _context.Grant.Remove(grant);
            await _context.SaveChangesAsync();

            return grant;
        }

        private bool GrantExists(int id)
        {
            return _context.Grant.Any(e => e.Id == id);
        }
    }
}
