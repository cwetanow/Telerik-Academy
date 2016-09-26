/* globals requester */

let dataService = {
    cookies: () => {
        return requester.get('/api/cookies');
    },
    login: (user) => {
        return requester.put('/api/auth', user)
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
    }
};