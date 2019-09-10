<template>
  <div class="home">   
    <CreateProduct/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import CreateProduct from "@/components/Product/CreateProduct.vue";

@Component({
  components: {
    CreateProduct,
  },
})
export default class Product extends Vue {
}
</script>