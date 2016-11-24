const express = require("express");

module.exports = function (app, data) {
    let controller = require("../controllers/fractions-controller")(data);

    let router = new express.Router();

    router
        .get("/", controller.getAll)
        .get("/:id", controller.getFractionById)
        .get("/:planet", controller.getFractionsByAlignment)
        .get("/:planet", controller.getFractionsByPlanet)
        .post("/", controller.createFraction);

    app.use("/fractions", router);
};