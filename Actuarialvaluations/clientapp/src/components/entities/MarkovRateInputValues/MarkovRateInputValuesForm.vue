
<template>
 <b-container>
<b-form @submit.stop.prevent="Save">
  <div>
    <h1> Markov Rate Input Values </h1>
</div>   
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

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Age *" label-for="AgeID">    
       <b-form-input autocomplete="off" id="AgeID" type="number" v-model="$v.record.AgeID.$model" :state="$v.record.AgeID.$dirty ? !$v.record.AgeID.$error : null" aria-describedby="AgeIDError" placeholder="Age"></b-form-input>
      <b-form-invalid-feedback id="AgeIDError" v-if="!$v.record.AgeID.required">Field is required</b-form-invalid-feedback>  
    </b-form-group> 

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Industry Id*" label-for="IndustryID">    
       <b-form-input autocomplete="off" id="IndustryID" type="number" v-model="$v.record.IndustryID.$model" :state="$v.record.IndustryID.$dirty ? !$v.record.IndustryID.$error : null" aria-describedby="IndustryIDError" placeholder="Industry Id"></b-form-input>
      <b-form-invalid-feedback id="IndustryIDError" v-if="!$v.record.IndustryID.required">Field is required</b-form-invalid-feedback>  
    </b-form-group> 

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Education Level Id *" label-for="EducationLevelID">    
       <b-form-input autocomplete="off" id="EducationLevelID" type="number" v-model="$v.record.EducationLevelID.$model" :state="$v.record.EducationLevelID.$dirty ? !$v.record.EducationLevelID.$error : null" aria-describedby="EducationLevelIDError" placeholder="Education Level Id"></b-form-input>
      <b-form-invalid-feedback id="EducationLevelIDError" v-if="!$v.record.EducationLevelID.required">Field is required</b-form-invalid-feedback>  
    </b-form-group> 

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Smoker Status ID *" label-for="SmokerStatusID">    
       <b-form-input autocomplete="off" id="SmokerStatusID" type="number" v-model="$v.record.SmokerStatusID.$model" :state="$v.record.SmokerStatusID.$dirty ? !$v.record.SmokerStatusID.$error : null" aria-describedby="SmokerStatusIDError" placeholder="Smoker Status Id"></b-form-input>
      <b-form-invalid-feedback id="SmokerStatusIDError" v-if="!$v.record.SmokerStatusID.required">Field is required</b-form-invalid-feedback>  
    </b-form-group> 

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Gender *" label-for="GenderID">    
       <b-form-input autocomplete="off" id="GenderID" type="number" v-model="$v.record.GenderID.$model" :state="$v.record.GenderID.$dirty ? !$v.record.GenderID.$error : null" aria-describedby="GenderIDError" placeholder="Gender"></b-form-input>
      <b-form-invalid-feedback id="GenderIDError" v-if="!$v.record.GenderID.required">Field is required</b-form-invalid-feedback>  
    </b-form-group> 
   <div>
      <b-button type="submit" variant="primary" :disabled="$v.record.$invalid">Save</b-button>
      <div class="divider" />
      <button type="reset" class="btn btn-danger btn-md center-block" style="width: 100px; padding:5px" v-on:click="Reset">Reset</button>
    </div>
    <b-container style="padding-top:15px" >    
        <FileReader id="FileReader"  @load="text = $event" />     
        <b-button @click="BulkUpload" class="mr-2">Submit</b-button>    
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
  import { MarkovRateInputValuesService, ConfigService } from "@/services";
  import { MarkovRateInputValues, FormMode } from "@/models";
  import FileReader from "@/components/common/FileReader";

   @Component({
     components: {
      FileReader
    },  
    validations: {
      record: {        
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
        },
        AgeID: {
          required
        },
        IndustryID: {
          required
        },
        EducationLevelID: {
          required,         
        },
        SmokerStatusID: {
          required,          
        },
        GenderID: {
          required,          
        }             
      }
    }
  })

export default class MarkovRateInputValuesForm extends Vue {

  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private MarkovRateInputValuesService: MarkovRateInputValuesService = AppContainer.get<MarkovRateInputValuesService>(TYPES.Services.MarkovRateInputValuesService);  
  public  record: MarkovRateInputValues = new MarkovRateInputValues();
  private file: any = '';
  private text : any = '';
  private parse_header: any = [];
  private parse_csv!: any;
  private sortOrders!: any;
  private sortKey: any = '';
  
  public Save(): any {
    this.$v.$reset();
    this.$v.$touch();
    FormHelper.HandleSave(this.MarkovRateInputValuesService.Create(this.record), this);
    this.$v.$reset();
  }

  public Reset(): any {
    this.$v.$reset();     
  }

  public BulkUpload(event: any) {    
   this.parse_csv = this.csvJSON(this.text)
   let lstMarkovRateInputValues  = this.parse_csv.map((entity: any) => new MarkovRateInputValues(entity))
   FormHelper.HandleSave(this.MarkovRateInputValuesService.BulkInsert(lstMarkovRateInputValues), this);   
  }

  public csvJSON(csv: any){    
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