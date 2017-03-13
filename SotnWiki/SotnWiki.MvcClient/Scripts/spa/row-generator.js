var rowGenerator = (() => {
    var containerId = '#leaderboard';

    function getGetOrdinal(n) {
        var s = ["th", "st", "nd", "rd"],
        v = n % 100;
        return n + (s[(v - 20) % 10] || s[v] || s[0]);
    }

    function getSubStr(str, delim) {
        var a = str.indexOf(delim);
        if (a == -1)
            return '';
        var b = str.indexOf(delim, a + 1);
        if (b == -1)
            return '';
        return str.substr(a + 1, b - a - 1);
    }

    function generateRows(runs) {
        $.each(runs, function (index, value) {
            if (!value.Url) {
                value.Url = "";
            }
            if (!value.Date) {
                value.Date = "";
            }
            var video = getSubStr(value.Url, '.');

            $(containerId).append('<tr><td>' + getGetOrdinal(index + 1) + '</td><td>'
                + value.Runner + '</td><td>' + value.Time + '</td><td><a href="'
                + value.Url + '">' + video + '</a></td><td>' + value.Platform + '</td><td>' + value.Date + '</td></tr>');
        });
    }

    return {
        generateRows
    };
})();