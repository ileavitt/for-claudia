<template>
    <div id="app">
        <b-container class="mb-3">
            <b-row>
                <b-col>
                    <router-link to="/">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/about">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/region">
                    </router-link>
                </b-col>
                <b-col>
                    <router-link to="/grants">
                    </router-link>
                </b-col>
            </b-row>
        </b-container>
        <router-view />
    </div>
</template>

<script>

export default {
        name: 'App',
        created() {
            this.$store.dispatch('setYears')
            this.$store.dispatch('setRegions')
            this.$store.dispatch('setTopics')
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
  margin-top: 50px;
}
*, body {
    max-height: 1600px !important;
}

.container {
    max-width:1920px!important;
}

.shadow-bg {
    box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)!important;
}

.material-icons.md-48 { 
    font-size: 48px;
}
.modal {
    padding-top: 45vh;
}
.modal-content {
    width: 70vw !important;
}
.modal-dialog {
    max-width: 70vw !important;
}
.modal-header {
    border-bottom: none !important;
}
.modal-header {
    font-size: 40px;
}

.modal-dialog button {
    width: 80px !important;
    height: 60px !important;
}


</style>
