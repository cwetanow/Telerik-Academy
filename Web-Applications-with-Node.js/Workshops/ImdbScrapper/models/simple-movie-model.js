const mongoose = require('mongoose');

const simpleMovieSchema = new mongoose.Schema({
    url: {
        type: String,
        required: true
    },
    title: {
        type: String,
        required: true
    }
});

const Movie = mongoose.model('SimpleMovie', simpleMovieSchema);

module.exports = mongoose.model('SimpleMovie');