$(function () {
    $('.expand').click(function () {
        var button = $(this);

        if (button.hasClass('retracted') && !$(this).hasClass('nobkg')) {
            button.addClass('expanded');
            button.removeClass('retracted');
        } else {
            button.removeClass('expanded');
            button.addClass('retracted');
        }

        if (button.hasClass('nobkg')) {
            button.parent().next().slideToggle('fast', function () { });
            if (button.text() == "hide") {
                button.text("show");
            }
            else {
                button.text("hide");
            }
        }
        else {
            button.next().slideToggle('fast', function () { });
        }
    });
});