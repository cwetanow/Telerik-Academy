module.exports = function (models) {
    let {
        User
    } = models;

    return {
        findUserById(id) {
            return new Promise((resolve, reject) => {
                User.findOne({
                    _id: id
                }, (err, user) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(user);
                });
            });
        },
        findByUsername(username) {
            return new Promise((resolve, reject) => {
                User.findOne({
                    username: username
                }, (err, user) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(user);
                });
            });
        }
    };
};