import { Condition } from '../../models/data/Condition';
import { Page } from "../../models/data/Page";
import { Sort } from "../../models/data/Sort";

export type DataLoadCallback<T> = (dataSetConfig: IDataSetConfig<T>) => void;
export type DataLoadFailedCallback = () => void;
export type DataLoadedCallback<T> = (records: T[], totalRecords: number) => void;

export interface IDataSetConfig<T> {
    Fields: string[];
    Conditions: Condition[];
    Page: Page;
    SortOrders: Sort[];
    DataLoadedCallback: DataLoadedCallback<T>;
    DataLoadFailedCallback: DataLoadFailedCallback;
}
