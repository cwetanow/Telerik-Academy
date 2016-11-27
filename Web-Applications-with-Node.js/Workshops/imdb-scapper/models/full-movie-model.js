/* globals require module */
"use strict";

const mongoose = require("mongoose"),
    Schema = mongoose.Schema;

let FullMovieSchema = new Schema({
    title: {
        type: String,
        required: true
    },
    coverImage: {
        type: String,
        required: true
    },
    trailer: {
        type: String,
        required: true
    },
    description: {
        type: String,
        required: true
    },
    categories: [
        [String]
    ],
    releaseDate: {
        type: Date,
        required: true,
        default: Date.now
    },
    actors: [{
        name: {
            type: String,
            required: true
        },
        img: {
            type: String,
            required: true
        },
        role: {
            type: String,
            required: true
        },
        id: {
            type: String,
            required: true
        }
    }]
});

let FullMovie = mongoose.model("FullMovie", FullMovieSchema);

module.exports = FullMovie;