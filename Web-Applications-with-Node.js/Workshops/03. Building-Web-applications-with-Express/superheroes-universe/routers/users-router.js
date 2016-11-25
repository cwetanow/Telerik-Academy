module.exports = (app, data) => {
    const router = require('express').Router(),
        usersController = require('../controllers/users-controller')(data),
        passport = require('passport');

    router
        .get('/login', usersController.getLogin)
        .post('/login', usersController.loginLocal)
        .get('/register', usersController.getRegister)
        .post('/register', usersController.register)
        .get('/profile', usersController.getProfile)
        .get('/unauthorized', usersController.getUnauthorized)
        .get('logout', usersController.logout);

    app.use(router);
};