<template>
  <div class="home">    
    <ModelPointsForm/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import ModelPointsForm from "@/components/entities/ModelPoints/ModelPointsForm.vue";

@Component({
  components: {
    ModelPointsForm,
  },
})
export default class ModelPoints extends Vue {
}
</script>