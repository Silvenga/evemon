import { autoinject } from 'aurelia-framework';
import "./create-application.scss";
import { Router } from "aurelia-router";

@autoinject
export class CreateApplicationPage {

    private _router: Router;

    public clientId: string;
    public callbackUrl: string;

    public constructor(router: Router) {
        this._router = router;

        this.callbackUrl = window.location.protocol + "//" + window.location.host + window.location.pathname + "/" + this._router.generate("callback");
    }

    public activate(params: any) {
        params = params || {};
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