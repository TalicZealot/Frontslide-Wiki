var rowGenerator = (() => {
    var containerId = '#leaderboard';

    function generateRows(runs) {
        $.each(runs, function (index, value) {
            $(containerId).append('<tr><td>' + value.Runner + '</td><td>' + value.Time + '</td></tr>');
        });
    }

    return {
        generateRows
    };
})();