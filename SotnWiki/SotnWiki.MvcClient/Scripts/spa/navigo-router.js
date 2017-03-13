var router = (() => {
    var containerId = '#leadrboard';
    var router = new Navigo(null, true);

    router.on('cvsalucardany%nsc', () => {
        leaderboardsController.cvsAlucardAnyNSC()
        .then((runs) => {
            rowGenerator.generateRows(runs);
        });
    });

    router.on(() => {
        router.navigate('cvsalucardany%nsc');
    });

    router.notFound(() => {
        router.navigate('cvsalucardany%nsc');
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();