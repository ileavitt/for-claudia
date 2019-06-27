
<template>
    <div class="home">
        <grant-total></grant-total>
        <b-container>
            <b-row align-h="center">
                <b-col cols="12">
                   <region></region>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12">
                    <bottom-nav></bottom-nav>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>

<script>
import bottomNav from '@/components/BottomNav.vue';
import region from '@/views/Region.vue';
import grantTotal from '@/components/GrantTotal.vue';
import axios from 'axios';

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