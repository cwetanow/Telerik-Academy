/* globals module require*/

"use strict";

const chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!@()_-1234567890",
    length = 40;

function getRandomNumber(min = 0, max = Number.MAX_VALUE) {
    return 0 | (Math.random() * (max - min)) + min;
}

function getRandomString() {
    let str = "";

    for (let i = 0; i < length; i += 1) {
        let index = getRandomNumber(0, chars.length);
        let char = chars[index];
        str += char;
    }

    return str;
}

function* authKeyGenerator() {
    const forever = true;

    while (forever) {
        yield getRandomString();
    }
}

module.exports = function() {

    let akg = authKeyGenerator();
    return {
        getNext() {
            return akg.next().value;
        }
    };
};