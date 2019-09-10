<template> 
     <b-container>     <b-card>
    <b-form @submit.stop.prevent="Save">
    <div>
        <h1> Applicable Markov States. </h1>
    </div>   
    <b-form-group  label-cols-sm="10" label-cols-md="3" label-cols-lg="3" breakpoint="md" label="Markov State *" label-for="MarkovState">
      <b-form-select id="MarkovState" aria-describedby="MarkovStateError" :options= this.markovStateOptions class="mb-3">       
      </b-form-select>
      <b-form-invalid-feedback id="MarkovStateError" >Field is required</b-form-invalid-feedback>
    </b-form-group>
    <b-form-group label-cols-sm="10" label-cols-md="3" label-cols-lg="3" breakpoint="md" label="Decrement Dependency *" label-for="Decrement Dependency">
      <b-form-select id="Death"  aria-describedby="DeathError" class="mb-3">
        <option value=1>O Before</option>
        <option value=2>0.5 UDD</option>
        <option value=3>1 After</option>   
      </b-form-select>
      <b-form-invalid-feedback id="DeathError">Field is required</b-form-invalid-feedback>
    </b-form-group>
     <div>
      <b-button @click="Add"  variant="primary" >Add</b-button>
    </div>
     <div style="padding: 10px"> 
    <b-card>
    
       <h5> List Markov States. </h5>
    <b-table
          outlined
          striped
          responsive
          hover
          async
          bordered
          :items="dataSet.Records"
          :busy="dataSet.Loading"
          :fields="fields"
          caption-top
          :current-page="dataSet.Page.CurrentPage"
          :sort-by.sync="dataSet.SortOrders.FieldName"
          :sort-direction="dataSet.SortOrders.sortDescending"
           @sort-changed="SortRecords"
        > 
          <div slot="table-busy" class="text-center text-danger my-2">
            <b-spinner class="align-middle"></b-spinner>
            <strong>Loading...</strong>
          </div>
          <template slot="ApplicableMS" slot-scope="row">
            
              <b-radio v-model="row.selected" :value="row.selected" @change="ApplicableMarkovStateChange(row.item)" ></b-radio>
              
          </template>
        </b-table>
        <b-row>
          <b-col md="12" class="my-3">
            <b-pagination
              :total-rows="dataSet.Page.TotalRecords"
              :per-page="dataSet.Page.RecordsPerPage"
              v-model="dataSet.Page.CurrentPage"
              class="my-0"
              align="center"
              @change="(page) => { dataSet.SetPage(page); }"
            />
          </b-col>
        </b-row>
       
        </b-card>
         </div>
     <div>
      <b-button @click="navigateToPost"  variant="primary" >Next</b-button>
    </div>
  </b-form></b-card>
</b-container>
  
</template>
<script lang="ts">
  import moment from "moment";
  import * as toastr from "toastr";
  import { required, between, minValue } from "vuelidate/lib/validators";
  import { Component, Prop, Vue, Watch } from "vue-property-decorator";
  import { AppContainer, TYPES } from "@/app/index";
  import { IEntityList } from "@/interfaces";
  import { FormHelper } from "@/helpers";
  import { MarkovStateDropdown, Dropdown, DataSet, FormMode } from "@/models";
  import {  ConfigService, ProductMarkovStateService,  DropDownService } from "@/services";
  
   @Component({
     components: {      
    },  
  })

export default class MarkovStates extends Vue {
  private configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
  private dateOptions: any = { format: this.configService.Config.DateFormat };
  private dropDownService: DropDownService = AppContainer.get<DropDownService>(TYPES.Services.DropDownService);
  private productMarkovStateService: ProductMarkovStateService = AppContainer.get<ProductMarkovStateService>(TYPES.Services.ProductMarkovStateService);
  private itemsDataSet: DataSet<MarkovStateDropdown> = new DataSet();
  private dataSet: DataSet<MarkovStateDropdown> = new DataSet();

private markovStateOptions: Dropdown[] = [];
private fields: any = {
    StateId: {
      label: "Markov ID",
      sortable: false,
      thClass: "text-lg-center",
      tdClass: "text-lg-center"      
    },
    StateName: { label: "Markov State", sortable: true},
    StateCode: { label: "Decrement Dependency", sortable: true },
    ApplicableMS: { label: "Applicable Markov State", tdClass: "text-lg-center" },

  };

  public created(): void{
    this.itemsDataSet.Configure((config) => {
      this.dropDownService
        .GetRecords<IEntityList<MarkovStateDropdown>>(`/GetMarkovStates`)
        .then((response) => {             
          config.DataLoadedCallback(
            response.data.Entities.map((entity) => new MarkovStateDropdown(entity)),
            response.data.Total
          );
          response.data.Entities.forEach((entity) =>{
            this.markovStateOptions.push({value: entity.StateId, text:entity.StateName});
          });         
        }).catch((error) => {          
          config.DataLoadFailedCallback();
          toastr.error(error.response.data);
        });
    });  

    this.dataSet.SortOrders.push({FieldName: "StateName", SortDescending: true});
    // debugger;
    this.dataSet.Configure((config) => {
      this.productMarkovStateService
        .GetRecords<IEntityList<MarkovStateDropdown>>(`?${this.dataSet.ToODataQuery()}`)
        .then((response) => {          
          config.DataLoadedCallback(
            response.data.Entities.map((entity) => new MarkovStateDropdown(entity)),
            response.data.Total
          );               
        }).catch((error) => {          
          config.DataLoadFailedCallback();
          toastr.error(error.response.data);
        });
    });  

    this.dataSet.Load();
    this.itemsDataSet.Load();
    console.log(this.dataSet.Records); 
  }

  private SortRecords(ctx: any) {
    this.dataSet.SortOrders = [{FieldName: ctx.sortBy, SortDescending: ctx.sortDesc}];
    this.dataSet.Load();
  }

  public navigateToPost(): any {
   this.$router.push({name: "Product"})
  }

  public Add(): any {
   alert("Added Successfully");
  }

  public ApplicableMarkovStateChange(record: any) {
   // alert("Changed Applicable Markov State Change Successfully");
   // debugger
   this.dataSet.Records[record.StateId].Selected = record.selected == true ? false: true;
   // alert(this.dataSet.Records[record.StateId].Selected)
  }
}
</script>