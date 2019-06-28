<template>
    <div role="tablist">
        <div class="filter">{{$route.params.filter ? transform($route.params.filter) : null}} region:{{region.name}} topic:{{topic.name}} Year:{{year}}</div>
        <b-container>
            <b-row>
                <div class="panel-left col-sm-6">
                    <b-card no-body class="mb-1" v-for="(data, index) in grants" v-if="index % 2">
                        <b-card-header header-tag="header" class="p-1" role="tab">
                            <b-button block href="#" variant="info" v-b-toggle="'accordion' + data.id"></b-button>
                            {{data.organization.name}} ${{data.amount}}
                        </b-card-header>
                        <b-collapse accordion="my-accordion" role="tabpanel" :id="'accordion' + data.id">
                            <b-card-body>
                                <b-card-text>Given in {{formatDate(data.startDate)}} "{{ data.title }}"</b-card-text>
                            </b-card-body>
                        </b-collapse>
                    </b-card>
                </div>

                <div class="panel-left col-sm-6">
                    <b-card no-body class="mb-1" v-for="(data, index) in grants" v-if="indexmath(index)">
                        <b-card-header header-tag="header" class="p-1" role="tab">
                            <b-button block href="#" variant="info" v-b-toggle="'accordion' + data.id"></b-button>
                            {{data.organization.name}} ${{data.amount}}
                        </b-card-header>
                        <b-collapse accordion="my-accordion" role="tabpanel" :id="'accordion' + data.id">
                            <b-card-body>
                                <b-card-text>Given in {{formatDate(data.startDate)}} "{{ data.title }}"</b-card-text>
                            </b-card-body>
                        </b-collapse>
                    </b-card>
                </div>
            </b-row>
        </b-container>
    </div>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'
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
                var grantDate = moment(value).format('MMMM YYYY')
                return grantDate;
            },
            indexmath(val) {
                if (val % 2) return false
                else return true
            }
        },
        computed: {
            ...mapState(['grants', 'region', 'topic', 'year'])
        }
}
</script>

<style scoped>
.btn,
.card,
.card-header,
.btn-info,
.btn-info:not(:disabled):not(.disabled):active {
    background:none;
    border:none;
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
    font-weight: bold;
    font-size: 38px;
    text-transform: capitalize;
}
</style>

