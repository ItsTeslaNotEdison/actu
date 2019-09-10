<template>
  <div class="home">   
    <MarkovStates/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import MarkovStates from "@/components/Product/MarkovStates.vue";

@Component({
  components: {
    MarkovStates,
  },
})
export default class MarkovState extends Vue {
}
</script>