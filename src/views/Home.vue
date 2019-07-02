
<template>
    <div class="home">
      <region></region>
      <bottom-nav></bottom-nav>      
    </div>
</template>

<script>
import bottomNav from '@/components/BottomNav.vue';
import region from '@/views/Region.vue';

export default {
  name: 'home',
  components: {
    region,
    bottomNav
  }
}
</script>


<style>
</style>