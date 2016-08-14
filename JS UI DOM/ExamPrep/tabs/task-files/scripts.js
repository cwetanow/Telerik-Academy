$.fn.tabs = function () {
    var $self = $(this);
    $self.addClass('tabs-container');
    $('.tab-item').first().addClass('current');

    $('.tab-item-content').hide();
    $('.current .tab-item-content').show();

    $('.tab-item').click(function () {
        $('.current').removeClass('current');
        $(this).addClass('current');
        $('.tab-item-content').hide();
        $('.current .tab-item-content').show();
    });

};