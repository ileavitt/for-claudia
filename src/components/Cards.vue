<template>
    <b-container>
        <b-row>
            <b-card-group deck>
                <!-- <b-card title="Title" img-src="https://picsum.photos/300/300/?image=41" img-alt="Image" img-top> -->
                <b-card header="Some Title" header-bg-variant="primary" align="center" class="shadow">
                    <b-card-text>
                        <h3>Special Projects</h3>
                    </b-card-text>
                </b-card>

                <b-card header="Some Title" header-bg-variant="primary" align="center" class="shadow acc-card-header">
                    <b-card-text>
                        <!-- Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. -->
                        <h3>Poverty &amp; Projects</h3>
                    </b-card-text>
                </b-card>

                <b-card header="Some Title" header-bg-variant="primary" align="center" class="shadow acc-card-header">
                    <b-card-text>
                        <h3>Education &amp; Information</h3>
                    </b-card-text>
                </b-card>

                <b-card header="Some Title" header-bg-variant="primary" align="center" class="shadow acc-card-header">
                    <b-card-text>
                        <h3>Personal Development</h3>
                    </b-card-text>
                </b-card>
            </b-card-group>
        </b-row>
    </b-container>
</template>

<script>
export default {
    name: 'cards',
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
.card-deck {
    min-height:700px;
    margin:0 auto;
}

.bg-primary {
    background-color:#ce6b29!important;
}
</style>
