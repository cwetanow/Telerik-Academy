const mongoose = require('mongoose');

const itemSchema = new mongoose.Schema({
    itemName: {
        type: String,
        required: true
    },
    price: Number,
    startDate: {
        type: Date,
        required: true,
        default: Date.now,
    },
    giveAwayStatus: {
        type: String,
        required: true,
        validate: {
            validator: (v) => {
                return v === 'Give away' || v === 'For Sale';
            }
        }
    },
    endDate: {
        type: Date,
        required: true,
        default: Date.now,
    }
});

module.exports = itemSchema;