<template>
    <div class="home">
        <!-- <grant-total></grant-total> -->
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
        <!-- <b-container class="mb-3">
            <b-row>
                <b-col>
                    <search @search-update="handleSearchUpdate"></search>
                </b-col>
            </b-row>
            <b-row>
                <b-col>
                    <router-link to="/region"><bubble :text="'VIEW'"></bubble></router-link>
                </b-col>
            </b-row>
        </b-container> -->
    </div>
</template>

<script>
// @ is an alias to /src
// import search from '@/components/Search.vue';
import bottomNav from '@/components/BottomNav.vue';
import region from '@/views/Region.vue';
import grantTotal from '@/components/GrantTotal.vue';
import axios from 'axios';

export default {
  name: 'home',
  components: {
    // search,
    region,
    bottomNav,
    grantTotal
  },
  created() {
    axios.get('https://jsonplaceholder.typicode.com/albums')
        .then((response) => {
        this.grants = response.data
    })
  },
  data() {
      return {
          grants: []
      }
  },
  methods: {
    handleSearchUpdate(val) {
          if (val == '') {
              return this.grants = this.grants
          }
      }
  }
}
</script>


<style scoped>
</style>
