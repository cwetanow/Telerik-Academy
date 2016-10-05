/* globals require, console */

"use strict";

let dbFactory = require("./db");

let dataService = require("./data")(dbFactory.getDb());

const app = require("./config/express")(dataService);

require("./routers")(app, dataService);

let port = require("./config").port;

app.listen(port, () => console.log(`App running at http://localhost:${port}/`));
