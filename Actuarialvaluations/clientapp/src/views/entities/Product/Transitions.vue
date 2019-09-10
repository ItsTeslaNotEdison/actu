<template>
  <div class="home">   
    <Transition/>   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { AppContainer, TYPES } from "@/app/index";
import Transition from "@/components/Product/Transitions.vue";

@Component({
  components: {
    Transition,
  },
})
export default class Transitions extends Vue {
}
</script>