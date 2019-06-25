<template>
    <b-container class="">
        <b-row align-h="left">
            <b-col cols="1">
                <!-- <div><p class="large-text">{{ getTotalGrantValue() }} <span class="text-uppercase"> {{ message }}</span></p></div> -->
                <div><p class="large-text"><span class="text-uppercase"> {{ message }}</span></p></div>
            </b-col>
        </b-row>
        <b-row>
            <b-col cols="1">
                <div>
                    {{ region }}
                </div>
            </b-col>
        </b-row>
    </b-container>
    
</template>

<script>
import axios from 'axios'

export default {
    name: 'grantTotal',
    props: { 
        text: String
    },
    data() {
        return {
            message: 'grants',
            region: []
        }
    },
    created() {
        axios.get('https://my-json-server.typicode.com/ileavitt/for-claudia/total')
            .then((response) => {
                this.region = response.data
            })
    },
    methods: {  
        // getTotalGrantValue() {

            
            // var total = [
            //     {"id":1,"name":"NORTH AMERICA","totalGrants":2913,"totalAmount":10},
            //     {"id":2,"name":"ASIA","totalGrants":2862,"totalAmount":10},
            //     {"id":3,"name":"AFRICA","totalGrants":2951,"totalAmount":10},
            //     {"id":4,"name":"GLOBAL","totalGrants":2936,"totalAmount":20},
            //     {"id":5,"name":"OCEANIA","totalGrants":2830,"totalAmount":3},
            //     {"id":6,"name":"SOUTH AMERICA","totalGrants":2753,"totalAmount":11},
            //     {"id":7,"name":"EUROPE","totalGrants":2751,"totalAmount":100}
            // ]

            // var sum = 0;

            // for (var key in total) {
            //     sum += total[key].totalAmount
            // }

            // return sum;
        // }
    }
}
</script>

<style>

</style>
