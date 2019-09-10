/**
 * The MarkovRate Input Values model class
 */
export class MarkovRateInputValues {
    public ID: number = 0;
    public From_State_ID: string = "";
    public To_State_ID: string = "";
    public PeriodMonthlyIncrements: string = "";
    public IndependantValue: string = "";
    public AgeID: number = 0;
    public IndustryID: number = 0;
    public EducationLevelID: number = 0;
    public SmokerStatusID: number = 0;
    public GenderID: number = 0;
    
    constructor(data: any = null) {
      
        if (data) {
          // Load from a POJO
          // this.Applicable_Model_ID = data[0];
          this.From_State_ID = data[0];
          this.To_State_ID = data[1];
          this.PeriodMonthlyIncrements = data[2];
          this.IndependantValue = data[3];
          this.AgeID = data[4];
          this.IndustryID = data[5];
          this.EducationLevelID = data[6];
          this.SmokerStatusID = data[7];
          this.GenderID = data[8];
          
        }
    }
}