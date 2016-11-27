/* globals module require */

const SimpleMovie = require("./simple-movie-model");
const FullMovie = require("./full-movie-model");
const Actor = require("./actor-model");

module.exports = {
    getSimpleMovie(name, url) {
        return SimpleMovie.getSimpleMovieByNameAndUrl(name, url);
    },
    insertManySimpleMovies(movies) {
        SimpleMovie.insertMany(movies);
    },
    getFullMovie(coverImage, trailer, title, description, categories, releaseDate, actors) {
        let movieObject = {
            coverImage,
            trailer,
            title,
            description,
            categories,
            releaseDate,
            actors
        };

        return new FullMovie(movieObject);
    },
    insertFullMovie(movie) {
        movie.save();

        console.log(`Inserted movie ${movie.title}`);
    },
    getActor(name, image, description, movies) {
        return new Actor({
            name,
            image,
            description,
            movies
        });
    },
    insertActor(actor) {
        actor.save();

        console.log(`Inserted actor ${actor.name}`);
    }
};