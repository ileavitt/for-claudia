<template>
    <div>
        <grant-total></grant-total>
        <accordion></accordion>
        <bottom-filter></bottom-filter>
    </div>
</template>

<script>
    import accordion from '@/components/Accordion.vue';
    import grantTotal from '@/components/GrantTotal.vue'
    import bottomFilter from '@/components/BottomFilter.vue'

export default {
    name: 'grants',
    components: {
        accordion,
        grantTotal,
        bottomFilter
        }
}
</script>