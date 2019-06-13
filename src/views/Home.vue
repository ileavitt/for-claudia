<template>
  <div class="home">
    <Search @search-update="handleSearchUpdate"></Search>
    <template v-if="albums.length">
        <div v-for="album in albums" :key="album.id">
            <router-link :to="{ name: 'album', params: { album } }">
                {{ album.title }}
            </router-link>
        </div>
    </template>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue';
import Search from '@/components/Search.vue';
import axios from 'axios';

export default {
  name: 'home',
  components: {
    Search
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
