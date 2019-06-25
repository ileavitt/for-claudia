<template>
    <div role="tablist">
        <b-container>
            <b-row>
                <b-col cols="6">
                    <b-card no-body class="mb-1">
                        <b-card-header header-tag="header" class="p-1" role="tab">
                            <b-button block href="#" v-b-toggle.accordion-1 variant="info">Accordion 1</b-button>
                        </b-card-header>
                        <b-collapse id="accordion-1" accordion="my-accordion" role="tabpanel">
                            <b-card-body>
                                <b-card-text></b-card-text>
                                <b-card-text>{{ text }}</b-card-text>
                            </b-card-body>
                        </b-collapse>
                    </b-card>
                </b-col>
                <b-col cols="6">
                    <b-card no-body class="mb-1">
                        <b-card-header header-tag="header" class="p-1" role="tab">
                        <b-button block href="#" v-b-toggle.accordion-2 variant="info">Accordion 2</b-button>
                        </b-card-header>
                        <b-collapse id="accordion-2" accordion="my-accordion" role="tabpanel">
                        <b-card-body>
                            <b-card-text>{{ text }}</b-card-text>
                        </b-card-body>
                        </b-collapse>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>

<script>
export default {
    name: 'accordion',
    data() {
        return {
            text: `
            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry
            richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor
            brunch.
            `
        }
    }
}
</script>

<style>
</style>
