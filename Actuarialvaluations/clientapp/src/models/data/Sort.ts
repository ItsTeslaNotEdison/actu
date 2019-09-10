/**
 * The Sort model class
 */
export class Sort {
    public FieldName: string;
    public SortDescending: boolean;

    /**
     * Create a new Sort
     * @param fieldName The field name
     * @param sortDescending The sort direction
     */
    constructor(fieldName: string, sortDescending: boolean) {
        this.FieldName = fieldName;
        this.SortDescending = sortDescending;
    }
}