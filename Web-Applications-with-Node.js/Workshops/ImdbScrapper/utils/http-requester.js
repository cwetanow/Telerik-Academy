'use strict';

const requester = require('request');

module.exports = {
    get: (url) => {
        let promise = new Promise((resolve, reject) => {
            requester(url, (err, res, body) => {
                if (err) {
                    return reject(err);
                }

                return resolve({
                    res,
                    body
                });
            })
        });

        return promise;
    }
}