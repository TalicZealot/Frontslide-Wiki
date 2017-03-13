var router = (() => {
    var containerId = '#leadrboard';
    var router = new Navigo(null, true);

    router.on('alucardAnyNSC', () => {
        leaderboardsController.alucardAnyNSC()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardAllBosses', () => {
        leaderboardsController.alucardAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardACE', () => {
        leaderboardsController.alucardACE()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardLowPercentWolf', () => {
        leaderboardsController.alucardLowPercentWolf()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('richterAny', () => {
        leaderboardsController.richterAny()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('richterAllBosses', () => {
        leaderboardsController.richterAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAny', () => {
        leaderboardsController.mariaAny()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAllBosses', () => {
        leaderboardsController.mariaAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAnyEmu', () => {
        leaderboardsController.mariaAnyEmu()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAllBossesEmu', () => {
        leaderboardsController.mariaAllBossesEmu()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    /////////////////////////////////////////////////////////////////////////

    router.on('cvsAlucardAnyNSC', () => {
        leaderboardsController.cvsAlucardAnyNSC()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardAllBosses', () => {
        leaderboardsController.cvsAlucardAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardACE', () => {
        leaderboardsController.cvsAlucardACE()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardLowPercentWolf', () => {
        leaderboardsController.cvsAlucardLowPercentWolf()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAichterAny', () => {
        leaderboardsController.cvsAichterAny()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsRichterAllBosses', () => {
        leaderboardsController.cvsRichterAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAny', () => {
        leaderboardsController.cvsMariaAny()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAllBosses', () => {
        leaderboardsController.cvsMariaAllBosses()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAnyEmu', () => {
        leaderboardsController.cvsMariaAnyEmu()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAllBossesEmu', () => {
        leaderboardsController.cvsMariaAllBossesEmu()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    /////////////////////////////////////////////////////////////////////////

    router.on(() => {
        router.navigate('cvsAlucardAnyNSC');
    });

    router.notFound(() => {
        router.navigate('cvsAlucardAnyNSC');
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();