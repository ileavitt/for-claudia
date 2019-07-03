<template>
    <div id="app">
        <b-container class="mb-3">
            <b-row>
                <b-col>
                    <router-link to="/">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/about">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/region">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/grants">
                    </router-link>
                </b-col>
            </b-row>
        </b-container>
        <router-view />
    </div>
</template>

<script>

export default {
        name: 'App',
        created() {
            this.$store.dispatch('setYears')
            this.$store.dispatch('setRegions')
            this.$store.dispatch('setTopics')
        }
}
</script>

<style>

</style>
