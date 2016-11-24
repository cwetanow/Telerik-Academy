const mongoose = require('mongoose'),
    Schema = mongoose.Schema;

const superheroSchema = new Schema({
    name: {
        type: String,
        required: true,
        min: 3,
        max: 20,
        unique: true
    },
    secretIdentity: {
        type: String,
        required: true,
        min: 3,
        max: 20,
        unique: true
    },
    alignment: {
        type: String,
        enum: ['good', 'bad', 'evil'],
        required: true
    },
    story: {
        type: String,
        required: true,
        min: 1
    },
    imageLink: {
        type: String,
        required: true
    },
    city: {
        name: {
            type: String,
            required: true,
            min: 2,
            max: 30,
            unique: true
        },
        country: {
            name: {
                type: String,
                required: true,
                min: 2,
                max: 30,
            },
            planet: {
                type: String,
                required: true,
                min: 2,
                max: 30,
            }
        }
    },
    fractions: [{
        fractionName: String
    }],
    powers: [{
        name: {
            type: String,
            required: true,
            min: 3,
            max: 35,
            unique: true
        }
    }]
});

const Superhero = mongoose.model('Superhero', superheroSchema);

module.exports = Superhero;