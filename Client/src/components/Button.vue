<template>
    <div>
         <button class="button" @click="handleBtnClick($event)">
             {{ text }}
         </button>
    </div>
    
</template>

<script>
export default {
    name: 'btn',
    props: {
        text: String
    },
    methods: {
        handleBtnClick() {
            this.$emit('btn-click')
        }
    }
}
</script>

<style>
.button {
    align-items: center;
    background-color: #fff;
    border:1px solid #dbdbdb;
    border-radius: 4px;
    box-shadow: none;
    color: #363636;
    cursor: pointer;
    display: inline-flex;
    font-size: 1rem;
    justify-content: center;
    height: 2.25em;
    line-height: 1.5;
    padding: calc(.375em - 1px) .75em;
    position: relative;
    text-align: center;
    vertical-align: top;
    white-space: nowrap;
    -webkit-appearance: none;
}
</style>
