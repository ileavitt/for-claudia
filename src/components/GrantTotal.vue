<template>
    <b-container class="grant-total">
        <b-row>
          <div><div class="counter">{{ grantTotal }}</div> Grants</div>   <div><div class='counter'>${{grantCount}}</div> provided since 1999</div>
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

    .counter {
        display: inline-block;
        -webkit-animation: flip .2s 2 linear;
        animation: flipX .2s 2 linear;
    }

    @-webkit-keyframes flipX {
        from { transform: rotateX(0deg); }
        to{ transform: rotateY(360deg); }
    }

    @keyframes flipX {
        from { transform: rotateX(0deg); }
        to{ transform: rotateX(360deg); }
    }

</style>
