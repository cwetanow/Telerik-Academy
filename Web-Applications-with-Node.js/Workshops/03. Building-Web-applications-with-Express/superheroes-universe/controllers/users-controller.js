module.exports = function (data) {
    const passport = require('passport');

    return {
        getLogin(req, res) {
            res.render('login');
        },
        loginLocal(req, res, next) {
            const auth = passport.authenticate('local', function (error, user) {
                if (error) {
                    next(error);
                    return;
                }

                if (!user) {
                    res.json({
                        success: false,
                        message: 'Invalid name or password!'
                    });
                }

                req.login(user, error => {
                    if (error) {
                        next(error);
                        return;
                    }

                    res.redirect('/profile');
                });
            });

            auth(req, res, next);
        },
        getRegister(req, res) {
            req.render('register');
        },
        register(req, res) {
            const user = {
                username: req.body.username,
                password: req.body.password
            };

            data.createUser(user)
                .then(dbUser => {
                    res.status(201)
                        .render('login');
                })
                .catch(error => res.status(500).json(error));
        },
        getProfile(req, res) {
            if (!req.isAuthenticated()) {
                res.status(401).redirect('/unauthorized');
            } else {
                const user = req.user;
                res.status(200)
                    .render('home');
            }
        },
        getUnauthorized(req, res) {
            res.render('unauthorized');
        },
        logout(req, res) {
            req.logout();
            res.redirect('/home');
        }
    }
}