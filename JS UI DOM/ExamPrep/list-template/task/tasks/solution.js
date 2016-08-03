function solve() {
    return function (selector) {
        var template = [
            '{{#each authors}}',
            '<div class="box {{#if right}}right{{/if}}">',
              '<div class="inner">',
                '<p>',
                  '<img alt="{{name}}" src="{{image}}" width="100" height="133">',
                '</p>',
                '<div>',
                '<h3>{{name}}</h3>',
                  '{{#each titles}}',
                    '<p>{{{this}}}</p>',
                  '{{/each}}',
                  '<ul>',
                    '{{#each urls}}',
                    '<li>',
                      '<a href="{{this}}" target="_blank">{{this}}</a>',
                    '</li>',
                    '{{/each}}',
                  '</ul>',
                '</div>',
              '</div>',
            '</div>',
            '{{/each}}'
        ].join('');

        document.getElementById(selector).innerHTML = template;
    }
}

if(typeof module !== 'undefined') {
    module.exports = solve;
}
