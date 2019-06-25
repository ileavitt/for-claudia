<template>
    <div>
        <div class="pulsing-bubble md north-am">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="pulsing-bubble sm south-am">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="pulsing-bubble sm europe">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="pulsing-bubble md africa">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="pulsing-bubble sm oceana">
            <span class="pulsing-text">VIEW</span>
        </div>
        <div class="pulsing-bubble lg asia">
            <span class="pulsing-text">VIEW</span>
        </div>
        <!--<div class="pulsing-bubble lg">
            <span class="pulsing-text">{{ text }}</span>
        </div> -->
    </div>
</template>

<script>
export default {
    name: 'bubble',
    props: {
        text: String
    },
    methods: {  
    }
}
</script>

<style scoped>
.pulsing-bubble {
    position: absolute;
    /*left: 50%;
    top: 50%;*/
    transform: translate(-50%, -50%);
    -webkit-transform: translate(-50%, -50%);
    display: table;
    vertical-align: middle;
    text-align: center;
}

/* .pulsing-bubble:before {
    content: '';
    position: relative;
    display: block;
    width: 300%;
    height: 300%;
    box-sizing: border-box;
    margin-left: -100%;
    margin-top: -100%;
    border-radius: 50%;
    background-color: #3086AB;
    animation: pulse-ring 1.9s cubic-bezier(0.215, 0.61, 0.355, 1) infinite;
}*/
  
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

.south-am {
    left: 27%;
    top: 69%;
}

.europe {
    left:46%;
    top:41%;
}

.africa {
    left:50%;
    top:66%;
}

.oceana {
    right:18%;
    top:78%;
}

.asia {
    right:10%;
    top:47%;
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

/*@keyframes pulse-ring {
  0% {
    transform: scale(.33);
  }
  80%, 100% {
    opacity: 0;
  }
}*/

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
