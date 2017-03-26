$(function () {
    var titleInputId = "#Title";
    var availabilityFieldId = "#TitleAvailable";
    var statusFieldId = "#titleStatus";

    $.validator.setDefaults({
        ignore: "#ignore"
    });

    $(titleInputId).change(function () {
        var title = $(titleInputId).val();

        if (title.length > 3) {
            titleCheck.result(title)
                .then((result) => {
                    if (result) {
                        $(availabilityFieldId).val('true');
                        $(statusFieldId).attr('class', 'availableTitleStatus');
                    } else {
                        $(availabilityFieldId).val('false');
                        $(statusFieldId).attr('class', 'unavailableTitleStatus');
                    }
                });
        }
    });
});