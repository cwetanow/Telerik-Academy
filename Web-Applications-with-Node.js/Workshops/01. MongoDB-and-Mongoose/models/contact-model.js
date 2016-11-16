const mongoose = require('mongoose');

var validateEmail = function (email) {
    var re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return re.test(email)
};

const contactSchema = new mongoose.Schema({
    phoneNumber: {
        type: String
    },
    email: {
        type: String,
        validate: [validateEmail, 'Please fill a valid email address'],
        trim: true,
        lowercase: true,
        match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, 'Please fill a valid email address']
    },
    roomNumber: {
        type: Number,
        min: [100],
        max: [999]
    }
});

module.exports = contactSchema;