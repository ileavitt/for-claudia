<template>
    <b-container class="grant-total">
        <b-row align-h="center">
            <b-col cols="3">
                <ICountUp :endVal="grantCount" :options="options" class="counter"></ICountUp><span class="grant-text">GRANTS</span>
                <!-- <span class="counter">{{ numberWithCommas(grantCount) }}</span><span class="grant-text">GRANTS</span> -->
            </b-col>
            <b-col cols="6">
                <ICountUp :endVal="grantTotal" :options="amountOptions"  class="counter"></ICountUp> <span class="grant-text">{{$route.name == 'topic-grants' ? null : (topic.name ? 'for ' + topic.name : null)}}  {{$route.name == 'region-grants' ? null : (region.name ? 'in ' + region.name : null)}} {{year.name ? 'during ' + year.name : 'provided since 1999'}}</span>
                <!-- <span class="counter">${{ numberWithCommas(grantTotal) }}</span> <span class="grant-text">{{$route.name == 'topic-grants' ? null : (topic.name ? 'for ' + topic.name : null)}}  {{$route.name == 'region-grants' ? null : (region.name ? 'in ' + region.name : null)}} {{year.name ? 'during ' + year.name : 'provided since 1999'}}</span> -->
            </b-col>
        </b-row>
        <div class="filter">{{$route.name == 'search-grants' ? 'Search Results:' : null}} {{$route.params.filter ? transform($route.params.filter) : null}}</div>
    </b-container>
</template>

<script>
    import {mapState} from 'vuex'
    import ICountUp from 'vue-countup-v2';
    export default {
        name: 'listTotal',
        components: {
            ICountUp
        },
        data() {
            return {
                options: {
                    separator: ','
                },
                amountOptions: {
                    separator: ',',
                    prefix: '$'
                }
            }
        },
        methods: {
            transform(value) {
                return value.replace("-", " ")
            },
            numberWithCommas(x) {
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
        },
        computed: mapState([
            'grantTotal', 'grantCount', 'region', 'topic', 'year', 'search'
        ])

    }
</script>

<style>
    .grant-total {
        font-family:'Dinot-Bold'!important;
    }

    .counter {
        display: inline-block;
    }

    .filter {
        color: #392d1c;
        font-family: 'Dinot-Bold';
        font-size: 36px;
    }

    .grant-text {
        font-size:36px;
        padding-left:12px;
    }
    
</style>
