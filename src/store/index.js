import Vue from 'vue'
import Vuex from 'vuex'
import data from '../db.json'
import GrantService from '@/services/GrantService'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
      grantTotal: 1000,
      grantCount: 800,
      grants: [],
      regions: [],
      topics: [],
      years: [],
      region: '',
      year: '',
      topic: '',
      search: ''
  },
    mutations: {
        SET_GRANTS(state, payload) {
            state.region = payload.filters.region || '';
            state.years = payload.filters.years || '';
            state.topic - payload.filters.topic || '';
            state.search = ''
            state.grantCount = payload.grants.totalGrants;
            state.grantTotal = payload.grants.totalAmount
            state.grants = payload.grants.grants;
        },
      RESET_GRANTS(state) {
          state.year = '';
          state.region = '';
          state.topic = '';
          state.grants = [];
          state.grantTotal = 10000;
          state.grantCount = 10000;
          state.search = '';
        },
        SET_YEARS(state) {
            state.years = [2010, 2011, 2012, 2013]
        },
        SET_REGIONS(state) {
            state.regions = data.regions;
        },
        SET_TOPICS(state) {
            state.topics = data.topicGroups
        },
        FILTER_TOPIC(state, topic) {
            state.topic = topic
        },
        FILTER_REGION(state, region) {
            state.region = region
        },
        FILTER_YEAR(state, year) {
            state.year = year
        },
        SEARCH(state, val) {
            state.year = '';
            state.region = '';
            state.topic = '';
            state.search = val
        }
    },
    actions: {
        loadFiltered({ commit }, filters) {
            let grants = data.grants[0]
            commit('SET_GRANTS', { grants, filters })
        },
        resetState({ commit }) {
            commit('RESET_GRANTS')
        },

        searchGrants({ commit }, keyword) {
            commit('SEARCH', keyword)
        }
  }
})
