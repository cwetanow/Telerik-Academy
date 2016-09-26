/* globals dataService console templates */

let controllers = {
    home: () => {
        let cookies;
        dataService.cookies()
            .then((cookiesResponse) => {
                cookies = cookiesResponse;
                return templates.get('home');
            })
            .then((templateHtml) => {
                let template = Handlebars.compile(templateHtml);
                //TODO filter by category

                let html = template(cookies);

                $('#container').html('').append(html);
            });
    },
    myCookie: () => {
        console.log('my cookie');
    },
    login: () => {
        if (dataService.isLoggedIn()) {
            window.location = "";
        }

        return templates.get('login')
            .then((templateHtml) => {
                let template = Handlebars.compile(templateHtml);
                let html = template();

                $('#container').html(html);

                $('#btn-login').on("click", (ev) => {
                    let user = {
                        username: $('#username').val(),
                        passHash: $('#password').val()
                    };

                    dataService.login(user)
                        .then((respUser) => {
                            localStorage.setItem("username", respUser.result.username);
                            localStorage.setItem("authKey", respUser.result.authKey);
                        });

                    ev.preventDefault();
                    return false;
                });

                $('#btn-register').on("click", (ev) => {
                    let user = {
                        username: $('#username').val(),
                        passHash: $('#password').val()
                    };

                    dataService.register(user)
                        .then((response) => {
                            dataService.login(user);
                        });

                    ev.preventDefault();
                    return false;
                });
            });
    }
};
