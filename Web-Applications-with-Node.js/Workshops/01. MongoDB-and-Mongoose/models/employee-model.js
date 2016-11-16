const contact = require('./contact-model');
const item = require('./item-model');

const mongoose = require('mongoose');

const employeeSchema = mongoose.Schema({
    firstName: {
        type: String,
        required: true,
        validate: /([A-Z])\w+/
    },
    middleName: {
        type: String,
        required: true,
        validate: /([A-Z])\w+/
    },
    lastName: {
        type: String,
        required: true,
        validate: /([A-Z])\w+/
    },
    insuranceNumber: {
        type: String,
        required: true
    },
    age: {
        type: Number,
        required: true,
        validate: (v) => {
            return v > 0 && v < 120;
        }
    },
    contactDetails: contact,
    itemsForSale: [item],
    itemsReceived: [String]
});

module.exports = employeeSchema;

