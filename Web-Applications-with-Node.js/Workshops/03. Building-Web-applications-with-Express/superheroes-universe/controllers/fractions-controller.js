module.exports = function (data) {
    return {
        createFraction(req, res) {
            let body = req.body;
            data.createFraction(body.name, body.superheroes)
                .then(() => {
                    res.redirect("/fractions");
                });
        },
        getAll(req, res) {
            data.getAllFractions()
                .then(fractions => {
                    return res.render('fraction-list', {
                        fractions
                    });
                })
        },
        getFractionById(req, res) {
            data.getFractionById(req.params.id)
                .then(fraction => {
                    if (fraction === null) {
                        return res.status(404)
                            .redirect("/error");
                    }

                    return res.render('fraction-details', {
                        fraction
                    });
                });
        },
        getFractionsByAlignment(req, res) {
            data.getFractionsByAlignment(req.params.alignment)
                .then(fraction => {
                    if (fraction === null) {
                        return res.status(404)
                            .redirect("/error");
                    }

                    return res.render('fraction-list', {
                        fraction
                    });
                });
        },
        getFractionsByPlanet(req, res) {
            data.getFractionsByPlanet(req.params.planet)
                .then(fraction => {
                    if (fraction === null) {
                        return res.status(404)
                            .redirect("/error");
                    }

                    return res.render('fraction-list', {
                        fraction
                    });
                });
        }
    }
}