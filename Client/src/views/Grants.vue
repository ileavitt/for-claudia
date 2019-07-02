<template>
    <div>
       <list-total></list-total>
        <accordion></accordion>
        <bottom-filter></bottom-filter>
    </div>
</template>

<script>
    import accordion from '@/components/Accordion.vue';
    import bottomFilter from '@/components/BottomFilter.vue'
    import listTotal from '@/components/ListTotal.vue'
export default {
    name: 'grants',
    components: {
        accordion,
        bottomFilter,
        listTotal
        }
}
</script>