import { PLATFORM, Aurelia } from 'aurelia-framework';

export async function configure(aurelia: Aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging();

    await aurelia.start();
    await aurelia.setRoot(PLATFORM.moduleName('app'));
}