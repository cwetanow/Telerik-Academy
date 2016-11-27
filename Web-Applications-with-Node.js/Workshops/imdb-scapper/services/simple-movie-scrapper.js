/* globals console require setTimeout Promise */
'use strict';

const httpRequester = require("./../utils/http-requester");
const htmlParser = require("./../utils/html-parser");
const queuesFactory = require("./../data-structures/queue");
const modelsFactory = require("./../models");
const constants = require("./../config/constants");
const awaiter = require("./../utils/awaiter");
const urlProvider = require("./../utils/url-provider");

require("./../config/mongoose")(constants.connectionString);

let urlsQueue = queuesFactory.getQueue();

const imdbHostString = "http://www.imdb.com";

function getMoviesFromUrl(url, selector) {
    //console.log(`Working with ${url}`);
    httpRequester.get(url)
        .then((result) => {
            const html = result.body;
            return htmlParser.parseSimpleMovie(selector, html);
        })
        .then(movies => {
            movies.forEach(function (movie) {
                httpRequester.get(imdbHostString + movie.url)
                    .then((result) => {
                        return htmlParser.parseFullMovie(constants.fullMovieSelector, result.body);
                    })
                    .then(parsedMovie => {
                        let dbMovie = modelsFactory.getFullMovie(
                            parsedMovie.coverImageLink,
                            parsedMovie.trailer,
                            parsedMovie.title,
                            parsedMovie.description,
                            parsedMovie.categories,
                            parsedMovie.releaseDate,
                            parsedMovie.actors
                        );

                        modelsFactory.insertFullMovie(dbMovie);
                    })
                    .catch(err => {
                        console.log(err);
                    });
            }, this);

            return awaiter(1000);
        })
        .then(() => {
            if (urlsQueue.isEmpty()) {
                return;
            }

            getMoviesFromUrl(urlsQueue.pop());
        })
        .catch((err) => {
            console.dir(err, {
                colors: true
            });
        });
}

let start = function start(pagesCount, genres) {

    genres.forEach(genre => {
        for (let i = 0; i < pagesCount; i += 1) {
            let url = urlProvider.getUrl(genre, i);
            urlsQueue.push(url);
        }
    });

    Array.from({
            length: pagesCount
        })
        .forEach(() => getMoviesFromUrl(urlsQueue.pop(), constants.simpleMovieCssSelector));

}

module.exports = {
    start(url, pagesCount, genres) {
        return start(url, pagesCount, genres)
    }
}