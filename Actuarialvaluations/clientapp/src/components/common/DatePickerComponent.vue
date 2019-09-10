<template>
  <div class="datetimepicker-inline" v-if="config.inline"></div>
  <input type="text" class="form-control" v-else>
</template>

<script lang="ts">
import jQuery from 'jquery';
import moment from 'moment';
import { Component, Prop, Vue, Watch } from "vue-property-decorator";
import 'bootstrap-datepicker';

const events = ['hide', 'show', 'change', 'error', 'update'];

@Component({})
export default class DatePickerComponent extends Vue {
  private name: string = 'date-picker';

  @Prop({
    default: null,
    required: true,
    validator(value: any) {
      return value === null || value instanceof Date || typeof value === 'string' || value instanceof String || value instanceof moment;
    }
  })
  private value!: any;

  @Prop({
    type: Object,
    default: () => ({})
  })
  // http://eonasdan.github.io/bootstrap-datetimepicker/Options/
  private config!: any;

  @Prop({
    type: Boolean,
    default: false
  })
  /**
   * You can set this to true when component is wrapped in input-group
   * Note: inline and wrap mode wont work together
   */
  private wrap!: any;

  @Prop({
    default: false
  })
  private useTime!: boolean;

  private dp: any = null;
  private elem: any = null;

  public mounted() {
      // Return early if date-picker is already loaded
      /* istanbul ignore if */
      if (this.dp) { return };
      // Handle wrapped input
      this.elem = jQuery((this.wrap ? this.$el.parentNode : this.$el) as any);
      // Init date-picker
      this.elem.datetimepicker(this.config);
      // Store data control
      this.dp = this.elem.data('DateTimePicker');
      // Set initial value
      this.dp.date(this.value);
      // Watch for changes
      this.elem.on('dp.change', this.onChange);
      // Register remaining events
      this.registerEvents();
  } 

  public onChange(event: any) {    
    let formattedDate = event.date ? event.date.format(this.dp.format()) : null;
    this.$emit('input', formattedDate);
    if (this.useTime) {
      this.$emit('dateChanged', event.date !== false ? event.date.toDate() : null);
    } else {
      this.$emit('dateChanged', event.date !== false ? event.date.hour(12).minute(0).second(0).toDate() : null);
    }    
  }

  public registerEvents() {
    events.forEach((name) => {
      this.elem.on(`dp.${name}`, (...args: any[]) => {
        this.$emit(`dp-${name}`, ...args);
      });
    })
  }

  public beforeDestroy() {
    if (this.dp) {
      this.dp.destroy();
      this.dp = null;
      this.elem = null;
    }
  }

  @Watch("value")
  private OnValueChanged(newValue: Date, oldValue: Date) {
    this.dp && this.dp.date(newValue || null);
  }

  @Watch("config", { deep: true })
  private OnConfigChanged(newValue: any, oldValue: any) {
    this.dp && this.dp.options(newValue);
  }
}
</script>