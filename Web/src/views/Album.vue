<template>
    <div>
        <div v-for="photo in photos" :key="photo.id">
            {{ photo }}
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    name: 'album',
    created() {
        var albumId = this.$route.params.album.id; 
        axios.get('https://jsonplaceholder.typicode.com/photos')
            .then((response) => {
                this.photos = response.data.filter((photo) => {
                    return photo.albumId === albumId;
                }) ;
            })
    },
    data() {
        return {
            photos: null
        }
    }
}
</script>

<style>

</style>
