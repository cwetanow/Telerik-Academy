/* globals require module */
"use strict";

const mongoose = require("mongoose"),
    Schema = mongoose.Schema;

const movie = new Schema({
    name: {
        type: String,
        required: true
    },
    imdbId: {
        type: String,
        required: true
    },
    characterName: {
        type: String,
        required: true
    }
});

let ActorSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    image: {
        type: String,
        required: true
    },
    description: {
        type: String,
        required: true
    },
    movies: [movie]
});

let Actor = mongoose.model("Actor", ActorSchema);

module.exports = Actor;