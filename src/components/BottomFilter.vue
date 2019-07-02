<template>
    <b-container class="bottom-filter-nav fixed-bottom">
        <b-row align-h="center">
            <b-col cols="2">
                <b-button class="btn-blue nav-button" v-on:click="resetGrants"><i class="material-icons md-48">chevron_left</i></b-button>
            </b-col>
            <b-col cols="8">
                <b-row align-h="center">
                    <b-col cols="4" class="text-left" v-if="$route.name !== 'search-grants'">
                        <b-form-group label="Year" >
                            <b-form-select v-model="yearSelected" v-on:change="applyYearFilter" class="shadow-bg">
                                <option value="" disabled selected hidden>All years</option>
                                <option v-for="year in years" :value="year" v-bind:key="year.id">
                                    {{year.name}}
                                </option>
                            </b-form-select>
                        </b-form-group>
                    </b-col>
                    <b-col cols="4" class="text-left" v-if="$route.name == 'region-grants'">
                        <b-form-group label="Topic">
                            <b-form-select id="topic-filter" v-model="topicSelected" v-on:change="applyTopicFilter" class="shadow-bg">
                                <option value="" disabled selected hidden>All topics</option>
                                <option v-for="topic in topics" :value="topic" v-bind:key="topic.id">
                                    {{topic.name}}
                                </option>
                            </b-form-select>
                        </b-form-group>
                    </b-col>
                    <b-col cols="4" class="text-left" v-if="$route.name == 'topic-grants'">
                        <b-form-group label="Region">
                            <b-form-select v-model="regionSelected" v-on:change="applyRegionFilter" class="shadow-bg">
                                <option value="" disabled selected hidden>All regions</option>
                                <option v-for="region in regions" :value="region" v-bind:key="region.id">
                                    {{region.name}}
                                </option>
                            </b-form-select>
                        </b-form-group>
                    </b-col>
                </b-row>
            </b-col>
            <b-col cols="1" offset="1">
                <search></search>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
    import search from '@/components/Search.vue';
    import { mapActions, mapState } from 'vuex';

    export default {
        name: 'bottomFilter',
        components: {
            search
        },
        data() {
            return {
                yearSelected: this.$store.state.year,
                topicSelected: this.$store.state.topic,
                regionSelected: this.$store.state.region
            }
        },
        methods: {
            resetGrants() {
                this.$store.dispatch('resetState')
                    .then(() => {
                        this.$router.push('/')
                    })
            },
            applyYearFilter: function () {
                let yearSelected = { id: this.yearSelected.id, name: this.yearSelected.name }
                this.$store.commit('FILTER_YEAR', yearSelected)
                this.$store.dispatch('loadFiltered')
            },
            applyTopicFilter: function () {
                let topicSelected = { id: this.topicSelected.id, name: this.topicSelected.name }
                this.$store.commit('FILTER_TOPIC', topicSelected)
                this.$store.dispatch('loadFiltered')
            },
            applyRegionFilter: function () {
                let regionSelected = { id: this.regionSelected.id, name: this.regionSelected.name }
                this.$store.commit('FILTER_REGION', regionSelected)
                this.$store.dispatch('loadFiltered')
            }
        },
        computed: {
            ...mapActions(['resetState']),
            ...mapState(['years', 'year', 'regions', 'region', 'topics', 'topic'])
        }
}
</script>

<style scoped>
    .bottom-filter-nav {
        bottom:80px;
    }

    .btn-blue {
        width: 95px;
        height: 95px;
        box-shadow: 0 0 15px 0 #6c6c6c;
        background-color: #236480;
        border-radius: 50%;
    }

    select {
        font-size: 24px;
        width: 370px;
        height: 80px;
        -webkit-appearance: none;
        -moz-appearance: none;
        background: transparent;
        border: none;
        border-radius: 0px;
        background-image: url("data:image/svg+xml;utf8,<svg fill='black' height='82' viewBox='0 0 24 24' width='82' xmlns='http://www.w3.org/2000/svg'><path d='M0 0h24v24H0z' fill='rgb(35,100,128)'/><path d='M16.59 8.59L12 13.17 7.41 8.59 6 10l6 6 6-6z' fill='white'/></svg>");
        background-repeat: no-repeat;
        background-position-x: 100%;
        background-position-y: auto;
        /* box-shadow: 0 0 15px 0 #6c6c6c; */
    }

    .form-label {
        font-size: 24px;
    }

</style>
