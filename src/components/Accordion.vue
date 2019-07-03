<template>
    <div role="tablist">
        <transition name="fade">
            <div class="loading" v-show="loading">
                <span class="fa fa-spinner fa-spin"></span> Loading
            </div>
        </transition>
        <b-container class="grantList" id="infinite-scroll">
                <b-row>
                    <b-col cols="2">
                        <div>year</div>
                    </b-col>
                        <b-col class="panel-left col-5">
                            <b-card no-body v-for="(data, index) in grantScroll" v-if="index % 2" v-bind:key="data.grants">
                                <b-card-header class="p-1 animated fadeInUp" header-tag="header" role="tab">
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
                            <b-card no-body class="mb-1" v-for="(data, index) in grantScroll" v-if="indexmath(index)" v-bind:key="data.grants">
                                <b-card-header class="p-1 animated fadeInUp" header-tag="header" role="tab">
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
        data() {
            return {
                nextItem: 1,
                loading: false,
                grantScroll: []
            }
        },
        mounted() {
            if (this.$route.name === 'region-grants' || this.$route.name === 'grants' || this.$route.name === 'topic-grants') {
                this.$store.dispatch('loadFiltered')
            }
            const listElm = document.querySelector('#infinite-scroll');
            listElm.addEventListener("scroll", e => {
                if (listElm.scrollTop + listElm.clientHeight >= listElm.scrollHeight) {
                    this.loadMore();
                }
            });
            this.grantScroll = this.$store.state.grants;
        },
        methods: {
            formatDate(value) {
                var moment = require('moment');
                var grantDate = moment(value).format('MMMM YYYY')
                return grantDate;
            },
            indexmath(val) {
                if (val % 2) return false
                else return true
            },
            loadMore() {
                this.loading = true;
                console.log("loading")
                this.loading = false;
            },
        },
        computed: {
            ...mapState(['grants'])
        }
}
</script>

<style scoped>

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

/* Animation */
@keyframes fadeInUp {
    from {
        transform: translate3d(0,500px,0)
    }

    to {
        transform: translate3d(0,0,0);
        opacity: 1
    }
}

@-webkit-keyframes fadeInUp {
    from {
        transform: translate3d(0,500px,0)
    }

    to {
        transform: translate3d(0,0,0);
        opacity: 1
    }
}

.animated {
    animation-duration: 1s;
    animation-fill-mode: both;
    -webkit-animation-duration: 1s;
    -webkit-animation-fill-mode: both
}

.fadeInUp {
    opacity: 0;
    animation-name: fadeInUp;
    -webkit-animation-name: fadeInUp;
}

</style>
