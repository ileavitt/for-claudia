<template>
    <b-container class="grant-total" fluid>
        <b-row align-h="center">
            <b-col cols="3">
                <span class="counter">{{ numberWithCommas(grantTotal) }}</span><span class="grant-text">GRANTS</span>
            </b-col>
            <b-col cols="6">
                <span class="counter">${{ numberWithCommas(grantCount) }}</span><span class="grant-text">provided since 1999</span>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
    import {mapState} from 'vuex'
    export default {
        name: 'grantTotal',
        methods: {
            numberWithCommas(x) {
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
        },
        computed: mapState([
            'grantTotal', 'grantCount'
        ])

    }
</script>

<style>
.grant-total {
    /* display: flex; */
    font-family:'Dinot-Bold'!important;
    /* justify-content: center; */
    /* align-items: center; */
    /* padding-bottom: 80px; */
}

.counter {
    /* display: inline-block; */
    font-size:60px;
    -webkit-animation: flip .2s 2 linear;
    animation: flipX .2s 2 linear;
}

.grant-text {
    font-size:36px;
    padding-left:12px;
}

/* .two {
    padding-left: 30px;
} */

</style>
