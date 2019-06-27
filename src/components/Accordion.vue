<template>
    <div role="tablist">
        <div class="filter">{{$route.params.filter ? transform($route.params.filter) : null}}</div>
        <b-container>
            <b-row>
                <b-col cols="6" v-for="data in grants">
                    <b-card no-body class="mb-1">
                        <b-card-header header-tag="header" class="p-1" role="tab">
                            <b-button block href="#" variant="info" v-b-toggle="'accordion' + data.id"></b-button>
                            {{data.organization.name}} ${{data.amount}} 
                            <div :id="data.id">{{ data.id }} </div>
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
    import {mapMutations, mapState} from 'vuex'
    export default {
        name: 'accordion',
        mounted() {
            let filters = {
                region: '',
                year: '',
                topic: ''
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
            }
        },
        computed: mapState(['grants'])
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

