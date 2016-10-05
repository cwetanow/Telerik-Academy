/* globals module require */

"use strict";

const DEFAULT_ORDER_TYPE = "createdOn";

const Router = require("express").Router;

const LIMITS = {
    MIN_COMMENT_LENGTH: 3,
    MAX_COMMENT_LENGTH: 300,
    MIN_MATERIAL_TITLE_LENGTH: 6,
    MAX_MATERIAL_TITLE_LENGTH: 30
};

const DEFAULTS = {
    IMG_URL: "http://html5beginners.com/wp-content/uploads/2014/09/js.png"
};

const mappings = {
    toMaterialResponse(material) {
        return {
            id: material.id,
            title: material.title,
            description: material.description,
            createdOn: material.createdOn,
            rating: material.rating,
            img: material.img || DEFAULTS.IMG_URL,
            commentsCount: (material.comments || []).length,
            user: {
                id: material.user.id,
                username: material.user.username
            }
        };
    },
    toMaterialDetailedResponse(material) {
        let model = mappings.toMaterialResponse(material);
        model.comments = material.comments;
        return model;
    }
};

function isMaterialValid(material) {
    return material &&
        (typeof material.title === "string" && material.title.length >= LIMITS.MIN_MATERIAL_TITLE_LENGTH && material.title.length <= LIMITS.MAX_MATERIAL_TITLE_LENGTH) &&
        (typeof material.description === "string");
}

function isCommentValid(comment) {
    return comment &&
        (typeof comment.commentText === "string" && comment.commentText.length >= LIMITS.MIN_COMMENT_LENGTH && comment.commentText.length <= LIMITS.MAX_COMMENT_LENGTH);
}

module.exports = function(data) {
    let router = new Router();

    router
        .get("/", (req, res) => {
            let order = req.query.order || DEFAULT_ORDER_TYPE;
            let keyword = req.query.filter || "";

            let materials = data.getMaterials(keyword)
                .sort((x, y) => {
                    if (typeof x[order] === "number") {
                        return y[order] - x[order];
                    }
                    return y[order].toString().localeCompare(x[order].toString());
                }).map(mappings.toMaterialResponse);

            res.send({
                result: materials
            });
        })
        .get("/:id", (req, res) => {
            let material = data.getMaterialById(req.params.id);
            if (material === null) {
                return res.status(404)
                    .send({ result: { err: "No such material" } });
            }

            material = mappings.toMaterialDetailedResponse(material);

            return res.send({
                result: material
            });
        })
        .put("/:id/comments", (req, res) => {
            if (req.user === null) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can comment" } });
            }

            let commentText = req.body.commentText;
            if (!isCommentValid(req.body)) {
                return res.status(400)
                    .send({ result: { err: "invalid comment" } });
            }

            let material = data.getMaterialById(req.params.id);
            if (material === null) {
                return res.status(404)
                    .send({ result: { err: "No such material" } });
            }

            data.addCommentToMaterial(material, commentText, req.user);

            return res.send({
                result: mappings.toMaterialDetailedResponse(material)
            });
        })
        .post("/", (req, res) => {
            if (!req.user) {
                return res.status(401)
                    .send({ result: { err: "Only authenticated users can create materials" } });
            }

            let material = req.body;

            if (!isMaterialValid(material)) {
                return res.status(400)
                    .send({ result: { err: "Invalid material" } });
            }

            let dbMaterial = data.createMaterial(material.title, material.description, material.img, req.user);

            return res.status(201)
                .send({
                    result: mappings.toMaterialDetailedResponse(dbMaterial)
                });
        });

    return router;
};