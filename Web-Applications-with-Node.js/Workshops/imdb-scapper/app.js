/* globals console require setTimeout Promise */
'use strict';

const simpleMovieScrapper = require("./services/simple-movie-scrapper");
const constants = require("./config/constants");

simpleMovieScrapper.start(constants.pagesCount, constants.genres);