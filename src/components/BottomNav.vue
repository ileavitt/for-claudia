<template>
    <b-container id="bottom-nav" class="fixed-bottom">
        <b-row align-h="center">
            <b-col cols="4">
                <b-button-group class="shadow-bg" size="lg">
                    <router-link to="/" class="text-uppercase btn-style"><span class="btn-group-text">region</span></router-link>
                    <router-link to="/topics" class="text-uppercase btn-style"><span class="btn-group-text">topic</span></router-link>
                </b-button-group>
            </b-col>
            <b-col cols="2" offset="1">
                <b-button-group class="shadow-bg" size="md">
                    <router-link to="/grants/all-grants" class="text-uppercase btn-style"><span class="btn-group-text">view all grants</span></router-link>
                </b-button-group>
            </b-col>
            <b-col cols="2" offset="3">
                <search></search>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
import search from '@/components/Search.vue';

export default {
    name: 'bottomNav',
    components: {
        search
    }
}
</script>

<style scoped>
    #bottom-nav {
        bottom:80px;
    }

    .no-radius {
        border-radius: 0!important;
    }

    .mb-10 {
        margin-bottom: 10rem;
    }

    .toggle-btn.active {
        background-color: #3086AB;
        border-color: #3086AB;
    }

    .btn-style {
        color:#000;
        padding:1.1rem 0;
    }

    .btn-group-lg > a {
        width:250px;
    }

    .btn-group-md > a {
        width:400px;
    }

    .btn-group-text {
        font-family:'Dinot-Bold';
        font-size:30px;
    }

    .btn-style.router-link-exact-active {
        background-color:#236480;
        color:#fff;
    }

    .btn-style:hover,
    .btn-style:active {
        text-decoration:none;
    }
</style>
