/*globals describe, it, require, before, global, $, jQuery, document*/

var expect = require("chai").expect;
var jsdom = require("jsdom");
var jq = require("jquery");
var result = require("../task/task-1")();

describe("Task #1 Zero Tests", function() {
    before(function(done) {
        jsdom.env({
            "html": "",
            "done": function(errors, window) {
                global.window = window;
                global.document = window.document;
                global.$ = jq(window);
                Object.keys(window)
                    .filter(function(prop) {
                        return prop.toLowerCase().indexOf('html') >= 0;
                    }).forEach(function(prop) {
                        global[prop] = window[prop];
                    });
                done();
            }
        });
    });

    it("Expect to contain no .suggestion elements, when no suggestions array provided", function() {
        document.body.innerHTML = " " +
            '  <div class="autocomplete">' +
            '        <input class="tb-pattern" type="text" />' +
            '        <a href="#" class="btn-add">Add</a>' +
            '        <ul class="suggestions-list">' +
            '        </ul>' +
            '    </div>';

        var $HaHa_No_jQuery = $;
        $ = jQuery = undefined;
        result('.autocomplete');
        $ = jQuery = $HaHa_No_jQuery;
        var $container = $('.autocomplete');

        var $suggestions = $container.find(".suggestion");

        expect($suggestions.length).to.equal(0);
    });

    it("Expect to contain 5 .suggestion elements, when a suggestions array with 5 elements provided", function() {
        document.body.innerHTML = " " +
            '  <div class="autocomplete">' +
            '        <input class="tb-pattern" type="text" />' +
            '        <a href="#" class="btn-add">Add</a>' +
            '        <ul class="suggestions-list">' +
            '        </ul>' +
            '    </div>';

        var $HaHa_No_jQuery = $;
        $ = jQuery = undefined;
        var suggestionsList = ["Apples", "Oranges", "Kiwis", "Watermelons", "Peaches"];
        result('.autocomplete', suggestionsList);
        $ = jQuery = $HaHa_No_jQuery;
        var $container = $('.autocomplete');

        var $suggestions = $container.find(".suggestion");

        expect($suggestions.length).to.equal(suggestionsList.length);
    });


    it("Expect to contain 4 unique .suggestion elements, when a suggestions array with 5 elements (with two repeating) provided", function() {
        document.body.innerHTML = " " +
            '  <div class="autocomplete">' +
            '        <input class="tb-pattern" type="text" />' +
            '        <a href="#" class="btn-add">Add</a>' +
            '        <ul class="suggestions-list">' +
            '        </ul>' +
            '    </div>';

        var $HaHa_No_jQuery = $;
        $ = jQuery = undefined;
        var suggestionsList = ["Apples", "Oranges", "aPPles", "Watermelons", "Peaches"];
        result('.autocomplete', suggestionsList);
        $ = jQuery = $HaHa_No_jQuery;
        var $container = $('.autocomplete');

        var $suggestions = $container.find(".suggestion");
        expect($suggestions.length).to.equal(suggestionsList.length - 1);
    });
	
    it("Expect to show 4 elements, when \"a\" autocomplete string is provided", function() {
        document.body.innerHTML = " " +
            '  <div class="autocomplete">' +
            '        <input class="tb-pattern" type="text"/>' +
            '        <a href="#" class="btn-add">Add</a>' +
            '        <ul class="suggestions-list">' +
            '        </ul>' +
            '    </div>';

        var $HaHa_No_jQuery = $;
        $ = jQuery = undefined;
        var suggestionsList = ["Apples", "Oranges", "Kiwis", "Watermelons", "Peaches"];

        result(".autocomplete", suggestionsList);

        $ = jQuery = $HaHa_No_jQuery;
        var $container = $(".autocomplete");

        var $input = $container.find(".tb-pattern").eq(0);

        $input.val("a");

        var inputEvent = document.createEvent("HTMLEvents");
        inputEvent.initEvent("input", true, true);

        $input.get(0).dispatchEvent(inputEvent);

        var $suggestions = $container.find(".suggestion");

        var count = 0;
        $suggestions.each(function(index, suggestion) {
            var $suggestion = $(suggestion);

            if ($suggestion.css("display") !== "none" &&
                $suggestion.find(".suggestion-link").css("display") !== "none") {
                count += 1;
            }
        });

        expect(count).to.equal(4);
    });

    it("Expect click on suggestion to fill the value to the autocomplete input", function() {
        document.body.innerHTML = " " +
            '  <div class="autocomplete">' +
            '        <input class="tb-pattern" type="text"/>' +
            '        <a href="#" class="btn-add">Add</a>' +
            '        <ul class="suggestions-list">' +
            '        </ul>' +
            '    </div>';

        var $HaHa_No_jQuery = $;
        $ = jQuery = undefined;
        var suggestionsList = ["Apples", "Oranges", "Kiwis", "Watermelons", "Peaches"];

        result(".autocomplete", suggestionsList);

        $ = jQuery = $HaHa_No_jQuery;
        var $container = $(".autocomplete");

        var $input = $container.find(".tb-pattern").eq(0);

        $input.val("appl");

        var inputEvent = document.createEvent("HTMLEvents");
        inputEvent.initEvent("input", true, true);

        $input.get(0).dispatchEvent(inputEvent);

        var $suggestions = $container.find(".suggestion");

        $suggestions.eq(0).find(".suggestion-link").click();
        var clickEvent = document.createEvent("MouseEvents");

        clickEvent.initEvent("click", true, true);

        $suggestions.eq(0).find(".suggestion-link").get(0).dispatchEvent(clickEvent);

        expect($input.val()).to.equal($suggestions.eq(0).find(".suggestion-link").html());
    });
});