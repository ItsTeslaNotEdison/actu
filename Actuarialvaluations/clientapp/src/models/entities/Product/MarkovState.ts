/**
 * The MarkovStates model class
 */
export class MarkovState {
    public Health: string = '';
    public Death: string = "";
    public Lapse: string = "";
    public TemporaryDisability: string = "";
    public PermanentDisability: string = "";
    public Retrenchment: string = "";
    public CriticalIllness: string = "";
    public PaidUp: string = "";

    constructor(data: any = null) {
        if (data) {
            Object.assign(this, data);
        }
    }
}