<template>
    <b-container class="grant-total" fluid>
        <b-row id="header-row">
          <b-col>
            <span class="counter">{{ grantTotal }}</span> GRANTS
                <div class='counter two'>${{grantCount}}</div> provided since 1999
           </b-col>
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
        padding-bottom: 80px;
        font-family: DINOT;
        font-size: 55px;
        font-weight: bold;
        color: #392d1c;
    }
    .counter {
        font-size: 65px;
        display: inline-block;
        -webkit-animation: flip .2s 2 linear;
        animation: flipX .2s 2 linear;
    }
    .two {
        padding-left: 30px;
    }

</style>
