/* globals $ */

let requester = {
    get: (url, options) => {
        options = options || {};
        let promise = new Promise((resolve, reject) =>
            $.ajax({
                url,
                method: 'GET',
                contentType: 'application/json',
                headers: options.headers,
                data: JSON.stringify(options.data),
                success(response) {
                    resolve(response);
                }
            }));

        return promise;
    },
    put: (url, body) => {
        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(body),
                success(response) {
                    resolve(response);
                }
            });
        });

        return promise;
    },
    post: (url, body) => {
        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(body),
                success(response) {
                    resolve(response);
                }
            });
        });

        return promise;
    }
};