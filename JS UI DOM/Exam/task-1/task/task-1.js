/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        selector = document.querySelector(selector);

        initialSuggestions = initialSuggestions || [];

        var field = document.querySelector('.tb-pattern'),
            list = document.querySelector('.suggestions-list'),
            button = document.querySelector('.btn-add'),
            suggestions = [];

        for (var i = 0; i < initialSuggestions.length; i += 1) {
            if (!contains(initialSuggestions[i], suggestions)) {
                suggestions.push(initialSuggestions[i]);
                add(initialSuggestions[i], list);
            }
        }
        field.addEventListener('keyup', function (ev) {
            if (ev.target.value==="") {
                for (var i = 0; i < list.children.length; i += 1) {
                    list.children[i].style.display = "none";
                }
            } else {
                var pattern = ev.target.value.toLowerCase();
                for (var i = 0; i < list.children.length; i += 1) {
                    var node = list.children[i];
                    if (suggestions[i].toLowerCase().indexOf(pattern) >= 0) {
                        node.style.display = "";
                    } else {
                        node.style.display = "none";
                    }
                }
            }
        });

        button.addEventListener("click", function () {
            var text = field.value;
            if (initialSuggestions.indexOf(text) < 0) {
                add(text, list);
                suggestions.push(text);
            }
        });

        list.addEventListener("click", function (ev) {
            field.value = ev.target.innerHTML;
        });

        function add(fruit, list) {
            var li = document.createElement('li');
            li.className = "suggestion";
            var anchor = document.createElement('a');
            anchor.href = "#";
            anchor.className = "suggestion-link";
            anchor.innerHTML = fruit;
            li.appendChild(anchor);
            li.style.display = "none";
            list.appendChild(li);
        }

        function contains(sample, list) {
            for (var i = 0; i < list.length; i += 1) {
                if (list[i].toLowerCase() == sample.toLowerCase()) {
                    return true;
                }
            }
            return false;
        }


    };
}

module.exports = solve;