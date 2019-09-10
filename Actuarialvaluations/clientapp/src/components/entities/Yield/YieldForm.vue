<template> 
 <b-container>
<b-form @submit.stop.prevent="Save">
  <div>
    <h1>Yield Curve Form </h1>
</div>       
     <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Date *" label-for="Date">
      <DatePickerComponent id="Date" ref="Date" :class="this.Helpers.FormHelper.ControlClassesCheckIsNull(record.Date)" :value="record.Date" @dateChanged="record.Date = $event" :config="dateOptions" placeholder="Valid From" autocomplete="off" aria-describedby="Date" />
      <b-form-invalid-feedback id="Date" v-if="!$v.record.Date.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Period" label-for="Period">
      <b-form-input autocomplete="off" id="Period" type="text" v-model="$v.record.Period.$model" :state="$v.record.Period.$dirty ? !$v.record.Period.$error : null" aria-describedby="PeriodError" placeholder="Model Id"></b-form-input>
      <b-form-invalid-feedback id="PeriodError"  v-if="!$v.record.Period.required">Field is required</b-form-invalid-feedback>   
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Model Id" label-for="ForwardRate">
      <b-form-input autocomplete="off" id="ForwardRate" type="text" v-model="$v.record.ForwardRate.$model" :state="$v.record.ForwardRate.$dirty ? !$v.record.ForwardRate.$error : null" aria-describedby="ForwardRateError" placeholder="Model Id"></b-form-input>
      <b-form-invalid-feedback id="ForwardRateError"  v-if="!$v.record.ForwardRate.required">Field is required</b-form-invalid-feedback>   
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Model Id" label-for="Inflation">
      <b-form-input autocomplete="off" id="Inflation" type="text" v-model="$v.record.Inflation.$model" :state="$v.record.Inflation.$dirty ? !$v.record.Inflation.$error : null" aria-describedby="InflationError" placeholder="Model Id"></b-form-input>
      <b-form-invalid-feedback id="InflationError"  v-if="!$v.record.Inflation.required">Field is required</b-form-invalid-feedback>   
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
  import { YieldService, ConfigService } from "@/services";
  import { Yield, FormMode } from "@/models";
  import FileReader from "@/components/common/FileReader";
  import DatePickerComponent from "@/components/common/DatePickerComponent.vue";

   @Component({
     components: {
      FileReader,
      DatePickerComponent
    },
    validations: {
      record: {
        Date: {
          required
        },
         Period: {
          required,         
        },
        ForwardRate: {
          required,          
        },
        Inflation: {
          required,          
        }       
      }
    }
  })

export default class YieldForm extends Vue {
  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private YieldService: YieldService = AppContainer.get<YieldService>(TYPES.Services.YieldService);  
  public  record: Yield = new Yield();
  private dateOptions: any = { format: this.configService.Config.DateFormat };
  private file: any = '';
  private text : any = '';
  private parse_csv!: any;

  
  public Save(): any {
    debugger;
    this.$v.$reset();
    this.$v.$touch();
    FormHelper.HandleSave(this.YieldService.Create(this.record), this);
    this.$v.$reset();
  }

  public Reset(): any {
    this.$v.$reset();     
  }

  public BulkUpload(event: any) {    
   this.parse_csv = this.csvJSON(this.text)
   let lstYield  = this.parse_csv.map((entity: any) => new Yield(entity))
   FormHelper.HandleSave(this.YieldService.BulkInsert(lstYield), this);   
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