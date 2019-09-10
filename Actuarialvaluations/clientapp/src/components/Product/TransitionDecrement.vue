<template> 
 <b-container>
     Transition Decrement
   </b-container>
</template>
<script lang="ts">
  import moment from "moment";
  import * as toastr from "toastr";
  import { required, between, minValue } from "vuelidate/lib/validators";
  import { Component, Prop, Vue, Watch } from "vue-property-decorator";
  import { AppContainer, TYPES } from "@/app/index";
  import { FormHelper } from "@/helpers";
  import {  ConfigService } from "@/services";
  
   @Component({
     components: {
      
    },    
  })

export default class TransitionDecrement extends Vue {
  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private dateOptions: any = { format: this.configService.Config.DateFormat };
}
</script>