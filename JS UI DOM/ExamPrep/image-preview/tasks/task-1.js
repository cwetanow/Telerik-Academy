/* globals module */
function solve() {
    return function (selector, items) {
        var element = document.querySelector(selector),
            preview = document.createElement('div');

        preview.className = 'image-preview';

        items.forEach(function (item) {
            var img = document.createElement('img'),
                text = document.createElement('strong'),
                container = document.createElement('div');

            text.innerHTML = item.title;
            img.setAttribute('src', item.url);

            container.className = 'image-container';
            container.appendChild(text);
            container.appendChild(img);
            element.appendChild(container);
        }, this);

        var image = document.createElement('img'),
            txt = document.createElement('strong');
        image.setAttribute('src', items[0].url);
        txt.innerHTML=items[0].title;

        preview.appendChild(txt);
        preview.appendChild(image);
        element.appendChild(preview);

    };
}

module.exports = solve;