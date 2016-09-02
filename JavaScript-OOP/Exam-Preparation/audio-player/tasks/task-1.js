function solve() {
    let generator = {
        get: (function () {
            return (function () {
                var lastId = 0;
                return {
                    getNext: function () {
                        return lastId += 1;
                    }
                };
            } ());
        })
    };

    let constants = {
        stringsMinLength: 3,
        stringsMaxLength: 25,
        lowerImdbRating: 1,
        higherImdbRating: 5,
        lengthMinimum: 0
    };

    let validator = {
        validateString: function (str) {
            return (typeof str === 'string') &&
                str.length >= constants.stringsMinLength &&
                str.length <= constants.stringsMaxLength;
        },
        validateImdbRating: function (rating) {
            return validator.validateNumber(rating) &&
                str.length >= constants.lowerImdbRating &&
                str.length <= constants.higherImdbRating;
        },
        validateNumber: function (num) {
            return (typeof num == 'number');
        },
        validateLength: function (num) {
            return validator.validateNumber(num) &&
                num > constants.lengthMinimum;
        }
    };



    let idGenerator = generator.get();

    class Playable {
        constructor(title, author) {
            this.id = idGenerator.getNext();
            this.title = title;
            this.author = author;
        }
    }

    return {
        getPlayer: function (name) {

        },
        getPlaylist: function (name) {
        },
        getAudio: function (title, author, length) {
        },
        getVideo: function (title, author, imdbRating) {
        }
    };
}


module.exports = solve;