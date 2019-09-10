
<template>
 <b-container>
<b-form @submit.stop.prevent="Save">
  <div>
    <h1> Markov States </h1>
</div>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Applicable Module *" label-for="ApplicableModule">
      <b-form-input autocomplete="off" id="ApplicableModule" type="text"  v-model="$v.record.Applicable_Model_ID.$model" :state="$v.record.Applicable_Model_ID.$dirty ? !$v.record.Applicable_Model_ID.$error : null" aria-describedby="ApplicableModuleError" placeholder="Applicable Module"></b-form-input>
      <b-form-invalid-feedback id="ApplicableModuleError" v-if="!$v.record.Applicable_Model_ID.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="From State ID" label-for="FromStateID">
      <b-form-input autocomplete="off" id="FromStateID" type="text" v-model="$v.record.From_State_ID.$model" :state="$v.record.From_State_ID.$dirty ? !$v.record.From_State_ID.$error : null" aria-describedby="FromStateIDError" placeholder="From State ID"></b-form-input>
      <b-form-invalid-feedback id="FromStateIDError"  v-if="!$v.record.From_State_ID.required">Field is required</b-form-invalid-feedback>   
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="To State ID *" label-for="ToStateID">
      <b-form-input autocomplete="off" id="ToStateID" type="text" v-model="$v.record.To_State_ID.$model" :state="$v.record.To_State_ID.$dirty ? !$v.record.To_State_ID.$error : null" aria-describedby="ToStateIDError" placeholder="To State ID"></b-form-input>
      <b-form-invalid-feedback id="ToStateIDError" v-if="!$v.record.To_State_ID.required" >Field is required</b-form-invalid-feedback>             
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Period *" label-for="Period"> 
       <b-form-input autocomplete="off" id="PeriodID" type="text" v-model="$v.record.PeriodMonthlyIncrements.$model" :state="$v.record.PeriodMonthlyIncrements.$dirty ? !$v.record.PeriodMonthlyIncrements.$error : null" aria-describedby="PeriodError" placeholder="Period"></b-form-input>
      <b-form-invalid-feedback id="PeriodError" v-if="!$v.record.PeriodMonthlyIncrements.required" >Field is required</b-form-invalid-feedback>         
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Value *" label-for="Value">    
       <b-form-input autocomplete="off" id="Value" type="text" v-model="$v.record.IndependantValue.$model" :state="$v.record.IndependantValue.$dirty ? !$v.record.IndependantValue.$error : null" aria-describedby="ValueError" placeholder="Value"></b-form-input>
      <b-form-invalid-feedback id="ValueError" v-if="!$v.record.IndependantValue.required">Field is required</b-form-invalid-feedback>  
    </b-form-group>    
   <div>
      <b-button type="submit" variant="primary" :disabled="$v.record.$invalid">Save</b-button>
      <div class="divider" />
      <button type="reset" class="btn btn-danger btn-md center-block" style="width: 100px; padding:5px" v-on:click="Reset">Reset</button>
    </div>
    <b-container style="padding-top:15px" >
      <!-- <b-form-group group horizontal breakpoint="md" >     -->
        <FileReader id="FileReader"  @load="text = $event" />     
        <b-button @click="clearFiles" class="mr-2">Submit</b-button>
    <!-- </b-form-group> -->
     </b-container>
  </b-form>
   </b-container>
</template>
<script lang="ts">
  import moment from "moment";
  import * as toastr from "toastr";
  import { required, between, minValue } from "vuelidate/lib/validators";
  import { Component, Prop, Vue, Watch } from "vue-property-decorator";
  import { AppContainer, TYPES } from "@/app/index";
  import { FormHelper } from "@/helpers";
  import { MarkovStatesService, ConfigService } from "@/services";
  import { MarkovStates, FormMode } from "@/models";
  import FileReader from "@/components/common/FileReader";

   @Component({
     components: {
      FileReader
    },  
    validations: {
      record: {
        Applicable_Model_ID: {
          required
        },
        From_State_ID: {
          required
        },
        To_State_ID: {
          required,         
        },
        PeriodMonthlyIncrements: {
          required,          
        },
        IndependantValue: {
          required,          
        }        
      }
    }
  })

export default class MarkovStatesForm extends Vue {

  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private MarkovStatesService: MarkovStatesService = AppContainer.get<MarkovStatesService>(TYPES.Services.MarkovStatesService);  
  public  record: MarkovStates = new MarkovStates();
  private file: any = '';
  private text : any = '';
  private parse_header: any = [];
  private parse_csv!: any;
  private sortOrders!: any;
  private sortKey: any = '';
  
  public Save(): any {
    this.$v.$reset();
    this.$v.$touch();
    FormHelper.HandleSave(this.MarkovStatesService.Create(this.record), this);
    this.$v.$reset();
  }

  public Reset(): any {
    this.$v.$reset();     
  }

  public clearFiles(event: any) {    
   this.parse_csv = this.csvJSON(this.text)
   let lstMarkovStates  = this.parse_csv.map((entity: any) => new MarkovStates(entity))
   FormHelper.HandleSave(this.MarkovStatesService.BulkInsert(lstMarkovStates), this);
  }

  public csvJSON(csv: any){
    debugger;
      var lines = csv.split("\n")
      var result: any = []; ;
      lines.map(function(line: any, indexLine: any){
        var currentline = line.split(",");
        result.push(currentline);
      });;
      result.pop(); // remove the last item because undefined values;
      return result;
    }
}
</script>