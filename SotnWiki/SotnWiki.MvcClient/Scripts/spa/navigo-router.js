var router = (() => {
    var containerId = '#leadrboard';
    var router = new Navigo(null, true);

    router.on('CvsAlucardAny%NSC', () => {
        leaderboardsController.cvsAlucardAnyNSC()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();