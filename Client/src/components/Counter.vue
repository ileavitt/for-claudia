<template>
    <div id='counter'>{{ mutableStart }}</div>
</template>

<script>
import GrantTotalVue from './GrantTotal.vue';
    export default {
        name : 'counter',
        props: [
            'startValue',
            'endValue'
        ],
        data: function() {
            return {
                mutableStart : this.startValue,
                endValue : this.endValue
            }
        },
        methods: {
            startCountUp() {
               var interval = setInterval(this.countUp, .5);
               
            },
            countUp(){
                if(this.mutableStart >= this.endValue)
                {
                    clearInterval(this.countUp);
                } 
                else{
                    return this.mutableStart++;
                }
                
            }
        },
        created: function() {
            this.startCountUp();
        }
    }
</script>

<style>
#counter {
    display: inline-block;
}
</style>