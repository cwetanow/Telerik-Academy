/* globals module require Promise */
"use strict";

const request = require("request");

module.exports = {
    get(url) {
        let promise = new Promise((resolve, reject) => {
            request(url, (err, response, body) => {
                if (err) {
                    return reject(err);
                }

                resolve({ response, body });
            });
        });
        return promise;
    }
};