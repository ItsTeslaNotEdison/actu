
<template> 
 <b-container>
<b-form @submit.stop.prevent="Save">
  <div>
    <h1>Model Points Form </h1>
</div>       
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Cont Option Premium Waiver Option *" label-for="PremiumWaiverOption">
      <b-form-select id="PremiumWaiverOption" v-model="$v.record.CONT_OPTION_PREMIUM_WAIVER_OPTION.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Prem Waver Ind *" label-for="PremiumWaiverInd">
      <b-form-select id="PremiumWaiverInd" v-model="$v.record.PREM_WAVER_IND.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Comm Type *" label-for="CommType">
      <b-form-select id="CommType" v-model="$v.record.COMM_TYPE.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Cash Back Ind *" label-for="CashBackInd">
      <b-form-select id="CashBackInd" v-model="$v.record.CASH_BACK_IND.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Grocery Benefit Repatriation Benefit *" label-for="GroceryBenefitRepatriationBenefit">
      <b-form-select id="GroceryBenefitRepatriationBenefit" v-model="$v.record.Grocery_Benefit_REPATRIATION_Benefit.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Tomb Stone Benefit *" label-for="TombStoneBenefit">
      <b-form-select id="TombStoneBenefit" v-model="$v.record.TOMBSTONE_Benefit.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Cow Benefit *" label-for="CowBenefit">
      <b-form-select id="CowBenefit" v-model="$v.record.COW_BENEFIT_Benefit.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
    </b-form-group>

    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Educator Option *" label-for="EducatorOption">
      <b-form-select id="EducatorOption" v-model="$v.record.EDUCATOR_OPTION.$model" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
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
  import { ModelPointsService, ConfigService } from "@/services";
  import { ModelPoints, FormMode } from "@/models";
  import FileReader from "@/components/common/FileReader";

   @Component({
     components: {
      FileReader
    },
    validations: {
      record: {        
        CONT_OPTION_PREMIUM_WAIVER_OPTION: {
          required
        },
        PREM_WAVER_IND: {
          required,         
        },
        COMM_TYPE: {
          required,          
        },
        CASH_BACK_IND: {
          required,          
        },
        Grocery_Benefit_REPATRIATION_Benefit: {
          required
        },
        TOMBSTONE_Benefit: {
          required,          
        },
        COW_BENEFIT_Benefit: {
          required,          
        },
        EDUCATOR_OPTION: {
          required
        }                 
      }
    }
  })

export default class ModelPointsForm extends Vue {
private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private ModelPointsService: ModelPointsService = AppContainer.get<ModelPointsService>(TYPES.Services.ModelPointsService);  
  public  record: ModelPoints = new ModelPoints();
  private file: any = '';
  private text : any = '';
  private parse_csv!: any;

  
  public Save(): any {
    debugger;
    this.$v.$reset();
    this.$v.$touch();
    FormHelper.HandleSave(this.ModelPointsService.Create(this.record), this);
    this.$v.$reset();
  }

  public Reset(): any {
    this.$v.$reset();     
  }

  public BulkUpload(event: any) {    
   this.parse_csv = this.csvJSON(this.text)
   let lstModelPoints  = this.parse_csv.map((entity: any) => new ModelPoints(entity))
   FormHelper.HandleSave(this.ModelPointsService.BulkInsert(lstModelPoints), this);   
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