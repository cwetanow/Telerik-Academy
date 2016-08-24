var expect = require('chai').expect;
var jsdom = require('jsdom');
var jq = require('jquery');
var result = require('../task/solution.js')();
var hb = require('handlebars');

describe('Forum task', function() {
	before(function(done) {
		jsdom.env({
			html: '',
			done: function(errors, window) {
				global.window = window;
				global.document = window.document;
				global.$ = jq(window);
				Object.keys(window)
					.filter(function(prop) {
						return prop.toLowerCase()
							.indexOf('html') >= 0;
					}).forEach(function(prop) {
						global[prop] = window[prop];
					});
				done();
			}
		});
	});

	describe('Sample tests', function() {
		it('Sample test 1', function() {
			document.body.innerHTML = '<div id="root"></div>';
			var jQueryDummy = $;
			$ = jQuery = undefined;
			var template = hb.compile(result());
			$ = jQuery = jQueryDummy;

			var data = {
				title: 'Conspiracy Theories',
				posts: [{
					author: '',
					text: 'Dear God,',
					comments: [{
						author: 'G',
						text: 'Yes, my child?'
					}, {
						author: '',
						text: 'I would like to file a bug report.'
					}]
				}, {
					author: 'Cuki',
					text: '<a href="https://xkcd.com/258/">link</a>',
					comments: []
				}]
			};

			var $root = $('#root');
			$root.html(template(data));

			function structureTestLevel0($root, data) {
				expect($root.children().length).to.equal(2);
				expect($root.children()[0].tagName).to.equal('H1');
				expect($root.children()[1].tagName).to.equal('UL');
				var $posts = $root.children('ul').children();
				expect($posts.length).to.equal(data.posts.length);
			}
			function structureTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					expect($post.length).to.equal(1);
					expect($post.children().length).to.equal(2);
					expect($post.children()[0].tagName).to.equal('P');
					expect($post.children()[1].tagName).to.equal('PRE');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var commentCount = data.posts[i].comments.length;
						data.posts[i].comments.forEach(function(z) {
							if(z.deleted) {
								--commentCount;
							}
						});
						expect($comments.length).to.equal(commentCount);
					}
				});
			}
			function structureTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							expect($comment.length).to.equal(1);
							expect($comment.children().length).to.equal(2);
							expect($comment.children()[0].tagName).to.equal('P');
							expect($comment.children()[1].tagName).to.equal('PRE');
						});
					}
				});
			}

			function attributeTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					expect($post.hasClass('post')).to.be.true;
					expect($post.children('p').hasClass('author')).to.be.true;
					if(data.posts[i].author) {
						expect($post.children('p').children('a').hasClass('user')).to.be.true;
						expect($post.children('p').children('a').hasClass('anonymous')).to.be.false;
						expect($post.children('p').children('a').attr('href')).to.equal('/user/' + data.posts[i].author);
					}
					else {
						expect($post.children('p').children('a').hasClass('user')).to.be.false;
						expect($post.children('p').children('a').hasClass('anonymous')).to.be.true;
						expect($post.children('p').children('a').attr('href')).to.be.undefined;
					}
					expect($post.children('pre').hasClass('content')).to.be.true;
				});
			}

			function attributeTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var comments = data.posts[i].comments.filter(function(z) {
							return !z.deleted;
						});
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							expect($comment.hasClass('comment')).to.be.true;
							expect($comment.children('p').hasClass('author')).to.be.true;
							if(comments[j].author) {
								expect($comment.children('p').children('a').hasClass('user')).to.be.true;
								expect($comment.children('p').children('a').hasClass('anonymous')).to.be.false;
								expect($comment.children('p').children('a').attr('href')).to.equal('/user/' + comments[j].author);
							}
							else {
								expect($comment.children('p').children('a').hasClass('user')).to.be.false;
								expect($comment.children('p').children('a').hasClass('anonymous')).to.be.true;
								expect($comment.children('p').children('a').attr('href')).to.be.undefined;
							}
							expect($comment.children('pre').hasClass('content')).to.be.true;
						});
					}
				});
			}

			function contentTestLevel0($root, data) {
				var title = data.title
					.replace(/&/g, '&amp;')
					.replace(/</g, '&lt;')
					.replace(/>/g, '&gt;');
				expect($root.children('h1').html()).to.equal(title);
			}

			function contentTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					var $p = $post.children('p');
					var author = (data.posts[i].author || 'Anonymous')
						.replace(/&/g, '&amp;')
						.replace(/</g, '&lt;')
						.replace(/>/g, '&gt;');
					expect($p.children('a').html()).to.equal(author);
					expect($post.children('pre').html()).to.equal(data.posts[i].text);
				});
			}

			function contentTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					var $p = $post.children('p');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var comments = data.posts[i].comments.filter(function(z) {
							return !z.deleted;
						});
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							var $p = $comment.children('p');
							var author = (comments[j].author || 'Anonymous')
								.replace(/&/g, '&amp;')
								.replace(/</g, '&lt;')
								.replace(/>/g, '&gt;');
							expect($p.children('a').html()).to.equal(author);
							expect($comment.children('pre').html()).to.equal(comments[j].text);
						});
					}
				});
			}

			structureTestLevel0($root, data);
			structureTestLevel1($root, data);
			structureTestLevel2($root, data);

			attributeTestLevel1($root, data);
			attributeTestLevel2($root, data);

			contentTestLevel0($root, data);
			contentTestLevel1($root, data);
			contentTestLevel2($root, data);
		});

		it('Sample test 2', function() {
			document.body.innerHTML = '<div id="root"></div>';
			var jQueryDummy = $;
			$ = jQuery = undefined;
			var template = hb.compile(result());
			$ = jQuery = jQueryDummy;

			var data = {
				title: 'JS UI & DOM 2016',
				posts: [{
					author: 'Cuki',
					text: 'Hello guys',
					comments: [{
						author: 'Kon',
						text: 'Hello'
					}, {
						text: 'Hello'
					}]
				}, {
					author: 'Cuki',
					text: 'This works',
					comments: [{
						author: 'Cuki',
						text: 'Well, ofcourse!\nRegards'
					}, {
						text: 'You are fat',
						deleted: true
					}]
				}, {
					author: 'Pesho',
					text: 'Is anybody out <a href="https://facebook.com/">there</a>?',
					comments: []
				}]
			};

			var $root = $('#root');
			$root.html(template(data));

			function structureTestLevel0($root, data) {
				expect($root.children().length).to.equal(2);
				expect($root.children()[0].tagName).to.equal('H1');
				expect($root.children()[1].tagName).to.equal('UL');
				var $posts = $root.children('ul').children();
				expect($posts.length).to.equal(data.posts.length);
			}
			function structureTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					expect($post.length).to.equal(1);
					expect($post.children().length).to.equal(2);
					expect($post.children()[0].tagName).to.equal('P');
					expect($post.children()[1].tagName).to.equal('PRE');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var commentCount = data.posts[i].comments.length;
						data.posts[i].comments.forEach(function(z) {
							if(z.deleted) {
								--commentCount;
							}
						});
						expect($comments.length).to.equal(commentCount);
					}
				});
			}
			function structureTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							expect($comment.length).to.equal(1);
							expect($comment.children().length).to.equal(2);
							expect($comment.children()[0].tagName).to.equal('P');
							expect($comment.children()[1].tagName).to.equal('PRE');
						});
					}
				});
			}

			function attributeTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					expect($post.hasClass('post')).to.be.true;
					expect($post.children('p').hasClass('author')).to.be.true;
					if(data.posts[i].author) {
						expect($post.children('p').children('a').hasClass('user')).to.be.true;
						expect($post.children('p').children('a').hasClass('anonymous')).to.be.false;
						expect($post.children('p').children('a').attr('href')).to.equal('/user/' + data.posts[i].author);
					}
					else {
						expect($post.children('p').children('a').hasClass('user')).to.be.false;
						expect($post.children('p').children('a').hasClass('anonymous')).to.be.true;
						expect($post.children('p').children('a').attr('href')).to.be.undefined;
					}
					expect($post.children('pre').hasClass('content')).to.be.true;
				});
			}

			function attributeTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var comments = data.posts[i].comments.filter(function(z) {
							return !z.deleted;
						});
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							expect($comment.hasClass('comment')).to.be.true;
							expect($comment.children('p').hasClass('author')).to.be.true;
							if(comments[j].author) {
								expect($comment.children('p').children('a').hasClass('user')).to.be.true;
								expect($comment.children('p').children('a').hasClass('anonymous')).to.be.false;
								expect($comment.children('p').children('a').attr('href')).to.equal('/user/' + comments[j].author);
							}
							else {
								expect($comment.children('p').children('a').hasClass('user')).to.be.false;
								expect($comment.children('p').children('a').hasClass('anonymous')).to.be.true;
								expect($comment.children('p').children('a').attr('href')).to.be.undefined;
							}
							expect($comment.children('pre').hasClass('content')).to.be.true;
						});
					}
				});
			}

			function contentTestLevel0($root, data) {
				var title = data.title
					.replace(/&/g, '&amp;')
					.replace(/</g, '&lt;')
					.replace(/>/g, '&gt;');
				expect($root.children('h1').html()).to.equal(title);
			}

			function contentTestLevel1($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					var $p = $post.children('p');
					var author = (data.posts[i].author || 'Anonymous')
						.replace(/&/g, '&amp;')
						.replace(/</g, '&lt;')
						.replace(/>/g, '&gt;');
					expect($p.children('a').html()).to.equal(author);
					expect($post.children('pre').html()).to.equal(data.posts[i].text);
				});
			}

			function contentTestLevel2($root, data) {
				var $posts = $root.children('ul').children();
				$posts.each(function(i, x) {
					x = $(x);
					var $post = x.children('div');
					var $p = $post.children('p');
					if(data.posts[i].comments.length > 0) {
						var $comments = x.children('ul').children('li');
						var comments = data.posts[i].comments.filter(function(z) {
							return !z.deleted;
						});
						$comments.each(function(j, y) {
							y = $(y);
							var $comment = y.children('div');
							var $p = $comment.children('p');
							var author = (comments[j].author || 'Anonymous')
								.replace(/&/g, '&amp;')
								.replace(/</g, '&lt;')
								.replace(/>/g, '&gt;');
							expect($p.children('a').html()).to.equal(author);
							expect($comment.children('pre').html()).to.equal(comments[j].text);
						});
					}
				});
			}

			structureTestLevel0($root, data);
			structureTestLevel1($root, data);
			structureTestLevel2($root, data);

			attributeTestLevel1($root, data);
			attributeTestLevel2($root, data);

			contentTestLevel0($root, data);
			contentTestLevel1($root, data);
			contentTestLevel2($root, data);
		});
	});
});
