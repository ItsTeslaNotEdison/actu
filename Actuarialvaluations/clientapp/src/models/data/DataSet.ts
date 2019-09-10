import { IDataSetConfig, DataLoadCallback, DataLoadedCallback } from '@/interfaces/';
import { Condition } from './Condition';
import { Page } from "./Page";
import { Sort } from "./Sort";
import { DataLoadFailedCallback } from '@/interfaces/data/IDataSet';

/**
 * The DataPage model class
 */
export class DataSet<T> {
    /**
     * The fields to retrieve
     */
    public Fields: string[] = [];

    /**
     * The conditions to filter by
     */
    public Conditions: Condition[] = [];

    /**
     * The paging information
     */
    public Page: Page = new Page();

    /**
     * The sort orders for fields
     */
    public SortOrders: Sort[] = [];

    /**
     * The Records
     */
    public Records: T[] = [];

    /**
     * Indicates if the dataset is loading
     */
    public Loading: boolean = false;

    public DataLoadFailedCallback: DataLoadFailedCallback = () => {
        this.Loading = false;
    }

    public DataLoadedCallback: DataLoadedCallback<T> = () => {
        return;
    }


    public Configure(dataLoadCallback: DataLoadCallback<T>, recordsPerPage: number = 10) {
        this.DataLoadCallback = dataLoadCallback;
        this.Page.RecordsPerPage = recordsPerPage;
        this.DataLoadedCallback = (records, totalRecords) => {
            this.Records = records;
            // Recalculate paging here
            this.Page.TotalRecords = totalRecords;
            this.Page.TotalPages = this.Page.TotalRecords > recordsPerPage ? Math.ceil(this.Page.TotalRecords / recordsPerPage) : this.Page.CurrentPage;
            this.Loading = false;
        };
    }

    public Load() {
        this.Loading = true;
        this.DataLoadCallback(this);
    }

    public SetPage(pageNumber: number) {
        this.Page.CurrentPage = pageNumber;
        this.Load();
    }

    public ToODataQuery() {
        return `skip=${this.Page.Skip}&take=${this.Page.RecordsPerPage}&sortBy=${this.SortOrders[0].FieldName}&sortDescending=${this.SortOrders[0].SortDescending}`;
    }

    private DataLoadCallback: DataLoadCallback<T> = () => { return; };
}

