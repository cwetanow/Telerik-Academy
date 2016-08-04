/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string`

*/
function solve() {
  return function (selector) {
    if (typeof selector !== "string" ) {
        throw Error();
    }
      var $element = $(selector);

      if ($element.length!==0) {
          $('.button').html("hide");
      } else {
          throw Error();
      }

      var $elements=[];

      $('.button, .content').each(function(){
        $elements.push($(this));
      });

      $('.button').click(function(){
        // var index = $elements.indexOf($(this));
        // if ($(this).html()==="show") {
        //   for (var i = index; i < $elements.length; i+=1) {
        //     if ($elements[i].hasClass("content")) {
        //       $(this).html("hide");
        //       $elements[i].display("");
        //     }
        //   }
        // }
        // else {
        //   for (var i = index; i < $elements.length; i+=1) {
        //     if ($elements[i].hasClass("content")) {
        //       $(this).html("show");
        //       $elements[i].display("none");
        //     }
        //   }
        var targetButton = $(this);
        var next = targetButton.next();
        while (next.hasClass("content")) {
            next = next.next();
        }
        if (!targetButton.hasClass('button')) {
            return;
        }
        if (next.hasClass('content')) {
          var  content = next;

            while (next.length!==0) {
                if (next.hasClass('button')) {
                    if (content.style.display === 'none') {
                        content.style.display = '';
                        targetButton.html('hide');
                    } else {
                        content.style.display = 'none';
                        targetButton.html('show');
                    }
                    break;
                }
                next = next.next();

            }
        }


      });


  };
};

module.exports = solve;
