<template>
    <b-container>
        <b-row>
            <b-col cols="2">
                <b-button-group size="lg">
                    <button v-on:click="resetGrants" class="text-uppercase btn-style"><</button>
                </b-button-group>
            </b-col>
            <b-col cols="2">
                <div>
                   SELECT YEAR OPTIONS
                </div>
            </b-col>
            <b-col cols="1" offset="5">
                <i class="material-icons md-48">search</i>
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
    import search from '@/components/Search.vue';
    import { mapActions, mapState } from 'vuex';

    export default {
        name: 'bottomFilter',
        components: {
            search
        },
        mounted() {
            this.$store.commit('SET_YEARS')
        },
        methods: {
            resetGrants() {
                this.$store.dispatch('resetState')
                    .then(() => {
                        this.$router.push('/')
                    })
            },
            updateYearFilter(selected) {
                this.$store.commit('FILTER_YEAR', selected)
            }
        },
        computed: {
            ...mapActions(['resetState']),
            ...mapState(['years', 'year'])
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
