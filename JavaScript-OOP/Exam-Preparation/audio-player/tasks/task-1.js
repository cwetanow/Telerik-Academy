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

    let utils = {
        sort: function (ob1, ob2) {
            if (ob1.strength > ob2.strength) {
                return 1;
            } else if (ob1.strength < ob2.strength) {
                return -1;
            }

            // Else go to the 2nd item
            if (ob1.name < ob2.name) {
                return -1;
            } else if (ob1.name > ob2.name) {
                return 1;
            } else {
                return 0;
            }
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

        removePlayable(options) {
            let idOfPlayable;
            if (typeof options === 'number') {
                idOfPlayable = options;
            } else {
                idOfPlayable = options.id;
            }

            for (var index = 0; index < this._playables.length; index += 1) {
                if (this._playables[index].id === idOfPlayable) {
                    this._playables.splice(index, 1);
                    return this;
                }
            }

            throw new Error();
        }

        listPlayables(page, size) {
            if (page * size > this._playables.length) {
                throw new Error();
            }

            if (page < 0 || size <= 0) {
                throw new Error();
            }

            this._playables.sort(utils.sort);

            let start = page * size;
            let end = ((page + 1) * size - 1) < this._playables.length ? ((page + 1) * size - 1) + 1 : this._playables.length;
            let result = [];

            for (var index = start; index < end; index++) {
                var element = this._playables[index];
                result.push(element);
            }

            return result;
        }
    }

    class Player {
        constructor(name) {
            this.id = idGenerator.getNext();
            this.name = name;
            this._playlists = [];
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

        addPlaylist(playlist) {
            if (playlist instanceof PlayList) {
                this._playlists.push(playlist);
                return this;
            }

            throw new Error();
        }

        getPlaylistById(id) {
            for (var index = 0; index < this._playlists.length; index += 1) {
                if (this._playlists[index].id === id) {
                    return this._playlists[index];
                }
            }

            return null;
        }

        removePlaylist(options) {
            let idOfPlayable;
            if (typeof options === 'number') {
                idOfPlayable = options;
            } else {
                idOfPlayable = options.id;
            }

            for (var index = 0; index < this._playlists.length; index += 1) {
                if (this._playlists[index].id === idOfPlayable) {
                    this._playlists.splice(index, 1);
                    return this;
                }
            }

            throw new Error();
        }

        listPlaylists(page, size) {
            if (page * size > this._playlists.length) {
                throw new Error();
            }

            if (page < 0 || size <= 0) {
                throw new Error();
            }

            this._playlists.sort(utils.sort);

            let start = page * size;
            let end = ((page + 1) * size - 1) < this._playlists.length ? ((page + 1) * size - 1) + 1 : this._playlists.length;
            let result = [];

            for (var index = start; index < end; index++) {
                var element = this._playlists[index];
                result.push(element);
            }

            return result;
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