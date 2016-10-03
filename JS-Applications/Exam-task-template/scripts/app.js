let router = new Navigo(null, false);

router
    .on('#/login', controllers.login)
    .on('#/logout', controllers.logout)
    .on(() => {
        router.navigate("#/home");
    })
    .resolve();