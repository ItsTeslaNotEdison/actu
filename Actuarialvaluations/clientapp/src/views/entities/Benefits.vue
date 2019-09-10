<template>
  <div class="home">    
    <BenefitsForm/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import BenefitsForm from "@/components/entities/Benefits/BenefitsForm.vue";

@Component({
  components: {
    BenefitsForm,
  },
})
export default class Benefits extends Vue {
}
</script>