function solve() {
    return function (fileContentsByName) {
        // you solution


        $('.del-btn').click(function () {
            var parent = $(this).parent();
            parent.empty();
            parent.remove();
        });

        $('.item-name').click(function () {
            var target = $(this).parent();
            if (target.hasClass('dir-item')) {
                target.toggleClass('collapsed');
            } else {
                target = $('.file-content');
                var text = $(this).text();
                target.text(fileContentsByName[text]);
            }
        });

        $('.add-btn').click(function () {
            $(this).toggleClass('visible');
            $('.add-wrapper input').toggleClass('visible');
        });


        $('.add-wrapper input').keypress(function (e) {
            if (e.keyCode == 13) {
                var txt = $(this).val();
                var li, anchor, delBtn;

                if (txt.indexOf('/') < 0) {
                    li = $('<li></li>');
                    li.addClass('file-item');
                    li.addClass('item');

                    anchor = $('<a></a>');
                    anchor.addClass('item-name');
                    anchor.html(txt);

                    delBtn = $('<a></a>');
                    delBtn.addClass('del-btn');

                    li.append(anchor);
                    li.append(delBtn);

                    $('.file-explorer .items').first().append(li);

                    $('.add-btn').toggleClass('visible');
                    $('.add-wrapper input').toggleClass('visible');
                    $('.add-wrapper input').val('');
                } else {
                    var splitted = txt.split('/'),
                        dir = splitted[0],
                        file = splitted[1],
                        match = $('.item-name').filter(function (index) { return $(this).text() === dir && $(this).parent().hasClass('dir-item') } );
                        console.log(match.length>0);
                    if (match.length > 0 ) {
                        li = $('<li></li>');
                        li.addClass('file-item');
                        li.addClass('item');

                        anchor = $('<a></a>');
                        anchor.addClass('item-name');
                        anchor.html(file);

                        delBtn = $('<a></a>');
                        delBtn.addClass('del-btn');

                        li.append(anchor);
                        li.append(delBtn);

                        match.next().append(li);

                        $('.add-btn').toggleClass('visible');
                        $('.add-wrapper input').toggleClass('visible');
                        $('.add-wrapper input').val('');
                    }

                }
            }
        });


    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}