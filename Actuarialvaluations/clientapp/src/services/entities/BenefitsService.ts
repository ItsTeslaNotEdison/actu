import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { Benefits } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class BenefitsService extends EntityServiceBase<Benefits> {
    public constructor() {
        super();
        this.baseUrl = "api/Benefits";
    }
   
    public BulkInsert(record: any): AxiosPromise<Benefits> {
        return this.Post<Benefits>(`${this.baseUrl}/BulkInsert`, JSON.stringify(record), {
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
          });
    }
}