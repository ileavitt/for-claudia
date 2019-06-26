<template>
    <div class="home">
        <!-- <grant-total></grant-total> -->
        <b-container>
            <b-row align-h="center">
                <b-col cols="12">
                    <div id="world-map">
                        <!-- <router-link to="/region"><bubble :text="'VIEW'"></bubble></router-link> -->
                        <router-link to="/region"><bubble></bubble></router-link>
                    </div>
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
        </b-container>
        
        <template v-if="albums.length">
            <div v-for="album in albums" :key="album.id">
                <router-link :to="{ name: 'album', params: { album } }">
                    {{ album.title }}
                </router-link>
            </div>
        </template> -->
    </div>
</template>

<script>
// @ is an alias to /src
// import search from '@/components/Search.vue';
import bottomNav from '@/components/BottomNav.vue';
import bubble from '@/components/Bubble.vue';
import grantTotal from '@/components/GrantTotal.vue';
import axios from 'axios';

export default {
  name: 'home',
  components: {
    // search,
    bottomNav,
    bubble,
    grantTotal
  },
  created() {
    axios.get('https://jsonplaceholder.typicode.com/albums')
        .then((response) => {
        this.originalAlbums = response.data
        this.albums = response.data
    })
  },
  data() {
      return {
          originalAlbums:[],
          albums: []
      }
  },
  methods: {
    handleSearchUpdate(val) {
          if (val == '') {
              return this.albums = this.originalAlbums
          }
          this.albums = this.originalAlbums.filter((album) => {
              if (album.title.indexOf(val) != -1) {
                  return album
              }
          })
      }
  }
}
</script>


<style scoped>
#world-map {
    background:url('~@/assets/map.gif') no-repeat center;
    width:1920px;
    height:1080px;
}
</style>
