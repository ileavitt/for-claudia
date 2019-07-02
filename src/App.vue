<template>
    <div id="app">
        <grant-total></grant-total>
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
    import grantTotal from '@/components/GrantTotal.vue';

export default {
    name: 'App',
    components: {
        grantTotal
    }
}
</script>

<style>

</style>
