import API from '@/services/API'

export default {
    getFilteredGrants(filterObj) {
        return API().post('api/grants/filter' + filterObj)
    },
    getSearchedGrants(keyword) {
        return API().post('api/grants/search' + keyword)
    }
}