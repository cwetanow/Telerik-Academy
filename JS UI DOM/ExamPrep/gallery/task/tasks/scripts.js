/* globals $ */

function solve() {
  $.fn.gallery = function (cols) {
    $(this).addClass('gallery');

    //Get columns
    var  columns=Number(cols);
    if (!columns) {
      columns=4;
    }


    //Fix table width
    var $width = 100/columns-1;
    $('.gallery .image-container').width($width+'%');
    $('.selected').hide();

    var $imageSrc=[];
    $('.gallery-list').children().each(function(index, image) {
    $imageSrc.push($(image).children().attr('src'));
    });

    //Change main image
    $('.image-container img').click(function(){
      $('.gallery-list').addClass('blurred');
      $('.gallery-list').addClass('disabled-background');
        $('.gallery-list').css('pointer-events','none');
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
      $('.gallery-list').removeClass('blurred');
      $('.gallery-list').removeClass('disabled-background');
        $('.gallery-list').css('pointer-events','auto');
    });

    $('.previous-image img, .next-image img').click(function() {
        var $target=$(this).attr('src');
        var $prev, $next;

        for (var i = 0; i < $imageSrc.length; i+=1) {
          if ($imageSrc[i]===$target) {
            $prev=$imageSrc[i-1];
            $next=$imageSrc[i+1];
            break;
          }
        }

        if (!$prev) {
          $prev=$imageSrc[$imageSrc.length-1];
        }
        if (!$next) {
          $next=$imageSrc[0];
        }

        $('.previous-image img').attr('src', $prev);
        $('.current-image img').attr('src', $target);
        $('.next-image img').attr('src', $next);
    });
};
}

module.exports = solve;
