var getUrl = function getUrl(genre, page) {
    return `http://www.imdb.com/search/title?genres=${genre}&title_type=feature&0sort=moviemeter,asc&page=${page + 1}&view=simple&ref_=adv_nxt`
}

module.exports = {
    getUrl(genre, page) {
        return getUrl(genre, page);
    }
}