import { inject, injectable } from 'inversify';
import axios, { AxiosRequestConfig, AxiosPromise } from 'axios';
import { HttpServiceBase } from "./HttpServiceBase";

@injectable()
export abstract class EntityServiceBase<T> extends HttpServiceBase {
    protected baseUrl: string = "";
    public GetRecords<T>(url: string, config?: AxiosRequestConfig): AxiosPromise<T> {        
        return this.Get<T>(`${this.baseUrl}${url}`, config);
    }
    public Create(record: T): AxiosPromise<T> {        
        return this.Post<T>(this.baseUrl, JSON.stringify(record), {
            headers: { "Content-Type": "application/json; charset=utf-8" }
          });
    }
    public Update(record: T): AxiosPromise<T> {
        return this.Patch<T>(this.baseUrl, JSON.stringify(record), {
            headers: { "Content-Type": "application/json; charset=utf-8" }
          });
    }
    public GetDropDown<T>(config?: AxiosRequestConfig): AxiosPromise<T> {       
        return this.Get<T>(`${this.baseUrl}`, config);
    }
}