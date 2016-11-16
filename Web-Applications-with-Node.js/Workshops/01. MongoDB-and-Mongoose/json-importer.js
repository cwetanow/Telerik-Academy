const fs = require('fs');

const importer = (filePath) => {
    let fileContents = fs.readFileSync(filePath, 'utf8');

    return JSON.parse(fileContents);
};

module.exports = importer;