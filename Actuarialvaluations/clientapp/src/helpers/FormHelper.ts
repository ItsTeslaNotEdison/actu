import { AxiosPromise } from 'axios';
import { Vue } from "vue-property-decorator";
import * as toastr from "toastr";

export class FormHelper {
  public static HandleSave<T>(promise: AxiosPromise<T>, vueComponent: Vue): any {
    promise
      .then((response) => {
        toastr.success("Success", "Record saved sucessfully.");
        vueComponent.$emit("saved");
      })
      .catch((error) => {
        toastr.error("Error", error.response.data);
      });
  }

  public static ControlClassesCheckIsNull(value: any) {
    if (value === null) {
      return "form-control is-invalid";
    } else {
      return "form-control";
    }
  }

  public static ToPercentage(value: number): number {
    return parseFloat((value * 100).toFixed(2));
  }
}