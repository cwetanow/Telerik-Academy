/* globals require module */
"use strict";

const mongoose = require("mongoose");

module.exports = function(connectionString) {
    mongoose.connect(connectionString);
};