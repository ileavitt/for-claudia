<template>
    <b-container class="grant-total">
        <b-row align-h="center">
            <b-col cols="3">
                <span class="counter">{{ numberWithCommas(grantCount) }}</span><span class="grant-text">GRANTS</span>
            </b-col>
            <b-col cols="6">
                <span class="counter">${{ numberWithCommas(grantTotal) }}</span> <span class="grant-text">{{$route.name == 'topic-grants' ? null : (topic.name ? 'for ' + topic.name : null)}}  {{$route.name == 'region-grants' ? null : (region.name ? 'in ' + region.name : null)}} {{year.name ? 'during ' + year.name : 'provided since 1999'}}</span>
            </b-col>
        </b-row>
        <div class="filter">{{$route.name == 'search-grants' ? 'Search Results:' : null}} {{$route.params.filter ? transform($route.params.filter) : null}}</div>
    </b-container>
</template>

<script>
    import {mapState} from 'vuex'
    export default {
        name: 'listTotal',
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
        font-size: 65px;
        display: inline-block;
        -webkit-animation: flip .2s 2 linear;
        animation: flipX .2s 2 linear;
    }

    .filter {
        color: #392d1c;
        font-weight: bold;
        font-size: 36px;
        text-transform: capitalize;
    }

    .grant-text {
        font-size:36px;
        padding-left:12px;
    }
    
</style>
