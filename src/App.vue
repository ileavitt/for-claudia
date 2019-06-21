<template>
    <div id="app">
        <b-container class="mb-3">
            <b-row>
                <b-col>
                    <router-link to="/">
                        <b-button variant="success" :text="'Home'">Home</b-button>
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/about">
                        <b-button variant="success" :text="'About'">About</b-button>
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/region">
                        <b-button variant="success" :text="'Region'">Region</b-button>
                    </router-link>
                </b-col>
            </b-row>
        </b-container>
        <router-view/>
    </div>
</template>

<script>
import btn from '@/components/Button'

export default {
  name: 'App',
  components: {
    btn
  },
  methods: {
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
