import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { Models } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class ModelsService extends EntityServiceBase<Models> {
    public constructor() {
        super();
        this.baseUrl = "api/Models";
    }
   
    public BulkInsert(record: any): AxiosPromise<Models> {
        return this.Post<Models>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}