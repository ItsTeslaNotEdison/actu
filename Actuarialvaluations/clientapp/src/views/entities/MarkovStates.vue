<template>
  <div class="home">
    <MarkovStatesForm/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import MarkovStatesForm from "@/components/entities/MarkovStates/MarkovStatesForm.vue";
@Component({
  components: {
    MarkovStatesForm,
  },
})
export default class MarkovStates extends Vue {
}
</script>