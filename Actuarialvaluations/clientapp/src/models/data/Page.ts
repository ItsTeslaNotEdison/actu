/**
 * The Page model class
 */
export class Page {
    /**
     * The Number of records to skip
     */
    public get Skip(): number {
        return (this.CurrentPage - 1) * this.RecordsPerPage;
    }

    /**
     * The Records Per Page
     */
    public RecordsPerPage: number = 10;

    /**
     * The Total Number of Records
     */
    public TotalRecords: number = 0;

    /**
     * The Current Page
     */
    public CurrentPage: number = 1;

    /**
     * The Total Pages
     */
    public TotalPages: number = 0;
}