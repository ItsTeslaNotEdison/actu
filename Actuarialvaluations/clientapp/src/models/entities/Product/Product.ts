/**
 * The Product class
 */
export class Product {
    public ID: number = 0;
    public ProductName: string = "";
    public ProductCode: number = 0;
    public ProductFamily: number = 0;
    public ParameterCode: number = 0;
    public AssumptionCode: number = 0;
    public ModelPointCode: number = 0;
    
    
    constructor(data: any = null) {     
        if (data) {                 
          Object.assign(this, data);          
        }
    }
}