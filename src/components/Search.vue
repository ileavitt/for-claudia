<template>
    <div class="control has-icons-left is-clearfix search">
        <input v-model="searchInput" @click="toggle" placeholder="Search..." class="input" />
        <span class="icon is-left">
            <i class="mdi mdi-magnify mdi-24px"></i>
        </span>
        <Keyboard v-model="searchInput" v-show="isOpen" :layouts="[
            '1234567890{delete:backspace}|qwertyuiop|asdfghjkl|{shift:goto:1}zxcvbnm|{space:space}{clear:clear}{enter:enter}',
            '!@#$%^&*(){delete:backspace}|QWERTYUIOP|ASDFGHJKL|{shift:goto:0}ZXCVBNM|{space:space}{clear:clear}{enter:enter}'
            ]" :maxlength="20">
        </Keyboard>
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
        isOpen: false,
        searchInput: ''
    }),
    methods: {
        toggle() {
            this.isOpen = !this.isOpen
        }
    },
    watch: {
        searchInput(newVal, oldVal) {
            this.$emit('search-update', newVal)
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
    font-size:1rem;
    height:2.25em;
    line-height:1.5;
    margin:0;
    max-width: 100%;
    padding: calc(.375em - 1px) calc(.625em - 1px);
    position: relative;
    vertical-align: top;
    width: 100%;
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
</style>
