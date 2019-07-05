<template>
    <b-container class="grant-total">
        <b-row align-h="center">
            <b-col cols="3">
                     <ICountUp :endVal="Count" :options="options" class="counter"></ICountUp><span class="grant-text">GRANTS</span>
                <!-- <span class="counter">{{ numberWithCommas(Count) }}</span><span class="grant-text">GRANTS</span> -->
            </b-col>
            <b-col cols="6">
                <ICountUp :endVal="Amount" :options="amountOptions" class="counter"></ICountUp><span class="grant-text">provided since 1999</span>
                <!-- <span class="counter">${{ numberWithCommas(Amount) }}</span><span class="grant-text">provided since 1999</span> -->
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
    import {mapState} from 'vuex';
    import ICountUp from 'vue-countup-v2';
    export default {
        name: 'grantTotal',
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
        created() {
            this.$store.dispatch('totalCount')
        },
        methods: {
            numberWithCommas(x) {
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
        },
        computed: mapState([
            'Amount', 'Count'
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
    margin-bottom:20px;
}

.counter {
    font-size:60px;
}

.grant-text {
    font-size:36px;
    padding-left:12px;
}

/* .two {
    padding-left: 30px;
} */

</style>
