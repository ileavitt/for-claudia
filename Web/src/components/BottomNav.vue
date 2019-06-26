<template>
    <b-container>
        <b-row>
            <b-col cols="2">
                <b-button-group class="mb-10 shadow-bg" size="lg">
                    <!-- <router-link to="/"><b-button class="text-uppercase no-radius active toggle-btn">region</b-button></router-link> -->
                    <!-- <router-link to="/topics"><b-button class="text-uppercase no-radius toggle-btn">topic</b-button></router-link> -->
                    <router-link to="/" class="text-uppercase btn-style">region</router-link>
                    <router-link to="/topics" class="text-uppercase btn-style">topic</router-link>
                </b-button-group>
            </b-col>
            <b-col cols="2" offset="2">
                <b-button-group class="mb-10 shadow-bg" size="lg">
                    <!-- <router-link to="/grants"><b-button class="text-uppercase no-radius">view all grants</b-button></router-link> -->
                    <router-link to="/grants" class="text-uppercase btn-style">view all grants</router-link>
                </b-button-group>
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
    .no-radius {
        border-radius: 0!important;
    }

    .mb-10 {
        margin-bottom: 10rem;
    }

    .btn-group-lg > .btn {
        padding:1rem 2rem;
    }

    .toggle-btn.active {
        background-color: #3086AB;
        border-color: #3086AB;
    }

    .btn-style {
        color:#000;
        padding:1.2rem 2.5rem;
    }

    .btn-style.router-link-exact-active {
        background-color:#3086AB;
        color:#fff;
    }

    .btn-style:hover,
    .btn-style:active {
        text-decoration:none;
    }
</style>
