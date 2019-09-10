/**
 * The Condition model class
 */
export class Condition {
    /**
     * The field name
     */
    public FieldName: string;

    /**
     * The comparison operator
     */
    public Comparison: ComparisonOperator;

    /**
     * The values
     */
    public Values: any[];

    /**
     * Create a new Condition
     * @param fieldName The field name
     * @param comparison The comparison operator
     * @param value The value(s) (Can be a single value, or array of values)
     */
    constructor(fieldName: string, comparison: ComparisonOperator, value: any | any[]) {
        this.FieldName = fieldName;
        this.Comparison = comparison;

        if (Array.isArray(value)) {
            this.Values = value;
        } else {
            this.Values = [ value ];
        }
    }
}

export enum ComparisonOperator {
    None = 0,
    GreaterThan = 1,
    GreaterThanOrEqualTo = 2,
    LessThan = 3,
    LessThanOrEqualTo = 4,
    EqualTo = 5,
    NotEqualTo = 6,
    Contains = 7,
    StartsWith = 8,
    EndsWith = 9,
    RegexMatch = 10,
    In = 11,
}
