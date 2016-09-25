import { data } from './data.js';
import { loader } from './template-loader.js';

let router = (() => {
    let navigo;

    function init() {
        navigo = new Navigo(null, false);
        navigo            
            .on('/threads/:id', (params) => {
                Promise.all([data.threads.getById(params.id), loader.get('thread')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').append(html);
                    })
                    .catch(console.log);
            })
            .on('/gallery', () => {
                Promise.all([data.gallery.get(), loader.get('gallery')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('/threads', () => {
                Promise.all([data.threads.get(), loader.get('threads')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('', () => {

            })
            .resolve();
    }

    return {
        init
    };
})();

export {router};