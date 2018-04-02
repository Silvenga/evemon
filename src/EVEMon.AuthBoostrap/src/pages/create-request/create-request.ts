import "./create-request.scss";

import { autoinject, buildQueryString } from "aurelia-framework";
import * as uuid from "uuid/v4";

import { OidcClientFactory } from "./../../services/oidc-client-factory";
import { Router } from "aurelia-router";

import * as moment from "moment";

@autoinject
export class CreateRequestPage {

    private _oidcFactory: OidcClientFactory;
    private _router: Router;
    public clientId: string;
    public channelId = uuid();
    public characters: { id: string, authCode: string, expiresAfter: string, status: string }[] = [];

    public constructor(oidcFactory: OidcClientFactory, router: Router) {
        this._oidcFactory = oidcFactory;
        this._router = router

        let channel = new BroadcastChannel(this.channelId);
        channel.onmessage = (message: any) => this.onCharacterAdded(message.data);
    }

    public activate(params: any) {
        params = params || {};
        this.clientId = params.clientId;
    }

    public addCharacter() {

        let character = {
            id: uuid(),
            authCode: null as string,
            expiresAfter: null as string,
            status: "Pending"
        };

        this.characters.push(character);
        console.log(this.characters);

        let callbackLink = this._router.generate("callback", {
            clientId: this.clientId,
            id: character.id,
            channelId: this.channelId
        });

        window.open(callbackLink, "_blank");
    }

    public onCharacterAdded(message: { id: string, authCode: string }) {
        console.log(message);
        let character = this.characters.find(x => x.id == message.id);
        character.authCode = message.authCode;
        character.status = "Success";
        character.expiresAfter = moment().add(20, "m").format("h:mm:ss a");
    }

    public copyText(text: string): boolean {

        // https://stackoverflow.com/a/30810322/2001966
        let textArea = document.createElement("textarea");
        textArea.style.position = "fixed";
        textArea.style.top = "0";
        textArea.style.left = "0";
        textArea.style.width = "2em";
        textArea.style.height = "2em";
        textArea.style.padding = "0";
        textArea.style.border = "none";
        textArea.style.outline = "none";
        textArea.style.boxShadow = "none";
        textArea.style.background = "transparent";
        textArea.value = text;
        document.body.appendChild(textArea);
        textArea.select();

        let success = false;
        try {
            let result = document.execCommand("copy");
            success = result;
        } catch (e) {
            console.warn("Failed to copy:", e);
        }

        document.body.removeChild(textArea);
        return success;
    }
}