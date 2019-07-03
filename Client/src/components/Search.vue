<template>
    <div>
        <b-button class="btn-blue" @click="$bvModal.show('search-keyboard')"><i class="material-icons md-48">search</i></b-button>
        <b-modal id="search-keyboard" hide-footer>
            <div class="control has-icons-left is-clearfix search">
                <div class="search-input">
                    <input v-model="searchInput" placeholder="Search by organization" class="input" />
                    <b-button v-on:click="searchGrants" @click="$bvModal.hide('search-keyboard')">SEARCH</b-button>
                </div>
                <Keyboard v-model="searchInput" :layouts="[
            '1234567890{delete:backspace}|qwertyuiop|asdfghjkl|{shift:goto:1}zxcvbnm|{space:space}{clear:clear}',
            '!@#$%^&*(){delete:backspace}|QWERTYUIOP|ASDFGHJKL|{shift:goto:0}ZXCVBNM|{space:space}{clear:clear}'
            ]" :maxlength="20">
                </Keyboard>
            </div>
        </b-modal>
    </div>

</template>

<script>

import Keyboard from 'vue-keyboard'
export default {
    name: 'search',
    components: {
        Keyboard
    },
    data: () => ({
        searchInput: ''
    }),
    methods: {
        searchGrants() {
            this.$store.dispatch('searchGrants', this.searchInput)
            let keyword = (this.searchInput.replace(" ", "-").toLowerCase());
            this.$router.push('/grants/search/' + keyword)
        }
    }
}

</script>

<style scoped>
.control {
    box-sizing: border-box;
    clear: both;
    font-size: 1rem;
    position: relative;
    text-align: left;
}

.input {
    background-color: #fff;
    border:1px solid #dbdbdb;
    border-radius: 4px;
    box-shadow: inset 0 1px 2px hsla(0,0%,4%,.1);
    color: #363636;
    display:inline-flex;
    line-height:1.5;
    margin:0;
    padding: calc(.375em - 1px) calc(.625em - 1px);
    position: relative;
    vertical-align: top;
}

.control.has-icons-left .input { 
    padding-left: 2.25em;
}

.control.has-icons-left .icon.is-left {
    left: 0;
}

.control.has-icons-left .icon {
    color: #dbdbdb;
    height: 2.25em;
    pointer-events: none;
    position: absolute;
    top: 0;
    width: 2.25em;
    z-index: 4;
}

.btn-blue {
    width: 95px;
    height: 95px;
    box-shadow: 0 0 15px 0 #6c6c6c;
    background-color: #236480;
    border-radius: 50%;
}

</style>
