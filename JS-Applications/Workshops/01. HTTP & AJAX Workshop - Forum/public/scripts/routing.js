let router = (() => {
    let navigo;

    function init() {
        navigo = new Navigo(null, false);
        navigo
            .on('/gallery', () => {
                console.log('works');
            })
            .resolve();
    }

    return {
        init
    };
})();

export {router};