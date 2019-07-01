<template>
    <div id="world-map">
        <bubble></bubble>
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