<template>
  <div class="home">    
    <YieldForm/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import YieldForm from "@/components/entities/Yield/YieldForm.vue";

@Component({
  components: {
    YieldForm,
  },
})
export default class Yield extends Vue {
}
</script>