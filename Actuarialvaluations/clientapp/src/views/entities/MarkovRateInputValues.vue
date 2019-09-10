<template>
  <div class="home">
    <MarkovRateInputValuesForm/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import MarkovRateInputValuesForm from "@/components/entities/MarkovRateInputValues/MarkovRateInputValuesForm.vue";
@Component({
  components: {
    MarkovRateInputValuesForm,
  },
})
export default class MarkovRateInputValues extends Vue {
}
</script>