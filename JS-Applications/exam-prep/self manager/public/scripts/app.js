let router = new Navigo(null, false);

router
    .on('#/events', controllers.events)
    .on('#/home', controllers.home)
    .on('#/login', controllers.login)
    .on('#/logout', controllers.logout)
    .on(() => {
        router.navigate("#/home");
    })
    .resolve();