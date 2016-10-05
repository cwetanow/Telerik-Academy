/* globals module require */

"use strict";

const AUTH_KEY_HEADER_NAME = "x-auth-key";

const express = require("express"),
    bodyParser = require("body-parser"),
    cors = require("cors");

function findUserMiddleware(data) {
    return function(req, res, next) {
        let authKey = req.headers[AUTH_KEY_HEADER_NAME];
        let user = data.getUserByAuthKey(authKey);

        req.user = user;

        next();
    };
}

module.exports = function(data) {
    let app = express();
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(cors());
    app.use(express.static("public"));
    app.use("/doncho", express.static("public2"));

    app.use(findUserMiddleware(data));

    return app;
};