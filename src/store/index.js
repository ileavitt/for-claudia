import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import db from '../db.json';
import VueAxios from 'vue-axios';

Vue.use(Vuex)
Vue.use(VueAxios, axios)
const baseUrl = process.env.VUE_APP_BASE_URL

export default new Vuex.Store({
    state: {
        grantTotal: 0,
        Amount: 0,
        grantCount: 0,
        Count: 0,
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
        SET_GRANTS(state, response) {
            var response = response[0]
            state.search = '';
            state.grantCount = response.totalGrants;
            state.grantTotal = response.totalAmount;
            state.grants = response.grants;
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
        SET_YEARS(state, response) {
            state.years = response;
        },
        SET_REGIONS(state, response) {
            state.regions = response;
        },
        SET_TOPICS(state, response) {
            state.topics = response;
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
        SET_TOTALS(state, totals) {
            var totals = totals[0]
            state.Count = totals.totalGrants;
            state.Amount = totals.totalAmount;
        },
        SEARCH(state, payload) {
            var pay = payload.grants[0]
            state.year = '';
            state.region = '';
            state.topic = '';
            state.search = payload.key;
            state.grantCount = pay.totalGrants;
            state.grantTotal = pay.totalAmount;
            state.grants = pay.grants;
        }
    },
    actions: {
        loadFiltered(context) {
            let cleanFilters = {
                topicId: context.state.topic.id ? context.state.topic.id : '',
                regionId: context.state.region.id ? context.state.region.id : '',
                year: context.state.year.name ? context.state.year.name : ''
            }
            context.commit('SET_GRANTS', db.grants)

            /** axios({
                 method: 'post',
                 url: `${baseUrl}/api/grants/filter`,
                 data: cleanFilters,
             }).then((res) => {
                 var response = res.data
                 context.commit('SET_GRANTS', response)
             }); */

        },
        setYears({ commit }) {
            commit('SET_YEARS', db.years)
            /*axios({
                method: 'get',
                url: `${baseUrl}/api/years`
            }).then((res) => {
                var response = res.data
                commit('SET_YEARS', response)
            }); */
        },
        setRegions({ commit }) {
            commit('SET_REGIONS', db.regions)
            /* axios({
                method: 'get',
                url: `${baseUrl}/api/regions`
            }).then((res) => {
                var response = res.data
                commit('SET_REGIONS', response)
            }); */
        },
        setTopics({ commit }) {
            commit('SET_TOPICS', db.topicGroups)
            /*axios({
                method: 'get',
                url: `${baseUrl}/api/topicgroups`
            }).then((res) => {
                var response = res.data
                commit('SET_TOPICS', response)
            }); */
        },
        totalCount({ commit }) {
            commit('SET_TOTALS', db.totalCount)
           /* axios({
                method: 'get',
                url: `${baseUrl}/api/grants/totalcount`
            }).then((res) => {
                var response = res.data
                commit('SET_TOTALS', response)
            }); */
        },
        resetState({ commit }) {
            commit('RESET_GRANTS')
        },
        searchGrants({ commit }, key) {
            let grants = db.grants
            var res = { grants, key }
            commit('SEARCH', res)

           /* axios({
                method: 'post',
                url: `${baseUrl}/api/grants/search`,
                data: { keyword: key }
            }).then((res) => {
                var response = res.data 
                commit('SEARCH', { response, key })
            }); */
        }
  }
})
