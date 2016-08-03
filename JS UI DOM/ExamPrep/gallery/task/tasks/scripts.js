/* globals $ */

//function solve() {
  $.fn.gallery = function (cols) {
    // your solution here
    $(this).addClass('gallery');

    //Get columns
    var  columns=Number(cols);
    if (!columns) {
      columns=4;
    }

    //Fix table width
    var $width = Math.round(100/columns)-1;
    $('.gallery .image-container').width($width+'%');
    $('.selected').hide();

    //Change main image
    $('.image-container img').click(function(){
      $('.selected').show();
      var $target = $(this).attr('src');
      var $prev = $(this).parent().prev().find('img').attr('src');
      var $next = $(this).parent().next().find('img').attr('src');

      if (!$prev) {
        $prev=$('.gallery-list').children().last().find('img').attr('src');
      }
      if (!$next) {
        $next=$('.gallery-list').children().first().find('img').attr('src');
      }

      $('.previous-image img').attr('src', $prev);
      $('.current-image img').attr('src', $target);
      $('.next-image img').attr('src', $next);
    });

    //hide selected when clicked on main
    $('.current-image img').click(function(){
      $('.selected').hide();
    });





  };
//}

//module.exports = solve;
