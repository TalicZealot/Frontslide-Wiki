var leaderboardsController = (() => {

    function alucardAnyNSC() {
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
                url: '/api/CvsAlucardAllBosses',
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function alucardACE() {
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

    function alucardLowPercentWolf() {
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

    function richterAny() {
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

    function richterAllBosses() {
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

    function mariaAny() {
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

    function mariaAllBosses() {
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

    function mariaAnyEmu() {
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

    function mariaAllBossesEm() {
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

    function cvsAlucardAllBosses() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: '/api/CvsAlucardAllBosses',
                method: 'GET',
                contentType: 'application/json'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function cvsAlucardACE() {
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

    function cvsAlucardLowPercentWolf() {
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

    function cvsRichterAny() {
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

    function cvsRichterAllBosses() {
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

    function cvsMariaAny() {
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

    function cvsMariaAllBosses() {
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

    function cvsMariaAnyEmu() {
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

    function cvsMariaAllBossesEm() {
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
        alucardAnyNSC,
        alucardAllBosses,
        alucardACE,
        alucardLowPercentWolf,
        richterAny,
        richterAllBosses,
        mariaAny,
        mariaAllBosses,
        mariaAnyEmu,
        mariaAllBossesEmu,
        cvsAlucardAnyNSC,
        cvsAlucardAllBosses,
        cvsAlucardACE,
        cvsAlucardLowPercentWolf,
        cvsRichterAny,
        cvsRichterAllBosses,
        cvsMariaAny,
        cvsMariaAllBosses,
        cvsMariaAnyEmu,
        cvsMariaAllBossesEm,
    };
})();