let dataService = {
    login(user) {
        return requester.putJSON('api/users/auth', user)
            .then(respUser => {
                localStorage.setItem("username", respUser.result.username);
                localStorage.setItem("authKey", respUser.result.authKey);
            });
    },
    register(user) {
        return requester.postJSON('api/users', user);
    },
    logout() {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem("username");
                localStorage.removeItem("authKey");
            });
    },
    isLoggedIn() {
        return Promise.resolve()
            .then(() => {
                return !!localStorage.getItem("username");
            });
    },
    events() {
        let options = {
            headers: {
                'x-auth-key': localStorage.getItem('authKey')
            }
        };

        return requester.getJSON('api/events', options);
    }
};