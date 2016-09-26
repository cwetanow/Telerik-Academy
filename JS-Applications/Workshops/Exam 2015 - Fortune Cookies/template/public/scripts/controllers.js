/* globals dataService console templates */

let checkForUser = () => {
    if (dataService.isLoggedIn()) {
        $('#login').hide();
        $('#logout').show();
        $('#hourly-cookie').show();
    } else {
        $('#login').show();
        $('#logout').hide();
        $('#hourly-cookie').hide();
    }
};

let controllers = {
    home: () => {
        checkForUser();
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
        checkForUser();
        dataService.hourlyCookie()
            .then((cookiesResponse) => {
                cookies = cookiesResponse;
                return templates.get('hourly-cookie');
            })
            .then((templateHtml) => {
                let template = Handlebars.compile(templateHtml);

                let html = template(cookies);

                $('#container').html(html);
            });
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

                    dataService.login(user);

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
    },
    logout: () => {
        dataService.logout();
    },
    like: (param) => {
        dataService.like(param.id);
    },
    dislike: (param) => {
        dataService.dislike(param.id);
    }

};
