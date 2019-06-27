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

<style scoped>
.btn,
.card,
.card-header,
.btn-info,
.btn-info:not(:disabled):not(.disabled):active {
    background:none;
    border:none;
}

.icon::before {
    display: inline-block;
    font-style: normal;
    font-variant: normal;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
}

.card-header > a:before {
    color:#ce6b29;
    float: left !important;
    font-family: "Font Awesome 5 Free";
    font-size:48px;
    font-weight: 900;
    content: "\f056";
    padding-right: 5px;
}

.card-header > a.collapsed:before {
    color:#ce6b29;
    float: left !important;
    font-family: "Font Awesome 5 Free";
    font-size:48px;
    font-weight: 900;
    content: "\f055";
}
</style>

