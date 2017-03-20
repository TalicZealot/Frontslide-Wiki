var router = (() => {
    var containerId = '#leadrboard';
    var router = new Navigo(null, true);

    router.on('alucardAnyNSC', () => {
        leaderboardsController.getCategory('AlucardAnyNSC')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardAllBosses', () => {
        leaderboardsController.getCategory('AlucardAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardACE', () => {
        leaderboardsController.getCategory('AlucardACE')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardLowPercentWolf', () => {
        leaderboardsController.getCategory('AlucardLowPercentWolf')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('alucardGlitchless', () => {
        leaderboardsController.getCategory('AlucardGlitchless')
            .then((runs) => {
                rowGenerator.generateRows(runs);
            });
    });

    router.on('richterAny', () => {
        leaderboardsController.getCategory('RichterAny')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('richterAllBosses', () => {
        leaderboardsController.getCategory('RichterAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAny', () => {
        leaderboardsController.getCategory('MariaAny')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAllBosses', () => {
        leaderboardsController.getCategory('MariaAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAnyEmu', () => {
        leaderboardsController.getCategory('MariaAnyEmu')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('mariaAllBossesEmu', () => {
        leaderboardsController.getCategory('MariaAllBossesEmu')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardAnyNSC', () => {
        leaderboardsController.getCategory('CvsAlucardAnyNSC')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardAllBosses', () => {
        leaderboardsController.getCategory('CvsAlucardAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardACE', () => {
        leaderboardsController.getCategory('CvsAlucardACE')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsAlucardLowPercentWolf', () => {
        leaderboardsController.getCategory('CvsAlucardLowPercentWolf')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsRichterAny', () => {
        leaderboardsController.getCategory('CvsRichterAny')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsRichterAllBosses', () => {
        leaderboardsController.getCategory('CvsRichterAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAny', () => {
        leaderboardsController.getCategory('CvsMariaAny')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAllBosses', () => {
        leaderboardsController.getCategory('CvsMariaAllBosses')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAnyEmu', () => {
        leaderboardsController.getCategory('CvsMariaAnyEmu')
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on('cvsMariaAllBossesEmu', () => {
        leaderboardsController.getCategory('CvsMariaAllBossesEmu')
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