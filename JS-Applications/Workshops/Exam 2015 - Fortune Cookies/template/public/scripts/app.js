/* globals Navigo console*/

let router = new Navigo(null, true);

router
    .on('login', controllers.login)
    .on('logout',controllers.logout)
    .on('home', controllers.home)
    .on('my-cookie', controllers.myCookie)
    .on(() => {
        router.navigate('/home');
    })
    .resolve();
