import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { MarkovRateInputValues } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class MarkovRateInputValuesService extends EntityServiceBase<MarkovRateInputValues> {
    public constructor() {
        super();
        this.baseUrl = "api/MarkovRateInputValues";
    }
   
    public BulkInsert(record: any): AxiosPromise<MarkovRateInputValues> {
        return this.Post<MarkovRateInputValues>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}