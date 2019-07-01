<template>
    <div>
        <cards></cards>
        <bottom-nav></bottom-nav>
    </div>
</template>

<script>
    import cards from '@/components/Cards.vue';
    import bottomNav from '@/components/BottomNav.vue'

    export default {
        name: 'topic',
        components: {
            cards,
            bottomNav
        }
    }
</script>