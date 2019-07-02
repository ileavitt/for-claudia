<template>
    <b-container class="bottom-filter-nav">
        <b-row>
            <b-col cols="1" offset="1">
                    <b-button class="btn btn-danger btn-circle btn-xl" v-on:click="resetGrants">
                        <i class="fas fa-angle-left"></i>
                    </b-button>
            </b-col>
            <b-col>
                <b-form-group label="Year:" v-if="$route.name !== 'search-grants'">
                    <b-form-select v-model="yearSelected" v-on:change="applyYearFilter">
                        <option v-for="year in years" :value="year" v-bind:key="year.id">
                            {{year.name}}
                        </option>
                    </b-form-select>
                </b-form-group>
            </b-col>
            <b-col>
                <b-form-group label="Topic:" v-if="$route.name == 'region-grants'">
                    <b-form-select v-model="topicSelected" v-on:change="applyTopicFilter">
                        <option v-for="topic in topics" :value="topic" v-bind:key="topic.id">
                            {{topic.name}}
                        </option>
                    </b-form-select>
                </b-form-group>
            </b-col>
            <b-col>
                <b-form-group label="Region:" v-if="$route.name == 'topic-grants'">
                    <b-form-select v-model="regionSelected" v-on:change="applyRegionFilter">
                        <option v-for="region in regions" :value="region" v-bind:key="region.id">
                            {{region.name}}
                        </option>
                    </b-form-select>
                </b-form-group>
            
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
    .btn-style {
        height: 70px;
        width: 70px;
        background-color: red;
    }
    .bottom-filter-nav {
        height: 30vh;
        margin-top: 5em;
    }
    .btn-circle.btn-xl {
        width: 96px;
        height: 96px;
        border-radius: 50px;
        font-size: 60px;
        background-color: #236480;
    }
</style>
