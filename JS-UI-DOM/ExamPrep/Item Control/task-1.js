  /* globals module, document, HTMLElement, console */
  /*
  Create a function that can add, search and remove items from a list

  The function takes two parameters:
  A selector that can be any CSS3 selector:
  By id -#id
  By class - .class
  By node type - div
  Or nested selectors - #this .is a .nested.selector
  A isCaseSensitive that sets the case-sensitivity of the search
  Possible values are true and false
  Has a default value false
  The following must be implemented:

  Adding an item
  Removing an item
  Searching items by a pattern

  The search can be either case-sensitive or case-insensitive
  Adding elements part must consist of an element with class add-controls, that contains:

  Text "Enter text"
  An input element
  An element with class button and content 'Add'
  By clicking the element with class button, a new item element with class list-item should be added to the element with class items-list (see 3. Result elements section_)
  An element with class list-item must be added to the element with class items-list
  Search elements part must consist of an element with class search-controls, that contains:

  Text "Search"
  An input element
  Typing in the input must refresh the contents of the element with class result-controls
  Hides all the elements with class list-item that does not contain the value of the input
  The search can be either case-sensitive or case-insensitive, depending on the isCaseSensitive parameter
  Hide the elements with display: none, otherwise, it will not be evaluated as correct!
  Result elements part must consists of an element with class result-controls, that contains:
  An element with class items-list
  The items-list element contains zero or many elements with class list-item
  Each element with class list-item contains of: * A text, that is taken from the input in the element with class add-controls * An element with class button, that has a content 'X' (capital 'x')
  By clicking any of the elements with class button in an element with class list-item:
  The element with class list-item that contains this button element, must be deleted
  */

  function solve() {
      return function(selector, isCaseSensitive) {
          //get all the variables
          var addControls,
              itemsControl,
              itemToAdd,
              itemsList,
              input,
              button,
              searchBar,
              searchBarContent,
              resultControl,
              searchControl,
              paragraph,
              current,
              lbl,
              lbl2,
              otherBtn,
              target;
          isCaseSensitive = isCaseSensitive || false;
          var root = document.getElementById(selector.replace(/#/g, ''));

          if (!root) {
              if (selector instanceof HTMLElement) {
                  root = selector;
              } else {
                  root = document.getElementsByClassName(selector.replace(/\./g, ''))[0];
              }

          }

          itemsControl = document.createElement('DIV');
          itemsControl.className = 'items-control';
          addControls = document.createElement('DIV');
          addControls.className = "add-controls";

          input = document.createElement('INPUT');
          button = document.createElement('A');
          button.innerHTML = "Add";
          button.className = "button";
          lbl = document.createElement('LABEL');
          lbl.innerHTML = 'Enter text ';
          addControls.appendChild(lbl);
          addControls.appendChild(input);
          addControls.appendChild(button);

          itemsControl.appendChild(addControls);

          itemsList = document.createElement('DIV');
          itemsList.className = "items-list";
          resultControl = document.createElement('DIV');
          resultControl.className = 'result-controls';
          resultControl.appendChild(itemsList);

          //add functionality
          button.addEventListener('click', function() {
              itemToAdd = document.createElement('DIV');
              itemToAdd.className = 'list-item';
              paragraph = document.createElement('LABEL');
              paragraph.innerHTML = input.value;
              otherBtn = document.createElement('A');
              otherBtn.className = 'button';
              otherBtn.innerHTML = "X";
              itemToAdd.appendChild(paragraph);
              itemToAdd.appendChild(otherBtn);
              itemsList.appendChild(itemToAdd);

          })
          searchControl = document.createElement('DIV');
          searchControl.className = 'search-controls';
          lbl2 = document.createElement('LABEL');
          lbl2.innerHTML = 'Search:';
          searchControl.appendChild(lbl2);
          searchBar = document.createElement('INPUT');
          searchControl.appendChild(searchBar);

          searchBarContent = searchBar.value;
          searchBar.addEventListener('keyup', function() {
              searchBarContent = searchBar.value;
              current = resultControl.getElementsByClassName('list-item');
              var text = current[i].getElementsByTagName('strong')[0].innerHTML;
              if (!isCaseSensitive) {
                  searchBarContent = searchBarContent.toLowerCase();
                  text = text.toLowerCase();
              }

              for (var i = 0; i < current.length; i += 1) {
                  if (text.indexOf(searchBarContent) >= 0) {
                      current[i].style.display = "";
                  } else {
                      current[i].style.display = "none";
                  }
              }


          })

          resultControl.addEventListener('click', function(ev) {
              target = ev.target;
              if (target.className === "button") {
                  target.parentNode.parentNode.removeChild(target.parentNode)
              }
          })
          resultControl.appendChild(itemsList);
          itemsControl.appendChild(searchControl);
          itemsControl.appendChild(resultControl);

          root.appendChild(itemsControl);

      }
  };

  module.exports = solve;
