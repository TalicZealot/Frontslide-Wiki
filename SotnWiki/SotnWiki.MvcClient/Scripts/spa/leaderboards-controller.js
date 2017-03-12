var leaderboardsController = (() => {

    function cvsAlucardAnyNSC() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: '/api/CvSpeedrunsAlucardAny',
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function alucardAllBosses() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: '/api/alucardallbosses',
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        cvsAlucardAnyNSC,
        alucardAllBosses
    };
})();