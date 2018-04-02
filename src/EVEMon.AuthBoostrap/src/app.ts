import './broadcast-channel-polyfil.js';
import './styles/main.scss';
import 'bootstrap';

import fontawesome from '@fortawesome/fontawesome';
import regular from '@fortawesome/fontawesome-free-regular';
import solid from '@fortawesome/fontawesome-free-solid';
import { PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

fontawesome.library.add(solid)
fontawesome.library.add(regular)

export class App {
    public router: Router;

    public configureRouter(config: RouterConfiguration, router: Router): void {
        this.router = router;
        config.title = 'EveMon Auth Bootstrapper';
        config.map([
            { route: [''], name: 'index', moduleId: PLATFORM.moduleName("./pages/index/index") },
            { route: ['create-application'], name: 'create-application', moduleId: PLATFORM.moduleName("./pages/create-application/create-application") },
            { route: ['create-request'], name: 'create-request', moduleId: PLATFORM.moduleName("./pages/create-request/create-request") },
            { route: ['callback'], name: 'callback', moduleId: PLATFORM.moduleName("./pages/callback/callback") },
        ]);
    }
}