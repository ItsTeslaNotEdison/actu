/**
 * The Benefits model class
 */
export class Benefits {
    public ID: number = 0;
    public ModelID: string = "";
    public AssociatedMarkovStateID: number = 0;
    public BenefitType: string = "";
    public AddSubtract: boolean = false;
    public Value: number = 0;
    
    
    constructor(data: any = null) {     
        if (data) {
          // Load from a POJO          
          this.ModelID = data[0];
          this.AssociatedMarkovStateID = data[1];
          this.BenefitType = data[2];
          this.AddSubtract = data[3] === 1 ? true : false;
          this.Value = data[4];
          
        }
    }
}