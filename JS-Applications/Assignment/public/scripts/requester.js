let requester = {
    putJSON: (url, body, options = {}) => {
        let promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};
            $.ajax({
                url,
                headers,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(body),
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    postJSON: (url, body, options = {}) => {
        let promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};

            $.ajax({
                url,
                headers,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(body),
                success: (response) => {
                    resolve(response);
                },
                error: (er) => {
                    // ugly fix
                    requester.putJSON(url, body, options);
                }
            });
        });

        return promise;
    },
    getJSON: (url, options = {}) => {
        var headers = options.headers || {};

        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                headers,
                method: "GET",
                contentType: "application/json",
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    }
};