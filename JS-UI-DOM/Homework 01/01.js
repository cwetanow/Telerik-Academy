/*
Create a function that takes an id or DOM element and an array of contents
* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed
*/

function solve() {
    return function(element, contents) {
        if (typeof element !== 'string' && !(element instanceof HTMLElement)) {
            throw new Error();
        }
        var domElement, content,
            len = contents.length;
        if (typeof element === 'string') {
            domElement = document.getElementById(element);
            if (!domElement) {
                throw new Error();
            }
        } else {
            domElement = element;
        }
        var content;
        for (var i = 0; i < len; i += 1) {
            content = contents[i];
            if (typeof content != "string" && typeof content != 'number') {
                throw new Error();
            }
        }
        var docFragment = document.createDocumentFragment();
        domElement.innerHTML = "";
        var div = document.createElement('div');
        for (var i = 0; i < len; i += 1) {
            var newDiv = div.cloneNode(true);
            newDiv.innerHTML = contents[i];
            docFragment.appendChild(newDiv);
        }
        domElement.appendChild(docFragment);

    };
}
