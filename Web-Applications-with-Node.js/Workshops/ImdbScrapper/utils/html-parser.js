'use strict';

const jsdom = require('jsdom').jsdom;
const doc = jsdom();
const window = doc.defaultView;

const $ = require('jquery')(window);

module.exports.parseSimpleMovie = (html, selector) => {
    $("body").html(html);

    let items = [];

    $(selector).each((index, item) => {
        const $item = $(item);
        items.push({
            title: $item.html(),
            url: $item.attr('href')
        });
    });

    return Promise.resolve()
        .then(() => {
            return items;
        })
};