var leaderboardsController = (() => {

    function getCategory(name) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: '/api/category?name=' + name,
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        getCategory
    };
})();