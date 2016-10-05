/* globals module require*/

"use strict";

const authKeysGenerator = require("../utils/auth-key-generator")();

module.exports = function(db) {
    return {
        /* USERS */

        getAllUsers() {
            return db.get("users")
                .value();
        },

        getUserByUsername(username) {
            let user = db.get("users")
                .find({
                    usernameToLower: username.toLowerCase()
                })
                .value();
            return user || null;
        },
        getUserByAuthKey(authKey) {
            let user = db.get("users")
                .find({ authKey })
                .value();
            return user || null;
        },
        createUser(username, password) {
            let user = {
                username,
                password,
                usernameToLower: username.toLowerCase()
            };

            db.get("users").insert(user).value();

            db.write();

            return user;
        },
        generateAuthKeyForUser(user) {
            db.get("users")
                .find({ id: user.id })
                .assign({ authKey: authKeysGenerator.getNext() })
                .value();
        },

        /* materialS */

        getMaterials(keyword) {
            let keywordToLower = keyword.toLowerCase();
            return db.get("materials")
                .value()
                .filter(m => {
                    return m.title.toLowerCase().includes(keywordToLower) ||
                        m.description.toLowerCase().includes(keywordToLower) ||
                        m.user.username.toLowerCase().includes(keywordToLower);
                });
        },

        getMaterialById(id) {
            let material = db.get("materials")
                .getById(id)
                .value();
            return material || null;
        },

        createMaterial(title, description, img, user) {
            let material = {
                title,
                description,
                img,
                createdOn: new Date(),
                rating: 0,
                comments: [],
                user: {
                    id: user.id,
                    username: user.username
                }
            };

            db.get("materials")
                .insert(material)
                .value();

            return material;
        },

        addCommentToMaterial(material, commentText, user) {
            let comments = material.comments || [];
            comments.push({
                text: commentText,
                user: {
                    id: user.id,
                    username: user.username
                }
            });

            db.get("materials")
                .find({ id: material.id })
                .assign({ comments })
                .value();
        },

        /* USER MATERIALS */

        getUserMaterials(user) {
            let userMaterials = (user.userMaterials || []).map(um => {
                let material = this.getMaterialById(um.id);

                let userMaterial = {
                    category: um.category
                };

                Object.keys(material)
                    .forEach(key => {
                        userMaterial[key] = material[key];
                    });
                return userMaterial;
            });

            return userMaterials;
        },
        getWatchedUserMaterials(user) {
            return this.getUserMaterials(user)
                .filter(um => um.category === "watched");
        },
        getWantToWatchUserMaterials(user) {
            return this.getUserMaterials(user)
                .filter(um => um.category === "want-to-watch");
        },
        getWatchingUserMaterials(user) {
            return this.getUserMaterials(user)
                .filter(um => um.category === "watching");
        },


        getUserMaterialById(user, materialId) {
            let userMaterial = (user.userMaterials || []).find(um => um.id === materialId);
            return userMaterial || null;
        },
        addUserMaterial(user, material, category) {
            let userMaterial = {
                id: material.id,
                title: material.title,
                category: category
            };

            let userMaterials = user.userMaterials || [];
            userMaterials.push(userMaterial);

            db.get("users")
                .find({ id: user.id })
                .assign({ userMaterials })
                .value();

            return userMaterial;
        },
        changeCategoryOfUserMaterial(user, material, category) {

            let userMaterials = user.userMaterials;
            let userMaterial = userMaterials.find(um => um.id === material.id);
            userMaterial.category = category;

            db.get("users")
                .find({ id: user.id })
                .assign({ userMaterials })
                .value();

            return userMaterial;
        }
    };
};