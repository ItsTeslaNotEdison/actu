import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { Product } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class ProductService extends EntityServiceBase<Product> {
    public constructor() {
        super();
        this.baseUrl = "api/Product";
    }   
}