
<template>
    <b-container>
        <b-row>
            <b-card-group deck>
                <b-card v-for="data in topics" header-bg-variant="primary" align="center" class="shadow" :id="data.id" :key="data.id">
                    <div slot="header" class="mb-0 img-container">
                    </div>
                    <b-card-text>
                        <h3 class="topic-header">{{data.name}}</h3>
                        <div class="topic-grants">{{ format(data.totalGrants)}}</div>
                        <div class="topic-total">${{ format(data.totalAmount) }}</div>
                    </b-card-text>
                </b-card>
                    <!-- <b-card v-for="data in topics" header-tag="header" header-bg-variant="primary" align="center" class="shadow" :id="data.id" :key="data.id">
                        <div slot="header" class="mb-0">
                            <div class="img-container">
                                <globe></globe>
                            </div>
                        </div>
                        <b-card-text>
                            <h3 class="topic-header">{{data.name}}</h3>
                            <div class="topic-grants">{{ format(data.totalGrants)}}</div>
                            <div class="topic-total">${{ format(data.totalAmount) }}</div>
                        </b-card-text>
                    </b-card> -->
            </b-card-group>
        </b-row>
    </b-container>
</template>

<script>
    import topicGroups from '../db.json'
    import globe from '@/components/Globe.vue'

    export default {
        name: 'cards',
        components: {
            globe
        },
        data() {
            return {
                topics: topicGroups.topicGroups
            }
        },
        methods: {
            format(value) {
                return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            },
            placeImg() {
              var imgContainer = document.getElementsByClassName('img-container')
              imgContainer[0].innerHTML = '<img src="/img/sun.9240fa97.gif" class="card-img" />'
              imgContainer[1].innerHTML = '<img src="/img/arrow.04a4b532.gif" class="card-img" />'
              imgContainer[2].innerHTML = '<img src="/img/hat.f0b0fb2c.gif" class="card-img" />'
              imgContainer[3].innerHTML = '<img src="/img/globe.1120e292.gif" class="card-img" />'
            }
        },
        mounted: function() {
            this.placeImg()
        }
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
