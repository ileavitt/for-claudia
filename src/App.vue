<template>
    <div id="app">
        <div class="grid-container">
            <router-link to="/">
                <btn :text="'Home'"></btn>
            </router-link>
            <router-link to="/about">
                <btn :text="'About'"></btn>
            </router-link>
            <router-link to="/region">
                <btn :text="'Region'"></btn>
            </router-link>
        </div>
        <router-view/>
    </div>
</template>

<script>
import btn from '@/components/Button'

export default {
    name: 'App',
    components: {
        btn
    },
    methods: {
    }
}

</script>

<style>
#app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
}

.grid-container {
    display: grid;
    grid-gap: 10px;
    grid-template-columns: auto auto auto;
    justify-content: center;
}

</style>
