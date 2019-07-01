<template>
    <div>
        <accordion></accordion>
        <bottom-filter></bottom-filter>
    </div>
</template>

<script>
    import accordion from '@/components/Accordion.vue';
    import bottomFilter from '@/components/BottomFilter.vue'

export default {
    name: 'grants',
    components: {
        accordion,
        bottomFilter
        }
}
</script>