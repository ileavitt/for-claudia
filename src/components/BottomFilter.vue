<template>
    <b-container>
        <b-row>
            <b-col cols="2">
                <b-button-group size="lg">
                    <router-link v-on:click="resetGrants" to="/" class="text-uppercase btn-style"><</router-link>
                </b-button-group>
            </b-col>
            <b-col cols="1" offset="5">
                <i class="material-icons md-48">search</i>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
    import search from '@/components/Search.vue';

    export default {
        name: 'bottomFilter',
        components: {
            search
        },
        methods: {
            resetGrants() {
                this.$store.dispatch('resetState')
            }
        }
}
</script>

<style scoped>
    .btn-style {
        height: 70px;
        width: 70px;
        background-color: red;
    }
</style>
