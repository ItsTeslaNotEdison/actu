import { inject, injectable } from 'inversify';
import { EntityServiceBase } from '@/bases/services/EntityServiceBase';
import { MarkovStateDropdown } from '@/models';
import { AxiosPromise } from 'axios';

@injectable()
export class DropDownService extends EntityServiceBase<MarkovStateDropdown> {
    public constructor() {
        super();
        this.baseUrl = "api/DropDown";
    }   
}