<template>
    <div role="tablist">
        <div class="filter">{{$route.name == 'search-grants' ? 'Search Results:' : null}} {{$route.params.filter ? transform($route.params.filter) : null}}</div>
        <b-container class="grantList">
                <b-row>
                    <b-col cols="2">
                        <div>region:{{region.name}}</div>
                        <div>topic:{{topic.name}}</div>
                        <div>Year:{{year}}</div>
                        <div>search: {{search}}</div>
                    </b-col>
                        <b-col class="panel-left col-5">
                            <b-card no-body v-for="(data, index) in grants" v-if="index % 2" v-bind:key="data.grants">
                                <b-card-header class="p-1 animated fadeInUpBig" header-tag="header" role="tab">
                                    <b-button block href="#" variant="info" v-b-toggle="'accordion' + data.id"></b-button>
                                    {{data.organization.name}} <br />${{data.amount}}
                                </b-card-header>
                                <b-collapse accordion="my-accordion" role="tabpanel" :id="'accordion' + data.id">
                                    <b-card-body>
                                        <b-card-text>Given in {{formatDate(data.startDate)}} "{{ data.title }}"</b-card-text>
                                    </b-card-body>
                                </b-collapse>
                            </b-card>
                        </b-col>
                        <b-col class="panel-left col-5">
                            <b-card no-body class="mb-1" v-for="(data, index) in grants" v-if="indexmath(index)" v-bind:key="data.grants">
                                <b-card-header class="p-1 animated fadeInUpBig" header-tag="header" role="tab">
                                    <b-button block href="#" variant="info" v-b-toggle="'accordion' + data.id"></b-button>
                                    {{data.organization.name}} <br />${{data.amount}}
                                </b-card-header>
                                <b-collapse accordion="my-accordion" role="tabpanel" :id="'accordion' + data.id">
                                    <b-card-body>
                                        <b-card-text>Given in {{formatDate(data.startDate)}} "{{ data.title }}"</b-card-text>
                                    </b-card-body>
                                </b-collapse>
                            </b-card>
                        </b-col>
                </b-row>
        </b-container>
    </div>
</template>

<script>
    import {mapState} from 'vuex'
    export default {
        name: 'accordion',
        mounted() {
            var filters = {
                region: this.$store.state.region,
                year: this.$store.state.year,
                topic: this.$store.state.topic
            }
            this.$store.dispatch('loadFiltered', filters)
        },
        methods: {
            transform(value) {
                return value.replace("-", " ")
            },
            formatDate(value) {
                var moment = require('moment');
                var grantDate = moment(value).format('MMMM YYYY')
                return grantDate;
            },
            indexmath(val) {
                if (val % 2) return false
                else return true
            }
        },
        computed: {
            ...mapState(['grants', 'region', 'topic', 'year', 'search'])
        }
}
</script>

<style scoped>

@import "https://cdn.jsdelivr.net/npm/animate.css@3.7.2"; /*Animation library*/


.grantList {
    margin-top: 3em;
    position:relative;
    overflow-y:auto; 
    height: 60vh;
    width: 80vw;
}

.btn,
.card,
.card-header,
.btn-info,
.btn-info:not(:disabled):not(.disabled):active {
    background:none;
    border:none;
}

.card-body {
    margin: auto;
    width: 80%;
}

.icon::before {
    display: inline-block;
    font-style: normal;
    font-variant: normal;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
}

.card-header > a:before {
    color:#ce6b29;
    float: left !important;
    font-family: "Font Awesome 5 Free";
    font-size:48px;
    font-weight: 900;
    content: "\f056";
    padding-right: 5px;
}

.card-header > a.collapsed:before {
    color:#ce6b29;
    float: left !important;
    font-family: "Font Awesome 5 Free";
    font-size:48px;
    font-weight: 900;
    content: "\f055";
}


    .filter {
        color: #392d1c;
        font-weight: bold;
        font-size: 36px;
        text-transform: capitalize;
    }
</style>

