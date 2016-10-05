/* globals module require */

"use strict";

const Router = require("express").Router;

function toUserMaterialModel(material) {
    return {
        id: material.id,
        title: material.title,
        category: material.category
    };
}

function toProfileModel(user) {
    return {
        id: user.id,
        username: user.username,
        userMaterials: (user.userMaterials || []).map(toUserMaterialModel)
    };
}

module.exports = function(data) {
    let router = new Router();

    router
        .get("/:username", (req, res) => {
            let user = data.getUserByUsername(req.params.username);
            if (user === null) {
                return res.status(404)
                    .send({ result: { err: "User not found" } });
            }

            return res.send({
                result: toProfileModel(user)
            });
        });

    return router;
};