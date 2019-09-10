
<template>
<b-container>
<b-form @submit.stop.prevent="Save">
  <div>
    <h1>Benfits</h1>
</div>   
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Model Id" label-for="ModelID">
      <b-form-input autocomplete="off" id="ModelID" type="text" v-model="$v.record.ModelID.$model" :state="$v.record.ModelID.$dirty ? !$v.record.ModelID.$error : null" aria-describedby="ModelIDError" placeholder="Model Id"></b-form-input>
      <b-form-invalid-feedback id="ModelIDError"  v-if="!$v.record.ModelID.required">Field is required</b-form-invalid-feedback>   
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Associated Markov State ID*" label-for="AssociatedMarkovStateID">
      <b-form-input autocomplete="off" id="AssociatedMarkovStateID" type="text" v-model="$v.record.AssociatedMarkovStateID.$model" :state="$v.record.AssociatedMarkovStateID.$dirty ? !$v.record.AssociatedMarkovStateID.$error : null" aria-describedby="AssociatedMarkovStateIDError" placeholder="Associated Markov State Id"></b-form-input>
      <b-form-invalid-feedback id="AssociatedMarkovStateIDError" v-if="!$v.record.AssociatedMarkovStateID.required" >Field is required</b-form-invalid-feedback>             
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Benefit Type *" label-for="BenefitType"> 
       <b-form-input autocomplete="off" id="BenefitType" type="text" v-model="$v.record.BenefitType.$model" :state="$v.record.BenefitType.$dirty ? !$v.record.BenefitType.$error : null" aria-describedby="BenefitTypeError" placeholder="Benefit Type"></b-form-input>
      <b-form-invalid-feedback id="BenefitTypeError" v-if="!$v.record.BenefitType.required" >Field is required</b-form-invalid-feedback>         
    </b-form-group>   
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Add Subtract *" label-for="AddSubtract">
      <b-form-select id="AddSubtractError" v-model="$v.record.AddSubtract.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Value *" label-for="Value">    
       <b-form-input autocomplete="off" id="Value" type="number" v-model="$v.record.Value.$model" :state="$v.record.Value.$dirty ? !$v.record.Value.$error : null" aria-describedby="ValueError" placeholder="Value"></b-form-input>
      <b-form-invalid-feedback id="ValueError" v-if="!$v.record.Value.required">Field is required</b-form-invalid-feedback>  
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
  import { required, minValue } from "vuelidate/lib/validators";
  import { Component, Prop, Vue, Watch } from "vue-property-decorator";
  import { AppContainer, TYPES } from "@/app/index";
  import { FormHelper } from "@/helpers";
  import { BenefitsService, ConfigService } from "@/services";
  import { Benefits, FormMode } from "@/models";
  import FileReader from "@/components/common/FileReader";

 @Component({
     components: {
      FileReader
    },  
    validations: {
      record: {        
        ModelID: {
          required
        },
        AssociatedMarkovStateID: {
          required,         
        },
        BenefitType: {
          required,          
        },
        AddSubtract: {
          required,          
        },
        Value: {
          required
        }                  
      }
    }
  })
export default class BenefitsForm extends Vue {
  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private BenefitsService: BenefitsService = AppContainer.get<BenefitsService>(TYPES.Services.BenefitsService);  
  public  record: Benefits = new Benefits();
  private file: any = '';
  private text : any = '';
  private parse_csv!: any;

  
  public Save(): any {
    debugger;
    this.$v.$reset();
    this.$v.$touch();
    FormHelper.HandleSave(this.BenefitsService.Create(this.record), this);
    this.$v.$reset();
  }

  public Reset(): any {
    this.$v.$reset();     
  }

  public BulkUpload(event: any) {    
   this.parse_csv = this.csvJSON(this.text)
   let lstBenefits  = this.parse_csv.map((entity: any) => new Benefits(entity))
   FormHelper.HandleSave(this.BenefitsService.BulkInsert(lstBenefits), this);   
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