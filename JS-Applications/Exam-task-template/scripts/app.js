let router = new Navigo(null, false);

router
    .on(() => {
        router.navigate("/home");
    })
    .resolve();