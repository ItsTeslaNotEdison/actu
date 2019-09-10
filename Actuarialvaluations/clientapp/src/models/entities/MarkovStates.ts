/**
 * The MarkovStates model class
 */
export class MarkovStates {
    public Applicable_Model_ID: string = '';
    public From_State_ID: string = "";
    public To_State_ID: string = "";
    public PeriodMonthlyIncrements: string = "";
    public IndependantValue: string = "";
    
    constructor(data: any = null) {
      
        if (data) {
          // Load from a POJO
          this.Applicable_Model_ID = data[0];
          this.From_State_ID = data[1];
          this.To_State_ID = data[2];
          this.PeriodMonthlyIncrements = data[3];
          this.IndependantValue = data[4];
          
        }
    }
}