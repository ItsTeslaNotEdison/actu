import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { Yield } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class YieldService extends EntityServiceBase<Yield> {
    public constructor() {
        super();
        this.baseUrl = "api/Yield";
    }
   
    public BulkInsert(record: any): AxiosPromise<Yield> {
        return this.Post<Yield>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}