module.exports = {
    connectionString: "mongodb://localhost/moviesDb",
    genres: ["action", "sci-fi", "fantasy", "horror", "comedy"],
    pagesCount: 1,
    simpleMovieCssSelector: ".col-title span[title] a",
    fullMovieSelector: {
        title: ".title_wrapper h1",
        description: ".plot_summary_wrapper .summary_text",
        cover: ".poster img",
        categories: ".subtext .itemprop",
        cast: "#titleCast tr",
        trailer: ".slate_wrapper .slate a"
    },
    actorSelector: {
        profileImage: "#name-poster",
        name: "#overview-top .header span",
        biography: "#name-bio-text .inline",
        moviesName: "#filmography .filmo-category-section:first .filmo-row b a",
        moviesImdbId: "#filmography .filmo-category-section:first .filmo-row b a",
        moviesCharacterName: "#filmography .filmo-category-section:first .filmo-row"
    }
};