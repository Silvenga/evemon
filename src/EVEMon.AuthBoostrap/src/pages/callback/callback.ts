import { autoinject } from 'aurelia-framework';
import { OidcClientFactory } from "../../services/oidc-client-factory";

@autoinject
export class CallbackPage {

    public clientId: string;
    public id: string;
    public code: string;
    public channelId: string;

    private _oidcFactory: OidcClientFactory;

    public constructor(oidcFactory: OidcClientFactory) {
        this._oidcFactory = oidcFactory;
    }

    public async activate(params: any) {
        params = params || {};

        this.clientId = params.clientId;
        this.id = params.id;
        this.code = params.code;
        this.channelId = params.channelId;

        console.log(params);

        if (this.code == null) {
            await this.redirect();
        } else {
            await this.callback();
        }
    }

    private async redirect() {
        let clientId = this._oidcFactory.create(this.clientId);
        let request = await clientId.createSigninRequest();
        window.location.assign(request.url);
    }

    private async callback() {
        var channel = new BroadcastChannel(this.channelId);
        channel.postMessage({
            id: this.id,
            authCode: this.code
        });
        window.close();
    }
}