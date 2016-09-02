function solve() {
    let idGenerator = {
        get: function () {
            return (function () {
                var lastId = 0;
                return {
                    getNext: function () {
                        return lastId += 1;
                    }
                };
            } ());
        }
    };

    let validator = {
        constants: {
            nameConstants: {
                nameLengthMin: 2,
                nameLengthMax: 40,
            },
            bookConstants: {
                isbnMinLength: 10,
                isbnMaxLength: 13,
                genreMinLength: 2,
                genreMaxLength: 20
            },
            mediaConstants: {
                durationMinLength: 0,
                ratingMin: 1,
                ratingMax: 5
            }
        },
        stringLengthValidator: function (str, min, max) {
            return str.length <= max && str.length >= min;
        },
        numberValidator: function (num, min, max) {
            let result;
            if (max) {
                result = num <= max && num >= min;
            } else {
                result = num >= min;
            }
            return result;
        },
        stringIsNumberValidator: function (str) {
            return isNaN(+str);
        }

    };

    

    return {
        getBook: function (name, isbn, genre, description) {

        },
        getMedia: function (name, rating, duration, description) {

        },
        getBookCatalog: function (name) {
        },
        getMediaCatalog: function (name) {
        }
    };
}
solve();
module.exports = solve;