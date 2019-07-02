
<template>
    <div class="home">
        <grant-total></grant-total>
      <region></region>
      <bottom-nav></bottom-nav>      
    </div>
</template>

<script>
    import bottomNav from '@/components/BottomNav.vue';
    import region from '@/views/Region.vue';
    import grantTotal from '@/components/GrantTotal.vue'
    export default {
        name: 'home',
        components: {
            region,
            bottomNav,
            grantTotal
        }
    }
</script>


<style scoped>
</style>