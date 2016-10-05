$(document).ready(() => {
    dataService.isLoggedIn()
        .then((isLogged) => {
            if (isLogged) {
                $('.visible-when-not-logged-in').hide();
            } else {
                $('.hidden-when-not-logged-in').hide();
            }
        });
});

let router = new Navigo(null, false);

router
    .on('#/my-materials/watching', controllers.watching)
    .on('#/my-materials/watched', controllers.watched)
    .on('#/my-materials/want-to-watch', controllers.wantToWatch)
    .on('#/my-materials', controllers.myMaterials)
    .on('#/create', controllers.create)
    .on('#/my-profile', controllers.myProfile)
    .on('#/home/:pattern', controllers.find)
    .on('#/search', controllers.search)
    .on('#/profiles/:username', controllers.profile)
    .on('#/materials/:id', controllers.material)
    .on('#/home', controllers.home)
    .on('#/login', controllers.login)
    .on('#/logout', controllers.logout)
    .on(() => {
        router.navigate("#/home");
    })
    .resolve();