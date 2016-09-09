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

    let idGenerator = generator.get();

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
            return typeof (str) === 'string' &&
                str.length >= min &&
                str.length <= max;
        },
        stringIsExactlyLongValidator: function (str, len) {
            return str.length === len;
        },
        numberValidator: function (num, min, max) {
            let result;
            if (max) {
                result = num <= max && num >= min;
            } else {
                result = num > min;
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
            let isString = typeof (isbn) === 'string';
            let hasCorrectLength = isbn.length === 10 || isbn.length === 13;
            isbn.split('').forEach(function (digit) {
                if (isNaN(+digit)) {
                    return false;
                }
            });

            return isString && hasCorrectLength;
        },
        nonEmptyStringValidator: function (str) {
            return str.length !== 0;
        },
        genreValidator: function (genre) {
            return typeof (genre) === 'string' &&
                genre.length >= validation.constants.bookConstants.genreMinLength &&
                genre.length <= validation.constants.bookConstants.genreMaxLength;
        },
        ratingValidator: function (num) {
            return typeof num === 'number' &&
                num <= validation.constants.mediaConstants.ratingMax &
                num >= validation.constants.mediaConstants.ratingMin;
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
                throw new Error();
            }

            this._name = value;
        }

        get description() {
            return this._description;
        }

        set description(value) {
            if (!validator.nonEmptyStringValidator(value)) {
                throw new Error();
            }

            this._description = value;
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
                throw new Error();
            }

            this._genre = value;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(value) {
            if (!validator.isbnValidator(value)) {
                throw new Error();
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
                throw new Error();
            }

            this._rating = value;
        }

        get duration() {
            return this._duration;
        }

        set duration(value) {
            if (!validator.durationValidator(value)) {
                throw new Error();
            }

            this._duration = value;
        }
    }

    class Catalog {
        constructor(name) {
            this.id = idGenerator.getNext();
            this.name = name;
            this.items = [];
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (!validator.nameValidator(value)) {
                throw new Error();
            }

            this._name = value;
        }

        get items() {
            return this._items;
        }

        set items(value) {
            this._items = value;
        }

        add(...items) {
            let itemsToAdd = items;
            if (items[0] instanceof Array) {
                itemsToAdd = items[0];

                if (itemsToAdd.length === 0) {
                    throw new Error();
                }
            }

            if (!itemsToAdd) {
                throw new Error();
            }

            let areValid = itemsToAdd.forEach(function (element) {
                if (!(element instanceof Item)) {
                    throw new Error();
                }
            }, this);

            itemsToAdd.forEach(function (item) {
                this.items.push(item);
            }, this);

            return this;
        }

        find(options) {
            if (typeof options === 'number') {
                this._items.forEach(function (item) {
                    if (item.id === options) {
                        return item;
                    }
                });
            } else if (typeof options === 'object') {
                let result = this._items;
                if (options.id) {
                    result = [this.find(options.id)];
                }

                if (options.name) {
                    result = result[0].name === options.name ? result : [];
                }

                return result;
            } else {
                throw new Error();
            }
        }

        search(pattern) {
            if (pattern === undefined || pattern === null || pattern === '') {
                throw new Error();
            }

            let result = [];
            pattern = pattern.toLowerCase();

            this._items.forEach(function (item) {
                if (item.name.toLowerCase().indexOf(pattern) >= 0) {
                    result.push(item);
                } else if (item.description.toLowerCase().indexOf(pattern) >= 0) {
                    result.push(item);
                }
            });

            return result;
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (books.length === 0) {
                books[0].forEach(function (element) {
                    if (!(element instanceof Book)) {
                        throw new Error();
                    }
                }, this);
            } else {
                books.forEach(function (element) {
                    if (!(element instanceof Book)) {
                        throw new Error();
                    }
                }, this);
            }

            super.add(books);
        }

        find(options) {
            return super.find(options);
        }

        getGenres() {
            let genres = [];
            this._items.forEach(function (param) {
                if (genres.indexOf(param.genre < 0)) {
                    genres.push(param.genre);
                }
            });

            return genres;
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...media) {
            if (media.length === 0) {
                media[0].forEach(function (element) {
                    if (!(element instanceof Book)) {
                        throw new Error();
                    }
                }, this);
            } else {
                media.forEach(function (element) {
                    if (!(element instanceof Book)) {
                        throw new Error();
                    }
                }, this);
            }

            super.add(media);
        }

        getTop(count) {
            if (count < 1 || (typeof count !== 'number')) {
                throw new Error();
            }
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
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    };
}
solve();
module.exports = solve;