let controllers = {
    home: () => {
        templates.get('home')
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc();

                $("#container").html(html);
            });
    },
    events: () => {
        dataService.isLoggedIn()
            .then((isLogged) => {
                if (!isLogged) {
                    window.location = '#/login';
                }

                dataService.events()
                    .then((events) => {
                        console.log(events);
                    });
            });
    },
    login: () => {
        dataService.isLoggedIn()
            .then(isLoggedIn => {
                if (isLoggedIn) {
                    $(document.body).addClass("logged-in");
                    $('.visible-when-not-logged-in').hide();
                    $('.hidden-when-not-logged-in').show();
                    window.location = "#/home";
                    return;
                }

                templates.get("login")
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc();

                        $("#container").html(html);

                        $("#btn-login").on("click", (ev) => {
                            let user = {
                                username: $("#tb-username").val(),
                                passHash: $("#tb-password").val()
                            };

                            dataService.login(user)
                                .then((respUser) => {
                                    $(document.body).addClass("logged-in");
                                    $('.visible-when-not-logged-in').hide();
                                    $('.hidden-when-not-logged-in').show();
                                    document.location = "#/home";
                                });

                            ev.preventDefault();
                            return false;
                        });

                        $("#btn-register").on("click", (ev) => {
                            let user = {
                                username: $("#tb-username").val(),
                                passHash: $("#tb-password").val()
                            };

                            dataService.register(user)
                                .then((respUser) => {
                                    return dataService.login(user);
                                })
                                .then((respUser) => {
                                    $(document.body).addClass("logged-in");
                                    $('.visible-when-not-logged-in').hide();
                                    $('.hidden-when-not-logged-in').show();
                                    document.location = "#/home";
                                });

                            ev.preventDefault();
                            return false;
                        });

                    });
            });
    },
    logout: () => {
        dataService.logout()
            .then(() => {
                $(document.body).removeClass("logged-in");
                $('.visible-when-not-logged-in').show();
                $('.hidden-when-not-logged-in').hide();
            });
    },
};