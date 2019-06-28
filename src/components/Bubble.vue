<template>
    <div>
        <div v-on:click="addFilter(regions[0])" regionId class="pulsing-bubble md north-am">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="north-am-info" v-if="regions[0]"><div class="region-name">{{regions[0].name}}</div>{{ format(regions[0].totalGrants)}} <br /> ${{ format(regions[0].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[5])"" class="pulsing-bubble sm south-am">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="south-am-info" v-if="regions[5]"><div class="region-name">{{regions[5].name}}</div> {{ format(regions[5].totalGrants)}} <br /> ${{ format(regions[5].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[6])" class="pulsing-bubble sm europe">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="europe-info" v-if="regions[6]"><div class="region-name">{{regions[6].name}}</div>{{ format(regions[6].totalGrants)}} <br /> ${{ format(regions[6].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[2])" class="pulsing-bubble md africa">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="africa-info" v-if="regions[2]"><div class="region-name">{{regions[2].name}}</div>{{ format(regions[2].totalGrants)}} <br /> ${{ format(regions[2].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[4])" class="pulsing-bubble sm oceana">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="oceana-info" v-if="regions[4]"><div class="region-name">{{regions[4].name}}</div>{{ format(regions[4].totalGrants)}} <br /> ${{ format(regions[4].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[1])" class="pulsing-bubble lg asia">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="asia-info" v-if="regions[1]"><div class="region-name">{{regions[1].name}}</div>{{ format(regions[1].totalGrants)}} <br /> ${{ format(regions[1].totalAmount) }}</div>
    </div>
</template>

<script>
    import { mapState } from 'vuex'
    export default {
        name: 'bubble',
        mounted() {
            this.$store.commit('SET_REGIONS')
        },
        methods: {
            format(value) {
                return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            },
            addFilter(region) {
                let regionFilter = { name: region.name, id: region.id }
                this.$store.commit('FILTER_REGION', regionFilter)
                this.$router.push('/grants/' + region.name.replace(" ", "-").toLowerCase());
            }
        },
        computed: mapState(['regions'])
}
</script>

<style scoped>
.pulsing-bubble {
    position: absolute;
    transform: translate(-50%, -50%);
    -webkit-transform: translate(-50%, -50%);
    display: table;
    vertical-align: middle;
    text-align: center;
}
  
.pulsing-bubble:after {
    content: '';
    position: absolute;
    left: 0; 
    top: 0;
    display: block;
    width: 100%;
    height: 100%;
    background-color:#3086AB;
    border-radius: 50%;
    box-shadow: 0 0 8px rgba(0,0,0,.3);
    animation: pulse-dot 1.9s cubic-bezier(0.455, 0.03, 0.515, 0.955) -.4s infinite;
}

.pulsing-text {
    color:#fff;
    display: table-cell;
    position: relative;
    vertical-align: middle;
    z-index:10;
}

.north-am {
    left: 17%;
    top: 47%;
}

    .north-am-info {
        left: 6%;
        top: 42%;
        font-weight: 600;
        position: absolute;
    }

.south-am {
    left: 27%;
    top: 69%;
}
    .south-am-info {
        left: 27%;
        top: 75%;
        position: absolute;
        font-weight: 600;
    }

.europe {
    left:46%;
    top:41%;
}

    .europe-info {
        left: 42%;
        top: 46%;
        position: absolute;
        font-weight: 600;
    }

.africa {
    left:50%;
    top:66%;
}

    .africa-info {
        top: 75%;
        left: 46%;
        position: absolute;
        font-weight: 600;
    }

.oceana {
    right:18%;
    top:78%;
}

.oceana-info {
    right: 23%;
    top: 80%;
    position: absolute;
    font-weight: 600;
}

.asia {
    right:10%;
    top:47%;
}

.asia-info {
    right: 12%;
    font-weight: 600;
    top: 55%;
    position: absolute;
}

.region-name {
    font-size: 20px;
    font-weight: 700;
    font-stretch: expanded;
}

.sm {
    width: 75px;
    height: 75px;
}

.md {
    width: 100px;
    height: 100px;
}

.lg {
    width: 135px;
    height: 135px;
}

@keyframes pulse-dot {
  0% {
    transform: scale(.8);
  }
  50% {
    transform: scale(1);
  }
  100% {
    transform: scale(.8);
  }
}
</style>
