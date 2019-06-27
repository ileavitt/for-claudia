<template>
    <b-container>
        <b-row>
            <b-col cols="2">
                <b-button-group size="lg">
                    <button v-on:click="resetGrants" class="text-uppercase btn-style"><</button>
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
                    .then((res) => {
                        this.$router.push('/')
                    })
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
