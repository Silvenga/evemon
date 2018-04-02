import { OidcClientFactory } from './oidc-client-factory';
import { autoinject } from 'aurelia-framework';
import { OidcClient } from 'oidc-client';

@autoinject
export class AuthService {

    private _clientFactory: OidcClientFactory;

    public constructor(clientFactory: OidcClientFactory) {
        this._clientFactory = clientFactory;
    }
    public async createAuthorizationRequest(clientId: string) {
        let client = this._clientFactory.create(clientId);
        let request = await client.createSigninRequest();
        return request.url;
    }
}