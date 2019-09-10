import { injectable } from 'inversify';
import { ClientConfig } from '@/models/config/ClientConfig';
import { HttpServiceBase } from '@/bases/services/HttpServiceBase';
import { AxiosPromise } from 'axios';

// Later - get configservice to ask inversify for an http service
@injectable()
export class ConfigService extends HttpServiceBase {
    private baseUrl: string;
    private config: ClientConfig;

    constructor() {
        super();
        this.baseUrl = "api/ClientSettings";
        this.config = new ClientConfig();
    }

    public get Config(): ClientConfig {
        return this.config;
    }

    public LoadConfig(): Promise<void> {
        return new Promise((resolve, reject) => {
                this.Get<ClientConfig>(this.baseUrl)
                .then((response) => {
                    this.config = response.data;
                    resolve();
                })
                .catch((error) => {
                    reject(error);
                });
            });
    }
}