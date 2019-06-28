<template>
    <div class="region">
        <b-row align-h="center">
            <b-col cols="12">
                <div id="world-map">
                    <bubble></bubble>
                </div>
            </b-col>
        </b-row>
    </div>
</template>

<script>
// @ is an alias to /src
import bubble from '@/components/Bubble.vue';

export default {
  name: 'region',
  components: {
    bubble
  }
}
</script>


<style scoped>
    #world-map {
        background: url('~@/assets/map.gif') no-repeat center;
        margin: auto;
        width: 1920px;
        height: 700px;
    }
</style>