/*globals console require */
'use strict';

const constants = require('./config/constants');

const httpRequester = require('./utils/http-requester');
const htmlParser = require('./utils/html-parser');

const queueFactory = require('./data-structures/queue');
let urlQueue = queueFactory.getQueue();

constants.genres.forEach(function (genre) {
    for (let index = 0; index < constants.pagesCount; index += 1) {
        let url = `http://www.imdb.com/search/title?genres=${genre}&title_type=feature&sort=moviemeter,asc&page=${index+1}&view=simple&ref_=adv_nxt`;

        urlQueue.enqueue(url);
    }
}, this);

function wait(time) {
    return new Promise((resolve, reject) => {
        setTimeout(function () {
            resolve();
        }, time);
    });
}

const db = require('./config/mongoose')(constants.connectionString);

const modelsFactory = require('./models');

db.on('error', (err) => {
    console.log(err);
});

function getMoviesFromUrl(url) {
    httpRequester.get(url)
        .then((result) => {
            const selector = '.col-title span[title] a';
            const html = result.body;

            return htmlParser.parseSimpleMovie(html, selector)
        })
        .then(movies => {
            let dbMovies = movies.map(movie => {
                return modelsFactory.getSimpleMovie(movie.title, movie.url);
            })

            modelsFactory.insertManySimpleMovies(dbMovies);
            console.log(`Inserted ${movies.length}`);

            return wait(2000);
        })
        .then(() => {
            if (urlQueue.isEmpty()) {
                return;
            }

            getMoviesFromUrl(urlQueue.dequeue());
        })
        .catch((err) => {
            console.dir(err, {
                colors: true
            });
        });
}

const asyncPagesCount = 30;

db.on('open', () => {
    console.log('Connection is open');

    for (let i = 0; i < asyncPagesCount; i += 1) {
        getMoviesFromUrl(urlQueue.dequeue());
    }
}, this);