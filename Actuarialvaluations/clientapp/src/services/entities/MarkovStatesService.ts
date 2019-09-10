import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { MarkovStates } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class MarkovStatesService extends EntityServiceBase<MarkovStates> {
    public constructor() {
        super();
        this.baseUrl = "api/MarkovStates";
    }
   
    public BulkInsert(record: any): AxiosPromise<MarkovStates> {
        return this.Post<MarkovStates>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}