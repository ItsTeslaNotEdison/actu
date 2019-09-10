import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { ModelPoints } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class ModelPointsService extends EntityServiceBase<ModelPoints> {
    public constructor() {
        super();
        this.baseUrl = "api/ModelPoints";
    }
   
    public BulkInsert(record: any): AxiosPromise<ModelPoints> {
        return this.Post<ModelPoints>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}