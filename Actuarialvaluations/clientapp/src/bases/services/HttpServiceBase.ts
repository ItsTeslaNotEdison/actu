import { inject, injectable } from 'inversify';
import axios, { AxiosRequestConfig, AxiosPromise } from 'axios';
import { IHttpService } from '@/interfaces/services/IHttpService';
declare var window: any;

@injectable()
export class HttpServiceBase implements IHttpService {
    public Get<T>(url: string, config?: AxiosRequestConfig): AxiosPromise<T> {
        return axios.get<T>(`${this.hostUrl}/${url}`, config);
    }

    public Patch<T>(url: string, data?: any, config?: AxiosRequestConfig): AxiosPromise<T> {
        return axios.patch<T>(`${this.hostUrl}/${url}`, data, config);
    }

    public Post<T>(url: string, data?: any, config?: AxiosRequestConfig): AxiosPromise<T> {
        return axios.post<T>(`${this.hostUrl}/${url}`, data, config);
    }

    public PUT<T>(url: string, data?: any, config?: AxiosRequestConfig): AxiosPromise<T> {
        return axios.put<T>(`${this.hostUrl}/${url}`, data, config);
    }

    private get hostUrl() {
      return this.IsDevelopmentMode ? "http://localhost:56018" : "";
    }

    private get IsDevelopmentMode(): boolean
    {
        if (window["webpackHotUpdate"] === undefined) {
            return false;
        }

        return true;
    }
}


