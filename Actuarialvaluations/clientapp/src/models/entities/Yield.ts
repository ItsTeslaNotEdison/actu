/**
 * The Yield model class
 */
export class Yield {
    public ID: number = 0;
    public Date: Date = new Date();
    public Period: number = 0;
    public ForwardRate: number = 0;
    public Inflation: number = 0;
    
    constructor(data: any = null) {
      
        if (data) {
          // Load from a POJO
          this.Date = data[0];
          this.Period = data[1];
          this.ForwardRate = data[2];
          this.Inflation = data[3];
        }
    }
}