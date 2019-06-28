<template>
    <b-container>
        <b-row>
            <b-card-group deck>
                    <b-card v-for="data in topics" header="ICON" header-bg-variant="primary" align="center" class="shadow" v-on:click="routing(data)" v-bind:id="data.Id">
                        <b-card-text>
                            <h3 class="topic-header">{{data.name}}</h3>
                            <div class="topic-grants">{{ format(data.totalGrants)}}</div>
                            <div class="topic-total">${{ format(data.totalAmount) }}</div>
                        </b-card-text>
                    </b-card>
            </b-card-group>
        </b-row>
    </b-container>
</template>

<script>
    import { mapState } from 'vuex'
    export default {
        name: 'cards',
        mounted() {
            this.$store.commit('SET_TOPICS')
        },
        methods: {
            format(value) {
                return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            },
            routing: function (data) {
                let topicFilter = {name: data.name, id: data.id}
                this.$store.commit('FILTER_TOPIC', topicFilter)
                this.$router.push('/grants/' + data.name.replace(" ", "-").toLowerCase())
            }
        },
        computed: mapState(['topics', 'topic'])
}
</script>

<style>
.card-deck {
    margin: auto auto 10vh;
}
.card-header {
    min-height: 12vh;
    justify-content: center;
    align-items: center;
    display: flex;
}
.topic-header {
    padding-top: 25px;
    min-height: 15vh;
    font-weight: 600;
    font-stretch: expanded;
}
.topic-grants {
    font-size: 30px;
}
.topic-total {
    font-size: 20px;
}
.bg-primary {
    background-color: #ce6b29 !important;
}
</style>
