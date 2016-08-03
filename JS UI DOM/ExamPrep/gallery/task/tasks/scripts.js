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


    $('.image-container img').click(function(){
      var $target = $(this).attr('src');
      var $prev = $(this).parent().prev().find('img').attr('src');
      var $next = $(this).parent().next().find('img').attr('src');

      if (!$prev) {
        $prev=$(this).parent().last().find('img').attr('src');
      }
      if (!$next) {
        $prev=$(this).parent().first().find('img').attr('src');
      }
      console.log($prev);
      $('.previous-image img').attr('src', $prev);
      $('.current-image img').attr('src', $target);
      $('.next-image img').attr('src', $next);
    });





  };
//}

//module.exports = solve;
