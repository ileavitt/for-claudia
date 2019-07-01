<template>
    <b-container>
        <b-row>
            <b-card-group deck>
                <b-card v-for="topic in topics" header-bg-variant="primary" align="center" class="shadow" @click="routing(topic)" :id="topic.id" :key="topic.id">
                    <div slot="header" class="mb-0 img-container">
                    </div>
                    <b-card-text>
                        <h3 class="topic-header">{{topic.name}}</h3>
                        <div class="topic-grants">{{ format(topic.totalGrants)}}</div>
                        <div class="topic-total">${{ format(topic.totalAmount) }}</div>
                    </b-card-text>
                </b-card>
            </b-card-group>
        </b-row>
    </b-container>
</template>

<script>
    import topicGroups from '../db.json'
    import globe from '@/components/Globe.vue'
    import { mapState } from 'vuex'
    
    export default {
        name: 'cards',
        methods: {
            format(value) {
                return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            },
            placeImg() {
              var imgContainer = document.getElementsByClassName('img-container')
              console.log(imgContainer.length)
              imgContainer[0].innerHTML = '<img src="/img/sun.9240fa97.gif" class="card-img" />'
              imgContainer[1].innerHTML = '<img src="/img/arrow.04a4b532.gif" class="card-img" />'
              imgContainer[2].innerHTML = '<img src="/img/hat.f0b0fb2c.gif" class="card-img" />'
              imgContainer[3].innerHTML = '<img src="/img/globe.1120e292.gif" class="card-img" />'
            },
            routing: function (data) {
                let topicFilter = {name: data.name, id: data.id}
                this.$store.commit('FILTER_TOPIC', topicFilter)
                this.$router.push('/grants/topic/' + data.name.replace(" ", "-").toLowerCase())
            }
        },
        mounted() {
            this.$store.commit('SET_TOPICS'),
            this.$nextTick(function () {
                this.placeImg()
            })
        },
        computed: mapState(['topics', 'topic'])
}
</script>

<style>
.card-deck {
    margin: auto auto 10vh;
}
.card-header {
    min-height: 22vh;
    justify-content: center;
    align-items: center;
    display: flex;
}
.card-img {
    width:20%;
    height:20%;
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
