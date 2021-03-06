/* globals requester */

let dataService = {
    cookies: () => {
        return requester.get('/api/cookies');
    },
    login: (user) => {
        window.location = "";

        return requester.put('/api/auth', { data: user })
            .then((response) => {
                localStorage.setItem("username", response.result.username);
                localStorage.setItem("authKey", response.result.authKey);
            });

    },
    register: (user) => {
        return requester.post('/api/users', user);
    },
    isLoggedIn: () => {
        if (localStorage.length === 0) {
            return false;
        }

        return true;
    },
    hourlyCookie: () => {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem("authKey")
            }
        };
        return requester.get('api/my-cookie', options)
            .then(function (res) {
                return res.result;
            });
    },
    logout: () => {
        localStorage.removeItem("username");
        localStorage.removeItem("authKey");

        window.location = "";
    },
    like: (id) => {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem("authKey")
            },
            data: {
                type: 'like'
            }
        };

        return requester.put('api/cookies/' + id, options)
            .then((res) => {
            });
    },
    dislike: (id) => {
        var options = {
            headers: {
                'x-auth-key': localStorage.getItem("authKey")
            },
            data: {
                type: 'dislike'
            }
        };

        return requester.put('api/cookies/' + id, options)
            .then((res) => {
                console.log(res);
            });
    }
};