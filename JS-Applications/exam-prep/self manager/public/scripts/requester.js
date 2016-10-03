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
                }
            });
        });
        return promise;
    },
    getJSON: (url, body) => {
        body = body || undefined;

        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: "GET",
                data: JSON.stringify(body),
                contentType: "application/json",
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    }
};