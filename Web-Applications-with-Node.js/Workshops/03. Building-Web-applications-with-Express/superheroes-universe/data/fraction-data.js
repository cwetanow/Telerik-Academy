module.exports = function (models) {
    let {
        Fraction
    } = models;

    return {
        getAllFractions() {
            return new Promise((resolve, reject) => {
                Fraction.find((err, fractions) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(fractions);
                });
            });
        },
        createFraction(name, superheroes) {
            let planets = [];
            let alignment = '';
            superheroes.forEach(function (superhero) {
                planets.push(superhero.city.county.planet);
                alignment = superhero.alignment;
            }, this);

            let fraction = new Fraction({
                name: name,
                superheroes: superheroes,
                planets: planets,
                alignment: alignment
            })
        },
        getFractionsByAlignment(alignment) {
            return new Promise((resolve, reject) => {
                Fraction.find({
                        alignment: alignment
                    },
                    (err, fractions) => {
                        if (err) {
                            return reject(err);
                        }

                        return resolve(fractions);
                    });
            });
        },
        getFractionsByPlanet(planet) {
            return new Promise((resolve, reject) => {
                Fraction.find({
                        planets: planet
                    },
                    (err, fractions) => {
                        if (err) {
                            return reject(err);
                        }

                        return resolve(fractions);
                    });
            });
        },
        getFractionById(id) {
            return new Promise((resolve, reject) => {
                Fraction.findOne({
                    _id: id
                }, (err, fraction) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(fraction);
                });
            });
        }
    };
};