/* globals require, module, console */

"use strict";


function getRoutes(app) {
    let routes = [],
        route;

    app._router.stack.forEach(function(middleware) {
        if (middleware.route) { // routes registered directly on the app
            routes.push(middleware.route);
        } else if (middleware.name === 'router') { // router middleware
            middleware.handle.stack.forEach(function(handler) {
                route = handler.route;
                let method = Object.keys(route.methods)[0].toUpperCase();
                routes.push(`${method} ${middleware.regexp}/${route.path}`);
            });
        }
    });
    return routes;
}

module.exports = function(app, data) {
    let usersRouter = require("./users")(data),
        materialsRouter = require("./materials")(data),
        userMaterialsRouter = require("./user-materials")(data),
        profilesRouter = require("./profiles")(data);

    app.use("/api/users", usersRouter);
    app.use("/api/materials", materialsRouter);
    app.use("/api/user-materials", userMaterialsRouter);
    app.use("/api/profiles", profilesRouter);

    let routes = getRoutes(app);
    app.use("/help/routes", (req, res) => {
        return res.send({
            result: routes
        });
    });
};