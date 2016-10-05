const HttpHeaderKey = 'x-auth-key';

let dataService = {
    materials() {
        return requester.getJSON('/api/materials');
    },
    single(id) {
        return requester.getJSON(`/api/materials/${id}`);
    },
    profile(username) {
        return requester.getJSON(`api/profiles/${username}`);
    },
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
    isLoggedIn() {
        return Promise.resolve()
            .then(() => {
                return !!localStorage.getItem("username");
            });
    },
    logout() {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem("username");
                localStorage.removeItem("authKey");

                window.location = '';
            });
    },
    search(pattern) {
        let url = `api/materials?filter=${pattern}`;

        return requester.getJSON(url);
    },
    create(material) {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        return requester.postJSON('api/materials', material, options);
    },
    myMaterials() {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        return requester.getJSON('api/user-materials', options);
    },
    wantToWatch() {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        return requester.getJSON('api/user-materials/want-to-watch', options);
    },
    watched() {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        return requester.getJSON('api/user-materials/watched', options);
    },
    watching() {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        return requester.getJSON('api/user-materials/watching', options);
    },
    comment(text, id) {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        let body = {
            commentText: text
        };

        return requester.putJSON(`api/materials/${id}/comments`, body, options);
    },
    assignCategory(category, id) {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        let body = {
            id,
            category
        };

        return requester.postJSON(`api/user-materials`, body, options);
    },
    changeCategory(category, id) {
        let options = {
            headers: {
                [HttpHeaderKey]: localStorage.getItem('authKey')
            }
        };

        let body = {
            id,
            category
        };

        return requester.putJSON(`api/user-materials`, body, options);
    }
};