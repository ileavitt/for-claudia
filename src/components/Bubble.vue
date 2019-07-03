<template>
    <div>
        <!-- <div v-on:click="addFilter(regions[0])" regionId class="pulsing-bubble md north-am">
            <span class="pulsing-text">VIEW</span>
        </div> -->

        <div v-on:click="addFilter(regions[0])" class="region north-am">
            <img class="bubble" src="@/assets/view-lg.gif" />
        </div>
        <div class="north-am-info region-info" v-if="regions[0]"><div class="region-name">{{ firstLetter(regions[0].name) }}</div>{{ format(regions[0].totalGrants)}} <br /> ${{ format(regions[0].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[5])" class="region south-am">
            <img class="bubble" src="@/assets/view-sm.gif" />
        </div>
        <div class="south-am-info region-info" v-if="regions[5]"><div class="region-name">{{ firstLetter(regions[5].name) }}</div> {{ format(regions[5].totalGrants)}} <br /> ${{ format(regions[5].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[6])" class="region europe">
            <img class="bubble" src="@/assets/view-sm.gif" />
        </div>
        <div class="europe-info region-info" v-if="regions[6]"><div class="region-name">{{ firstLetter(regions[6].name) }}</div>{{ format(regions[6].totalGrants)}} <br /> ${{ format(regions[6].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[2])" class="region africa">
            <img class="bubble" src="@/assets/view-lg.gif" />
        </div>
        <div class="africa-info region-info" v-if="regions[2]"><div class="region-name">{{ firstLetter(regions[2].name) }}</div>{{ format(regions[2].totalGrants)}} <br /> ${{ format(regions[2].totalAmount) }}</div>

        <div v-on:click="addFilter(regions[4])" class="region oceana">
            <img class="bubble" src="@/assets/view-sm.gif" />
        </div>
        <div class="oceana-info region-info" v-if="regions[4]"><div class="region-name">{{ firstLetter(regions[4].name) }}</div>{{ format(regions[4].totalGrants)}} <br /> ${{ format(regions[4].totalAmount) }}</div>
        -->
        <div v-on:click="addFilter(regions[1])" class="region asia">
            <img class="bubble" src="@/assets/view-md.gif" />
        </div>
        <div class="asia-info region-info" v-if="regions[1]"><div class="region-name">{{ firstLetter(regions[1].name) }}</div>{{ format(regions[1].totalGrants)}} <br /> ${{ format(regions[1].totalAmount) }}</div>
    </div>
</template>

<script>
    import { mapState } from 'vuex'
    export default {
        name: 'bubble',
        methods: {
            format(value) {
                return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
            },
            addFilter(region) {
                let regionFilter = { name: region.name, id: region.id }
                this.$store.commit('FILTER_REGION', regionFilter)
                this.$router.push('/grants/region/' + region.name.replace(" ", "-").toLowerCase());
            },
            firstLetter(region) {
                return region.replace(/\w\S*/g, function(txt){
                    return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
                });
            }
        },
        computed: mapState(['regions'])
}
</script>

<style scoped>
.bubble {
    height:42%;
    width:42%;
}

.north-am {
    left: 14%;
    top: 23%;
}

.north-am-info {
    left: 12%;
    top: 34%;
}

.south-am {
    left: 23%;
    top: 54%;
}

.south-am-info {
    left: 22%;
    top: 62%;
}

.europe {
    left:36%;
    top:23%;
}

.europe-info {
    left: 38%;
    top: 33%;
}

.africa {
    left:37%;
    top:46%;
}

.africa-info {
    top: 64%;
    left: 41%;
}

.oceana {
    right:20%;
    top:53%;
}

.oceana-info {
    right: 21%;
    top: 65%;
}

.asia {
    right:16%;
    top:23%;
}

.asia-info {
    right: 18%;
    top: 36%;
}

.region {
    position:absolute;
}

.region-name {
    font-family:'Dinot-Bold';
    font-size: 24px;
}

.region-info {
    font-family: 'Dinot';
    font-size:30px;
    position: absolute;
}


/*.pulsing-bubble {
    position: absolute;
    transform: translate(-50%, -50%);
    -webkit-transform: translate(-50%, -50%);
    display: table;
    vertical-align: middle;
    text-align: center;
}

.pulsing-bubble:before {
    content: '';
    position: relative;
    display: block;
    width: 300%;
    height: 300%;
    box-sizing: border-box;
    margin-left: -100%;
    margin-top: -100%;
    border-radius: 45px;
    background-color: #01a4e9;
    animation: pulse-ring 1.25s cubic-bezier(0.215, 0.61, 0.355, 1) infinite;
}
  
.pulsing-bubble:after {
    content: '';
    position: absolute;
    left: 0; 
    top: 0;
    display: block;
    width: 100%;
    height: 100%;
    background-color:#CE6B29;
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

@keyframes pulse-ring {
  0% {
    transform: scale(.33);
  }
  80%, 100% {
    opacity: 0;
  }
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
}*/
</style>
