mocha.setup('bdd');

const HTTP_HEADER_KEY = 'x-auth-key';

const expect = chai.expect;

describe('Tests', function () {
    describe('Register tests', function () {
        const user = {
            username: 'pesho',
            password: 'peshoPass'
        };

        beforeEach(() => {
            sinon.stub(requester, 'postJSON').returns(new Promise((resolve, reject) => {
                resolve(user);
            }));
        });

        afterEach(() => {
            requester.postJSON.restore();
        });

        it('expect postJSON to be called once', function (done) {
            dataService.register(user)
                .then(() => {
                    expect(requester.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect postJSON to make correct call', function (done) {
            dataService.register(user)
                .then(() => {
                    let actual = requester.postJSON
                        .firstCall
                        .args;

                    expect(actual.length).to.equal(2);
                    expect(actual[0]).to.equal('api/users');
                    expect(actual[1]).to.eql(user);
                })
                .then(done, done);
        });

        it('expect dataService.register() to post correct data', function (done) {
            dataService.register(user)
                .then(() => {
                    let actual = requester.postJSON
                        .firstCall
                        .args[1];

                    let properties = Object.keys(actual)
                        .sort();

                    expect(properties.length).to.equal(2);
                    expect(properties[0]).to.equal('password');
                    expect(properties[1]).to.equal('username');
                })
                .then(done, done);
        });
    });

    describe('Login tests', function () {
        const user = {
            username: 'pesho',
            password: 'peshoPass'
        };

        const AUTH_KEY = "123456789";

        beforeEach(function () {
            sinon.stub(requester, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve({
                        result: {
                            username: user.username,
                            authKey: AUTH_KEY
                        }
                    });
                }));
        });

        afterEach(function () {
            requester.putJSON.restore();
            localStorage.clear();
        });

        it('expect putJSON to be called once', function (done) {
            dataService.login(user)
                .then(() => {
                    expect(requester.putJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect putJSON to make correct call', function (done) {
            dataService.login(user)
                .then(() => {
                    let actual = requester.putJSON
                        .firstCall
                        .args;

                    expect(actual.length).to.equal(2);
                    expect(actual[0]).to.equal('api/users/auth');
                    expect(actual[1]).to.eql(user);
                })
                .then(done, done);
        });

        it('expect login to put username in local storage', function (done) {
            dataService.login(user)
                .then(() => {
                    expect(localStorage.getItem('username')).to.equal(user.username);
                })
                .then(done, done);
        });

        it('expect login to put auth key in local storage', function (done) {
            dataService.login(user)
                .then(() => {
                    expect(localStorage.getItem('authKey')).to.equal(AUTH_KEY);
                })
                .then(done, done);
        });
    });

    // describe('Logout tests', function () {
    //     const user = {
    //         username: 'pesho',
    //         password: 'peshoPass'
    //     };

    //     const AUTH_KEY = "123456789";

    //     beforeEach(function () {
    //         sinon.stub(requester, 'putJSON')
    //             .returns(new Promise((resolve, reject) => {
    //                 resolve({
    //                     result: {
    //                         username: user.username,
    //                         authKey: AUTH_KEY
    //                     }
    //                 });
    //             }));
    //             localStorage.clear();
    //     });

    //     afterEach(function () {
    //         requester.putJSON.restore();
    //         localStorage.clear();
    //     });

    //     it('expect local storage to not have key username', function (done) {
    //         dataService.login(user)
    //             .then(() => {
    //                 dataService.logout();
    //             })
    //             .then(() => {
    //                 expect(localStorage.getItem('username')).to.be.null;
    //             })
    //             .then(done, done);
    //     });

    //     // it('expect local storage to not have key auth key', function (done) {
    //     //     dataService.login(user)
    //     //         .then(() => {
    //     //             dataService.logout();
    //     //         })
    //     //         .then(() => {
    //     //             expect(localStorage.getItem('authKey')).to.be.null;
    //     //         })
    //     //         .then(done, done);
    //     // });
    // });

    describe('Is logged in tests', function () {
        const user = {
            username: 'pesho',
            passHash: 'peshoPass'
        };

        const AUTH_KEY = "123456789";

        beforeEach(function () {
            sinon.stub(requester, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve({
                        result: {
                            username: user.username,
                            authKey: AUTH_KEY
                        }
                    });
                }));
        });

        afterEach(function () {
            requester.putJSON.restore();
            localStorage.clear();
        });

        it('expect to return false when not logged in', function (done) {
            dataService.isLoggedIn()
                .then((res) => {
                    expect(res).to.be.false;
                })
                .then(done, done);
        });

        it('expect to return true when logged in', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.isLoggedIn();
                })
                .then((res) => {
                    expect(res).to.be.true;
                })
                .then(done, done);
        });
    });

    describe('Materials tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.materials() to make exactly one JSON call', function (done) {
            dataService.materials()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.materials() to make correct JSON call', (done) => {
            dataService.materials()
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('/api/materials');
                })
                .then(done, done);
        });

        it('expect dataService.materials() to return correct result', (done) => {
            dataService.materials()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('Singe material tests', function () {
        const id = '123';
        const result = {
            id
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.single to make exactly one JSON call', function (done) {
            dataService.single(id)
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.single to make correct JSON call', (done) => {
            dataService.single(id)
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('/api/materials/' + id);
                })
                .then(done, done);
        });

        it('expect dataService.single to return correct result', (done) => {
            dataService.single(id)
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('Profile tests', function () {
        const username = 'Pesho';
        const result = {
            username
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.profile to make exactly one JSON call', function (done) {
            dataService.profile(username)
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.profile to make correct JSON call', (done) => {
            dataService.profile(username)
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/profiles/' + username);
                })
                .then(done, done);
        });

        it('expect dataService.profile to return correct result', (done) => {
            dataService.profile(username)
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('Search tests', function () {
        const pattern = 'Pesho';
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.search to make exactly one JSON call', function (done) {
            dataService.search(pattern)
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.search to make correct JSON call', (done) => {
            dataService.search(pattern)
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/materials?filter=' + pattern);
                })
                .then(done, done);
        });

        it('expect dataService.search to return correct result', (done) => {
            dataService.search(pattern)
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('myMaterials tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.myMaterials() to make exactly one JSON call', function (done) {
            dataService.myMaterials()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.myMaterials() to make correct JSON call', (done) => {
            dataService.myMaterials()
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/user-materials');
                })
                .then(done, done);
        });

        it('expect dataService.myMaterials() to return correct result', (done) => {
            dataService.myMaterials()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('wantToWatch tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.wantToWatch() to make exactly one JSON call', function (done) {
            dataService.wantToWatch()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.wantToWatch() to make correct JSON call', (done) => {
            dataService.wantToWatch()
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/user-materials/want-to-watch');
                })
                .then(done, done);
        });

        it('expect dataService.wantToWatch() to return correct result', (done) => {
            dataService.wantToWatch()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('watched tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.watched() to make exactly one JSON call', function (done) {
            dataService.watched()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.watched() to make correct JSON call', (done) => {
            dataService.watched()
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/user-materials/watched');
                })
                .then(done, done);
        });

        it('expect dataService.watched() to return correct result', (done) => {
            dataService.watched()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('watching tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requester, 'getJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(function () {
            requester.getJSON.restore();
        });

        it('expect dataService.watching() to make exactly one JSON call', function (done) {
            dataService.watching()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.watching() to make correct JSON call', (done) => {
            dataService.watching()
                .then(res => {
                    let actual = requester.getJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/user-materials/watching');
                })
                .then(done, done);
        });

        it('expect dataService.watching() to return correct result', (done) => {
            dataService.watching()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('Comment tests', function () {
        const id = '123';
        const text = 'comment';
        const result = {};

        beforeEach(() => {
            sinon.stub(requester, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });

        afterEach(() => {
            requester.putJSON.restore();
        });

        it('expect dataService.comment() to make exactly one JSON call', function (done) {
            dataService.comment(text, id)
                .then(() => {
                    expect(requester.putJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect dataService.comment() to make correct JSON call with correct parameters', (done) => {
            dataService.comment(text, id)
                .then(res => {
                    let actual = requester.putJSON
                        .firstCall
                        .args[0];

                    let actualText = requester.putJSON
                        .firstCall
                        .args[1];

                    let expected = {
                        commentText: text
                    };

                    expect(actual).to.equal('api/materials/' + id + '/comments');
                    expect(actualText).to.eql(expected);
                })
                .then(done, done);
        });

        it('expect dataService.comment() to return correct result', (done) => {
            dataService.comment()
                .then(res => {
                    expect(res).to.equal(result);
                })
                .then(done, done);
        });
    });

    describe('Create tests', function () {
        let db = [];
        const material = {
            title: 'titleee',
            description: 'description',
            img: ''
        }
        const AUTH_KEY = '1234';
        const user = {
            username: 'Pesho',
            password: 'peshopass'
        }

        beforeEach(function () {
            sinon.stub(requester, 'postJSON', (route, material, options) => {
                return new Promise((resolve, reject) => {
                    db.push(material);
                    resolve(material);
                });
            });
            sinon.stub(requester, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve({
                        result: {
                            username: user.username,
                            authKey: AUTH_KEY
                        }
                    });
                }));
            localStorage.clear();
            db = [];
        });

        afterEach(function () {
            requester.postJSON.restore();
            requester.putJSON.restore();
            localStorage.clear();
        });

        it('expect postJSON to be called for material', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.create(material);
                })
                .then(() => {
                    expect(requester.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('expect postJSON to be called with correct route', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.create(material);
                })
                .then(() => {
                    const actual = requester.postJSON
                        .firstCall
                        .args[0];

                    expect(actual).to.equal('api/materials');
                })
                .then(done, done);
        });

        it('expect postJSON to be called with the material', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.create(material);
                })
                .then(() => {
                    const actual = requester.postJSON
                        .firstCall
                        .args[1];
                    expect(actual).to.eql(material);
                })
                .then(done, done);
        });

        it('expect postJSON to be called with authorization headers', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.create(material);
                })
                .then(() => {
                    const actual = requester.postJSON
                        .firstCall
                        .args[2];
                    expect(actual.headers[HTTP_HEADER_KEY]).to.equal(AUTH_KEY);
                })
                .then(done, done);
        });

        it('expect material to be added to DB', function (done) {
            dataService.login(user)
                .then(() => {
                    return dataService.create(material);
                })
                .then(() => {
                    expect(db).to.eql([material]);
                })
                .then(done, done);
        });
    });
});

mocha.run();