$(function () {
    $('.expand').click(function () {
        console.log('asdf');
        if ($(this).hasClass('retracted') && !$(this).hasClass('nobkg')) {
            $(this).addClass('expanded');
            $(this).removeClass('retracted');
        } else {
            $(this).removeClass('expanded');
            $(this).addClass('retracted');
        }
        $(this).next().slideToggle('fast', function () { });
    });
});