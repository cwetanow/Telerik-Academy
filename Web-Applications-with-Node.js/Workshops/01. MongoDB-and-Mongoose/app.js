const employeeSchema = require('./models/employee-model');

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/TelerikEmployees');

const db = mongoose.connection;

db.once('open', () => {
    console.log('Connection is open');
});

let Employee = mongoose.model('Employee', employeeSchema);

const importer = require('./json-importer');

let employees = importer('data.json');

employees.forEach((employee) => {
    console.log(employee);
    let empl = new Employee(employee);
    empl.save((err) => {
        if (err) {
            console.log(err);
        }
    });
}, this);