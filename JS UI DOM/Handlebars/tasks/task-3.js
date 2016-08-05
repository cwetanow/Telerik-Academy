function solve(){
  return function(){
    $.fn.listview = function(data){
      var element=$(this);
      var template = $('#'+element.attr('data-template')).html();
      listTemplate = handlebars.compile(template);

      for (var i = 0, len=data.length; i < len; i+=1) {
        this.append(listTemplate(data[i]));
      }
      return this;
    };
  };
}

module.exports = solve;
