module.exports = function (app, data) {
    const passport = require('passport');

    passport.serializeUser((user, done) => {
        if (user) {
            done(null, user.id);
        }
    });

    passport.deserializeUser((userId, done) => {
        data
            .findUserById(userId)
            .then(user => done(null, user || false))
            .catch(error => done(error, false));
    });

    require('./local-strategy')(passport, data);

    app.use(passport.initialize());
    app.use(passport.session());
};