<template> 
 <b-container>     
    <b-form @submit.stop.prevent="Save">
    <div>
        <h1>Create Product </h1>
    </div>
     <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Product Name *" label-for="ModelID">
      <b-form-input autocomplete="off" id="ProductName" type="text" v-model="$v.record.ProductName.$model" :state="$v.record.ProductName.$dirty ? !$v.record.ProductName.$error : null" aria-describedby="ProductNameError" placeholder="Product Name"></b-form-input>
      <b-form-invalid-feedback id="ProductNameError"  v-if="!$v.record.ProductName.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Product Code *" label-for="ProductCode">
      <b-form-select id="ProductCode" v-model="$v.record.ProductCode.$model"  :state="$v.record.ProductCode.$dirty ? !$v.record.ProductCode.$error : null" aria-describedby="ProductCodeError" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
      <b-form-invalid-feedback id="ProductCodeError"  v-if="!$v.record.ProductCode.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Product Family *" label-for="ProductFamily">
      <b-form-select id="ProductFamily" v-model="$v.record.ProductFamily.$model"  :state="$v.record.ProductFamily.$dirty ? !$v.record.ProductFamily.$error : null" aria-describedby="ProductFamilyError" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
      <b-form-invalid-feedback id="ProductFamilyError"  v-if="!$v.record.ProductFamily.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Parameter Code*" label-for="ParameterCode">
      <b-form-select id="ParameterCode" v-model="$v.record.ParameterCode.$model"   :state="$v.record.ParameterCode.$dirty ? !$v.record.ParameterCode.$error : null" aria-describedby="ParameterCodeError" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
      <b-form-invalid-feedback id="ParameterCodeError"  v-if="!$v.record.ParameterCode.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Assumption Code *" label-for="AssumptionCode">
      <b-form-select id="AssumptionCode" v-model="$v.record.AssumptionCode.$model"   :state="$v.record.AssumptionCode.$dirty ? !$v.record.AssumptionCode.$error : null" aria-describedby="AssumptionCodeError" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
      <b-form-invalid-feedback id="AssumptionCodeError"  v-if="!$v.record.AssumptionCode.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group group horizontal :label-cols="3" breakpoint="md" label="Model Point Code *" label-for="ModelPointCode">
      <b-form-select id="ModelPointCode" v-model="$v.record.ModelPointCode.$model"  :state="$v.record.ModelPointCode.$dirty ? !$v.record.ModelPointCode.$error : null" aria-describedby="ModelPointCodeError" class="mb-3">
        <option value=true>True</option>
        <option value=false>False</option>        
      </b-form-select>
      <b-form-invalid-feedback id="ModelPointCodeError"  v-if="!$v.record.ModelPointCode.required">Field is required</b-form-invalid-feedback>
    </b-form-group>
     <div>
      <b-button type="submit" variant="primary" :disabled="$v.record.$invalid">Save</b-button>
      <div class="divider" />
      <button type="reset" class="btn btn-danger btn-md center-block" style="width: 100px; padding:5px" >Reset</button>      
    </div>
  </b-form>
</b-container>
</template>
<script lang="ts">
  import moment from "moment";
  import * as toastr from "toastr";
  import { required, between, minValue } from "vuelidate/lib/validators";
  import { Component, Prop, Vue, Watch } from "vue-property-decorator";
  import { IEntityList } from "@/interfaces";
  import { AppContainer, TYPES } from "@/app/index";
  
  import { ProductService, ConfigService } from "@/services";
  import { Product, DataSet, FormMode } from "@/models";

   @Component({
     components: {      
    },
    
    validations: {
      record: {        
        ProductName: {
          required
        },
        ProductCode: {
         required,         
        },
        ProductFamily: {
          required,          
        },
        ParameterCode: {
          required,          
        },
        AssumptionCode: {
          required
        },
        ModelPointCode: {
            required
        }                
      }
    }
  })

export default class CreateProduct extends Vue {
  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private ProductService: ProductService = AppContainer.get<ProductService>(TYPES.Services.ProductService);

  private dateOptions: any = { format: this.configService.Config.DateFormat };
  public  record: Product = new Product();
  public  dropDown: any = [];
  private dataSet: DataSet<Product> = new DataSet();

  public created(): void {
    console.log("Loading Notification Templates");
    this.dataSet.SortOrders.push({FieldName: "NotificationType", SortDescending: true});

    this.dataSet.Configure((config) => {
      this.ProductService
        .GetDropDown<IEntityList<Product>>()
        .then((response) => {
        //   config.DataLoadedCallback(
        //     response.data.Entities.map((entity) => new Product(entity)),
        //     response.data.Total
        //   );
        this.dropDown = response.data;
          console.log(this.dropDown);
        }).catch((error) => {          
          config.DataLoadFailedCallback();
          toastr.error(error);
        });
    });

    this.dataSet.Load();
  }
  public Save(): any {
   alert("Created Product Successfully.");
    this.$router.push({name: "MarkovState"})
  }

}
</script>