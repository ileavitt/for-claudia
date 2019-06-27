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
    }
}
</script>

<style>

</style>
