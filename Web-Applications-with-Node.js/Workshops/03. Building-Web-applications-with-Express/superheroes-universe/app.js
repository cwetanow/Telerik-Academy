const express = require('express'),
    session = require('express-session'),
    cookieParser = require('cookie-parser'),
    bodyParser = require('body-parser');

const app = express();

app.set("view engine", "pug");

app.use("/static", express.static("public"));

app.use(cookieParser()); // session will be maintained via cookies
app.use(bodyParser.urlencoded({
    extended: true
})); // html forms send credentials in urlencoded by default
app.use(session({
    secret: 'purple unicorn'
})); // middleware that manages sessions

const config = require("./config");

const data = require("./data")(config);

require('./config/passport')(app, data);
require("./routers")(app, data);

app.listen(config.port, () => {
    console.log(`App is on port ${config.port}`);
});