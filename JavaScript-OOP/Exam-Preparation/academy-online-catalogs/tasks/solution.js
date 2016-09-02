function solve() {
    let idGenerator = {
        get: (function () {
            return (function () {
                var lastId = 0;
                return {
                    getNext: function () {
                        return lastId += 1;
                    }
                };
            } ());
        } ())
    };

    let validation = {
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
        stringIsExactlyLongValidator: function (str, len) {
            return str.length === len;
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
            return !isNaN(+str);
        }
    };

    let validator = {
        nameValidator: function (name) {
            return validation.stringLengthValidator(name,
                validation.constants.nameConstants.nameLengthMin,
                validation.constants.nameConstants.nameLengthMax);
        },
        isbnValidator: function (isbn) {
            return validation.stringIsExactlyLongValidator(isbn, validation.constants.bookConstants.isbnMinLength) &&
                validation.stringIsExactlyLongValidator(isbn, validation.constants.bookConstants.isbnMaxLength) &&
                validation.stringIsNumberValidator(isbn);
        },
        nonEmptyStringValidator: function (str) {
            return str.length !== 0;
        },
        genreValidator: function (genre) {
            return validation.stringLengthValidator(name,
                validation.constants.nameConstants.genreMinLength,
                validation.constants.nameConstants.genreMaxLength);
        },
        ratingValidator: function (num) {
            return validation.numberValidator(num,
                validation.constants.mediaConstants.ratingMin,
                validation.constants.mediaConstants.ratingMax);
        },
        durationValidator: function (num) {
            return validation.numberValidator(num,
                validation.constants.mediaConstants.durationMinLength);
        }
    };

    class Item {
        constructor(name, description) {
            this.id = idGenerator.getNext();
            this.description = description;
            this.name = name;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (!validator.nameValidator(value)) {
                throw "Name is not in the required range";
            }

            this._name = value;
        }

        get description() {
            return this._description;
        }

        set description(value) {
            if (!validator.nonEmptyStringValidator(value)) {
                throw "Description cannot be empty";
            }

            this._name = value;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        get genre() {
            return this._genre;
        }

        set genre(value) {
            if (!validator.genreValidator(value)) {
                throw 'Genre is not valid';
            }

            this._genre = value;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(value) {
            if (!validator.isbnValidator(value)) {
                throw 'ISBN is not valid';
            }

            this._isbn = value;
        }
    }

    class Media extends Item {
        constructor(name, description, duration, rating) {
            super(name, description);
            this.duration = duration;
            this.rating = rating;
        }

        get rating() {
            return this._rating;
        }

        set rating(value) {
            if (!validator.ratingValidator(value)) {
                throw 'Rating is not valid';
            }

            this._genre = value;
        }

        get duration() {
            return this._duration;
        }

        set duration(value) {
            if (!validator.durationValidator(value)) {
                throw 'Duration is not valid';
            }

            this._duration = value;
        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, description, duration, rating);
        },
        getBookCatalog: function (name) {

        },
        getMediaCatalog: function (name) {

        }
    };
}
solve();
module.exports = solve;