let templates = {
    get: function (templateName) {
        let url = `./templates/${templateName}.html`;
        return requester.get(url);
    }
};

export {
    templates
};