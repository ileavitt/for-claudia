<template>
    <b-container class="grant-total">
        <b-row>
          <div>{{ grantTotal }} Grants</div>   <div>${{grantCount}} provided since 1999</div>
        </b-row>
    </b-container>
    
</template>

<script>
    import {mapState} from 'vuex'
    export default {
        name: 'grantTotal',
        computed: mapState([
            'grantTotal', 'grantCount'
        ])
    }
</script>

<style>
    .grant-total {
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
