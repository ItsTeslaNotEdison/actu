import Vue from 'vue';
import Vuelidate from 'vuelidate';
import App from './App.vue';
import router from './router';
import store from './store';
import DatetimeFilter from './filters/DatetimeFilter';
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css';
import 'toastr/build/toastr.min.css';
import * as toastr from "toastr";
import { FormHelper } from "@/helpers";
import { ConfigService } from './services';
import { config } from '@vue/test-utils';
import {AppContainer} from './app/AppContainer';
import {TYPES} from './app/types';
const BootstrapDatePicker = require("vue-bootstrap-datetimepicker");

const configService: ConfigService = AppContainer.get<ConfigService>(TYPES.Services.ConfigService);
configService.LoadConfig()
  .then(() => {
  // Configure toastr
  toastr.options.timeOut = 5000;
  toastr.options.tapToDismiss = true;
  toastr.options.closeButton = true;
  toastr.options.progressBar = true;

  // Configure Vue
  Vue.use(Vuelidate);
  Vue.use(BootstrapVue);
  Vue.use(BootstrapDatePicker);
  Vue.config.productionTip = false;
  Vue.filter('datetime', DatetimeFilter);

  Vue.prototype.Helpers = {
    FormHelper
  };

  Vue.config.productionTip = false;

  new Vue({
    validations: {},
    router,
    store,
    render: (h) => h(App),
  }).$mount('#app');
});