/**
 * The ModelPoints model class
 */
export class ModelPoints {
    public ID: number = 0;
    public CONT_OPTION_PREMIUM_WAIVER_OPTION: boolean = false;
    public PREM_WAVER_IND: boolean = false;
    public COMM_TYPE: boolean = false;
    public CASH_BACK_IND: boolean = false;
    public Grocery_Benefit_REPATRIATION_Benefit: boolean = false;
    public TOMBSTONE_Benefit: boolean = false;
    public COW_BENEFIT_Benefit: boolean = false;
    public EDUCATOR_OPTION: boolean = false;
    
    constructor(data: any = null) {
      debugger;
        if (data) {
          // Load from a POJO
          this.CONT_OPTION_PREMIUM_WAIVER_OPTION = data[0] === "1" ? true : false;
          this.PREM_WAVER_IND = data[1] === "1" ? true : false;
          this.COMM_TYPE = data[2] === "1" ? true : false;
          this.CASH_BACK_IND = data[3] === "1" ? true : false;
          this.Grocery_Benefit_REPATRIATION_Benefit = data[4] === "1" ? true : false;
          this.TOMBSTONE_Benefit = data[5] === "1" ? true : false;
          this.COW_BENEFIT_Benefit = data[6] === "1" ? true : false;
          this.EDUCATOR_OPTION = data[7] === "1" ? true : false;
          
        }
    }
}