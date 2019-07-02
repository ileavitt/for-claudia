<template>
    <b-container class="grant-total" fluid>
        <b-row id="header-row">
            <b-col>
                <span class="counter">{{ grantCount }}</span> GRANTS
                <div class='counter two'>${{ grantTotal }}</div> {{$route.name == 'topic-grants' ? null : (topic.name ? 'for ' + topic.name : null)}}  {{$route.name == 'region-grants' ? null : (region.name ? 'in ' + region.name : null)}} {{year.name ? 'during ' + year.name : 'provided since 1999'}}
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
        },
        computed: mapState([
            'grantTotal', 'grantCount', 'region', 'topic', 'year', 'search'
        ])

    }
</script>

<style>
    .grant-total {
        display: inline;
        justify-content: center;
        align-items: center;
        padding-bottom: 70px;
        font-family: DINOT;
        font-size: 55px;
        font-weight: bold;
        color: #392d1c;
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
    .two {
        padding-left: 30px;
    }
</style>
