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
      region: '',
      year: '',
      topic: '',
      search: ''
  },
    mutations: {
        SET_GRANTS(state, payload) {
            console.log(payload)
            state.region = payload.filters.region || '';
            state.years = payload.filters.years || '';
            state.topic - payload.filters.topic || '';
            state.search = ''
            state.grantCount = payload.grants.totalGrants;
            state.grantTotal = payload.grants.totalAmount
            state.grants = payload.grants.grants;
        },
      RESET_GRANTS() {
          state.year = '';
          state.region = '';
          state.topic = '';
          state.grants = [];
          state.grantTotal = 10000;
          state.grantCount = 10000;
          state.search = '';
      }
    },
    actions: {
        loadFiltered({ commit }, filters) {
            let grants = data.grants[0]
            commit('SET_GRANTS', { grants, filters })
        },
        resetState({ commit }) {
            commit('RESET_GRANTS')
        }
  }
})
