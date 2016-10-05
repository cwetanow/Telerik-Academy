const UsernameKey = 'username';

let controllers = {
    home: () => {
        let materials;
        dataService.materials()
            .then((response) => {
                materials = response;
                return templates.get('home');
            })
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc(materials);
                $("#container").html(html);
            });
    },
    material: (params) => {
        let material;
        dataService.single(params.id)
            .then((response) => {
                material = response.result;
                return templates.get('material');
            })
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc(material);
                $("#container").html(html);

                $('#btn-comment').click(() => {
                    let commentText = $('#comment').val();

                    try {
                        validator.validateComment(commentText);

                        dataService.comment(commentText, params.id)
                            .then((response) => {
                                dataService.single(params.id)
                                    .then((response) => {
                                        material = response.result;
                                        return templates.get('material');
                                    })
                                    .then((templateHtml) => {
                                        let templateFunc = Handlebars.compile(templateHtml);
                                        let html = templateFunc(material);
                                        $("#container").html(html);
                                    });
                            });

                        $('#errors').removeClass('alert alert-danger');
                        $('#errors').html('');
                    } catch (error) {
                        $('#errors').addClass('alert alert-danger');
                        $('#errors').html(error);
                    }
                });

                $('#watch').click((ev) => {
                    let category = 'watching';

                    try {
                        dataService.assignCategory(category, params.id);
                    } catch (error) {
                        dataService.changeCategory(category, params.id);
                    }

                });

                $('#watched').click((ev) => {
                    let category = 'watched';

                    try {
                        dataService.assignCategory(category, params.id);
                    } catch (error) {
                        dataService.changeCategory(category, params.id);
                    }
                });

                $('#want-to-watch').click((ev) => {
                    let category = 'want-to-watch';

                    try {
                        dataService.assignCategory(category, params.id);
                    } catch (error) {
                        dataService.changeCategory(category, params.id);
                    }
                });
            });
    },
    profile: (params) => {
        let profile;
        dataService.profile(params.username)
            .then((response) => {
                profile = response.result;
                return templates.get('profile');
            })
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc(profile);
                $("#container").html(html);
                
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
                                password: $("#tb-password").val()
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
                                password: $("#tb-password").val()
                            };

                            try {
                                validator.validateUsername(user.username);
                                validator.validatePassword(user.password);

                                dataService.register(user)
                                    .then((respo) => {
                                        return dataService.login(user);
                                    });

                                $('#errors').removeClass('alert alert-danger');
                                $('#errors').html('');
                            } catch (error) {
                                $('#errors').addClass('alert alert-danger');
                                $('#errors').html(error);
                            }

                            ev.preventDefault();
                            return false;
                        });

                    });
            });
    },
    logout: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                dataService.logout()
                    .then(() => {
                        $(document.body).removeClass("logged-in");
                        $('.visible-when-not-logged-in').show();
                        $('.hidden-when-not-logged-in').hide();
                    });
            });
    },
    search: () => {
        templates.get('search')
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc();

                $("#container").html(html);

                $('#btn-search').click(() => {
                    let pattern = $('#pattern-box').val();

                    window.location = `#/home/${pattern}`;
                });
            });
    },
    find: (params) => {
        let materials;
        dataService.search(params.pattern)
            .then((response) => {
                materials = response;
                return templates.get('home');
            })
            .then((templateHtml) => {
                let templateFunc = Handlebars.compile(templateHtml);
                let html = templateFunc(materials);
                $("#container").html(html);
            });
    },
    myProfile: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                let username = localStorage.getItem(UsernameKey);

                window.location = `#/profiles/${username}`;
            });
    },
    create: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                templates.get('create')
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc();

                        $("#container").html(html);

                        $('#btn-create').click(() => {
                            let title = $('#title').val();
                            let description = $('#description').val();
                            let imgSrc = $('#img').val();

                            let material = {
                                title,
                                description,
                                img: imgSrc
                            }

                            try {
                                validator.validateMaterial(material);

                                dataService.create(material)
                                    .then((resp) => {
                                        window.location = '';
                                    });

                                $('#errors').removeClass('alert alert-danger');
                                $('#errors').html('');
                            } catch (error) {
                                $('#errors').addClass('alert alert-danger');
                                $('#errors').html(error);
                            }

                            ev.preventDefault();
                            return false;
                        });
                    });
            });
    },
    myMaterials: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                let materials;
                dataService.myMaterials()
                    .then((response) => {
                        materials = response;

                        return templates.get('myMaterials');
                    })
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc(materials);
                        $("#container").html(html);
                        
                    });
            });
    },
    wantToWatch: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                let materials;
                dataService.wantToWatch()
                    .then((response) => {
                        materials = response;

                        return templates.get('myMaterials');
                    })
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc(materials);
                        $("#container").html(html);
                    });
            });
    },
    watching: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                let materials;
                dataService.watching()
                    .then((response) => {
                        materials = response;

                        return templates.get('myMaterials');
                    })
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc(materials);
                        $("#container").html(html);
                    });
            });
    },
    watched: () => {
        dataService.isLoggedIn()
            .then((isLoggedIn) => {
                if (!isLoggedIn) {
                    window.location = '';
                }

                let materials;
                dataService.watched()
                    .then((response) => {
                        materials = response;

                        return templates.get('myMaterials');
                    })
                    .then((templateHtml) => {
                        let templateFunc = Handlebars.compile(templateHtml);
                        let html = templateFunc(materials);
                        $("#container").html(html);
                    });
            });
    }
};