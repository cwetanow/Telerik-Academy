let templates = {
    get: (templateName) => {
        let url = `/scripts/templates/${templateName}.html`;

        return requester.get(url);
    }
};