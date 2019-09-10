/**
 * The Markov State Dropdown model class
 */
export class MarkovStateDropdown {
    
    public StateId: number | null = null;    
    public StateName: string | null = null;    
    public StateCode: string | null = null;   
    public StartDate: Date | null = null;   
    public EndDate: Date | null = null;
    public Selected: boolean | null = false;
    
    constructor(data: any = null) {
        if (data) {
            Object.assign(this, data);
        }
    }    
}