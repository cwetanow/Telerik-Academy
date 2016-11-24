const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

const fractionSchema = new Schema({
    name: {
        type: String,
        required: true,
        min: 3,
        max: 30,
        unique: true
    },
    alignment: {
        type: String,
        enum: ['good', 'bad', 'evil'],
        required: true
    },
    superheroes: [
        String
    ],
    planets: [
        String
    ]
});

const Fraction = mongoose.model('Fraction', fractionSchema);

module.exports = Fraction;