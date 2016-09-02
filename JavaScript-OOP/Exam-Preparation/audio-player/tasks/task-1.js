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

        get id() {
            return this._id;
        }

        set id(value) {
            this._id = value;
        }

        get title() {
            return this._title;
        }

        set title(value) {
            if (!validator.validateString(value)) {
                throw new Error();
            }

            this._title = value;
        }

        get author() {
            return this._author;
        }

        set author(value) {
            if (!validator.validateString(value)) {
                throw new Error();
            }

            this._author = value;
        }

        play() {
            let result = `${this.id}. ${this.title} - ${this.author}`;
            return result;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }

        get length() {
            return this._length;
        }

        set length(value) {
            if (!validator.validateLength(value)) {
                throw new Error();
            }

            this._length = value;
        }

        play() {
            let result = super.play() + ` - ${this.length}`;
            return result;
        }
    }

    class Video extends Playable {
        constructor(title, author, rating) {
            super(title, author);
            this.imdbRating = rating;
        }

        get imdbRating() {
            return this._rating;
        }

        set imdbRating(value) {
            if (!validator.validateImdbRating(value)) {
                throw new Error();
            }

            this._rating = value;
        }

        play() {
            let result = super.play() + ` - ${this.imdbRating}`;
            return result;
        }
    }

    class PlayList {
        constructor(name) {
            this.id = idGenerator.getNext();
            this.name = name;
            this._playables = [];
        }

        get name() {
            return this._name;
        }

        set name(value) {
            if (!validator.validateString(value)) {
                throw new Error();
            }

            this._name = value;
        }

        addPlayable(playable) {
            this._playables.push(playable);
            return this;
        }

        getPlayableById(id) {
            for (var index = 0; index < this._playables.length; index += 1) {
                if (this._playables[index].id === id) {
                    return this._playables[index];
                }
            }

            return null;
        }
    }

    class Player {
        constructor(name) {
            this.id = idGenerator.getNext();
            this.name = name;
        }
    }

    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new PlayList(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

module.exports = solve;