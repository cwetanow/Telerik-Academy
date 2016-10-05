/* globals module require */

"use strict";

const Router = require("express").Router;

const DEFAULTS = {
    MIN_USERNAME_LENGTH: 6,
    MAX_USERNAME_LENGTH: 30,
    USERNAME_CHARS: "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890_.",
    MIN_PASSWORD_LENGTH: 6,
    MAX_PASSWORD_LENGTH: 30,
    PASSWORD_CHARS: "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890"
};

function isValidUser(user) {
    return user &&
        (typeof user.username === "string" &&
            user.username.length >= DEFAULTS.MIN_USERNAME_LENGTH &&
            user.username.length <= DEFAULTS.MAX_USERNAME_LENGTH &&
            Array.from(user.username).every(ch => DEFAULTS.USERNAME_CHARS.includes(ch))
        ) &&
        (typeof user.password === "string" &&
            user.password.length >= DEFAULTS.MIN_PASSWORD_LENGTH &&
            user.password.length <= DEFAULTS.MAX_PASSWORD_LENGTH &&
            Array.from(user.password).every(ch => DEFAULTS.PASSWORD_CHARS.includes(ch))
        );
}

module.exports = function(data) {
    let router = new Router();

    router
        .get("/", (req, res) => {
            res.send({
                result: data.getAllUsers()
                    .map(u => {
                        return {
                            id: u.id,
                            username: u.username
                        };
                    })
            });
        })
        .post("/", (req, res) => {
            let user = req.body;
            let dbUser = data.getUserByUsername(user.username);
            if (dbUser) {
                return res.status(400)
					.send({
                    result: {
                        err: "User already exists"
                    }
                });
            }

            if (!isValidUser(user)) {
                return res.status(400)
                    .send({ result: { err: "Invalid user" } });
            }

            dbUser = data.createUser(user.username, user.password);

            return res.status(201)
                .send({
                    result: {
                        username: dbUser.username
                    }
                });
        })
        .put("/auth", (req, res) => {
            let user = req.body;
            let dbUser = data.getUserByUsername(user.username);
            if (!dbUser || dbUser.password !== user.password) {
                return res.send({
                    result: {
                        err: "Username or password is incorrect"
                    }
                });
            }

            if (typeof dbUser.authKey === "undefined") {
                data.generateAuthKeyForUser(dbUser);
            }

            return res.send({
                result: {
                    username: dbUser.username,
                    authKey: dbUser.authKey
                }
            });
        });

    return router;
};