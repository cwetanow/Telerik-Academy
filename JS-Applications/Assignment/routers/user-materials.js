/* globals module require */

"use strict";

const Router = require("express").Router;

const validCategories = ["watched", "want-to-watch", "watching"];

module.exports = function(data) {
    let router = new Router();

    router
        .get("/", (req, res) => {
            let user = req.user;
            if (!user) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can see their user materials" } });
            }

            let userMaterials = data.getUserMaterials(user);

            return res.send({
                result: userMaterials
            });
        })
        .get("/watched", (req, res) => {
            let user = req.user;
            if (!user) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can see their user materials" } });
            }

            let userMaterials = data.getWatchedUserMaterials(user);

            return res.send({
                result: userMaterials
            });
        })
        .get("/want-to-watch", (req, res) => {
            let user = req.user;
            if (!user) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can see their user materials" } });
            }

            let userMaterials = data.getWantToWatchUserMaterials(user);

            return res.send({
                result: userMaterials
            });
        })
        .get("/Watching", (req, res) => {
            let user = req.user;
            if (!user) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can see their user materials" } });
            }
            
            let userMaterials = data.getWatchingUserMaterials(user);

            return res.send({
                result: userMaterials
            });
        })
        .put("/", (req, res) => {
            let user = req.user;

            if (user === null) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can add materials" } });
            }

            if (!validCategories.includes(req.body.category)) {
                return res.status(400)
                    .send({ result: { err: "Invalid category" } });
            }

            let materialData = req.body;
            let material = data.getMaterialById(materialData.id);
            if (material === null) {
                return res.status(404)
                    .send({ result: { err: "Invalid material ID" } });
            }

            let userMaterial = data.getUserMaterialById(user, materialData.id);

            if (userMaterial) {
                data.changeCategoryOfUserMaterial(user, material, materialData.category);
            } else {
                data.addUserMaterial(user, material, materialData.category);
            }

            userMaterial = data.getUserMaterialById(user, materialData.id);

            return res.status(201)
                .send({
                    result: userMaterial
                });
        })
        .post("/", (req, res) => {
            let user = req.user;
            if (user === null) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can add materials" } });
            }

            if (!validCategories.includes(req.body.category)) {
                return res.status(400)
                    .send({ result: { err: "Invalid category" } });
            }

            let materialData = req.body;
            let material = data.getMaterialById(materialData.id);
            if (material === null) {
                return res.status(404)
                    .send({ result: { err: "Invalid material ID" } });
            }

            let userMaterial = data.getUserMaterialById(user, materialData.id);

            if (userMaterial) {
                return res.status(400)
                    .send({ result: { error: "User already has this material added" } });
            }

            userMaterial = data.addUserMaterial(user, material, materialData.category);

            return res.status(201)
                .send({
                    result: userMaterial
                });
        });

    return router;
};