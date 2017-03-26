var titleCheck = (() => {
    function result(title) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: '/api/CheckTitleAvailability?title=' + title,
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        result
    };
})();