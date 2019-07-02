<template>
    <div>
        <grant-total></grant-total>
        <cards></cards>
        <bottom-nav></bottom-nav>
    </div>
</template>

<script>
    import cards from '@/components/Cards.vue';
    import bottomNav from '@/components/BottomNav.vue'
    import grantTotal from '@/components/GrantTotal.vue'

    export default {
        name: 'topic',
        components: {
            cards,
            bottomNav,
            grantTotal
        }
    }
</script>