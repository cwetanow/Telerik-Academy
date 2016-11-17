'use strict';

const SimpleMovie = require('./simple-movie-model');

module.exports = {
    getSimpleMovie(title, url) {
        return new SimpleMovie({
            title,
            url
        });
    },
    insertManySimpleMovies(movies) {
        SimpleMovie.insertMany(movies);
    }
}