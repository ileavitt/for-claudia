<template>
    <b-container class="bottom-filter-nav">
        <b-row>
            <b-col cols="1" offset="1">
                    <b-button class="btn-blue" v-on:click="resetGrants"><i class="material-icons md-48">chevron_left</i></b-button>
            </b-col>
            <b-col>
                <b-form-group label-cols-sm="3" label="Year:" v-if="$route.name !== 'search-grants'">
                    <b-form-select v-model="yearSelected" v-on:change="applyYearFilter" :options="years">
                         <option value="" disabled selected hidden>All years</option>
                    </b-form-select>
                </b-form-group>
            </b-col>
            <b-col>
                <b-form-group label-cols-sm="3" label="Topic:" v-if="$route.name == ('region-grants')">
                    <b-form-select v-model="topicSelected" v-on:change="applyTopicFilter">
                        <option value="" disabled selected hidden>All topics</option>
                        <option v-for="topic in topics" :value="topic" v-bind:key="topic.id">
                            {{topic.name}}
                        </option>
                    </b-form-select>
                </b-form-group>
            </b-col>
            <b-col>
                <b-form-group label-cols-sm="3" label="Region:" v-if="$route.name == 'topic-grants'">
                    <b-form-select v-model="regionSelected" v-on:change="applyRegionFilter">
                         <option value="" disabled selected hidden>All regions</option>
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
        mounted() {
            this.$store.commit('SET_YEARS')
            this.$store.commit('SET_REGIONS')
            this.$store.commit('SET_TOPICS')
        },
        methods: {
            resetGrants() {
                this.$store.dispatch('resetState')
                    .then(() => {
                        this.$router.push('/')
                    })
            },
            applyYearFilter: function () {
                this.$store.commit('FILTER_YEAR', this.yearSelected)
            },
            applyTopicFilter: function () {
                let topicSelected = { id: this.topicSelected.id, name: this.topicSelected.name }
                this.$store.commit('FILTER_TOPIC', topicSelected)
            },
            applyRegionFilter: function () {
                let regionSelected = { id: this.regionSelected.id, name: this.regionSelected.name }
                this.$store.commit('FILTER_REGION', regionSelected)
            }
        },
        computed: {
            ...mapActions(['resetState']),
            ...mapState(['years', 'year', 'regions', 'region', 'topics', 'topic'])
        }
}
</script>

<style scoped>
    /* .btn-style {
        height: 70px;
        width: 70px;
        background-color: red;
    } */
    .bottom-filter-nav {
        height: 30vh;
        margin-top: 5em;
    }
    /* .btn-circle.btn-xl {
        width: 96px;
        height: 96px;
        border-radius: 50px;
        font-size: 60px;
        background-color: #236480;
    } */

    .btn-blue {
        width: 95px;
        height: 95px;
        box-shadow: 0 0 15px 0 #6c6c6c;
        background-color: #236480;
        border-radius: 50%;
    }

    select {
        font-size: 23px;
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
        box-shadow: 0 0 15px 0 #6c6c6c;
    }

</style>
