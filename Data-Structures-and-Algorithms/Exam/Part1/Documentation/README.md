<div class="page">

<div id="preview-page" class="preview-page" data-autorefresh-url="">

<div role="main" class="main-content">

<div class="container new-discussion-timeline experiment-repo-nav">

<div class="repository-content">

<div id="readme" class="readme boxed-group clearfix announce instapaper_body md">

### <span class="octicon octicon-book"></span>Documentation

<article class="markdown-body entry-content" itemprop="text" id="grip-content">

# [<span aria-hidden="true" class="octicon octicon-link"></span>](#documentation)Documentation

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#description)Description

Coki is a developer who loves doing pranks. The newest one he wants to try is to transform the documentations which his colleagues write into [palindromes](https://en.wikipedia.org/wiki/Palindrome) (from Wikipedia: A palindrome is a word, phrase, number, or other sequence of characters which reads the same backward or forward, such as madam or kayak.).

To do this he follows three rules: 1\. He can increase/reduce the value of a letter, e.g. he can change **d** to **e** or change **e** to **d** (the border cases **a** to **z** and **z** to **a** are also allowed). 1\. Capital letters are treated like non-capital letters, e.g. he can change **A** to **b** or change **b** to **A**. 1\. Special characters such as **" "** (white space), **","**, **"."**, **"!"**, **"?"** are disregarded.

Each increase/reduction in the value of a letter is counted as a single operation. Your task is to help Coki find the minimum number of operations required to convert a given documentation text into a palindrome.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#input)Input

*   Input is read from the console
    *   On the single line in the console is the string to be converted.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#output)Output

*   Output should be printed on the console
    *   A single line denoting the number of minimum operations required to convert the string into a palindrome.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#constraints)Constraints

*   1 <= length of string <= 1500000
*   All characters are upper/lower case English letters and the following special characters - **" "** (white space), **","**, **"."**, **"!"**, **"?"**.
*   **Time limit**: **0.07s**
*   **Memory limit**: **32 MB**

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-tests)Sample tests

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-1)Sample test 1

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-1)Input

```
abc

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-1)Output

```
2

```

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-2)Sample test 2

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-2)Input

```
AZ!x

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-2)Output

```
3

```

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-3)Sample test 3

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-3)Input

```
No x in Nixon

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-3)Output

```
0

```

</article>

</div>

</div>

</div>

</div>

</div>

</div>

<script>function showCanonicalImages() { var images = document.getElementsByTagName('img'); if (!images) { return; } for (var index = 0; index < images.length; index++) { var image = images[index]; if (image.getAttribute('data-canonical-src') && image.src !== image.getAttribute('data-canonical-src')) { image.src = image.getAttribute('data-canonical-src'); } } } function scrollToHash() { if (location.hash && !document.querySelector(':target')) { var element = document.getElementById('user-content-' + location.hash.slice(1)); if (element) { element.scrollIntoView(); } } } function autorefreshContent(eventSourceUrl) { var initialTitle = document.title; var contentElement = document.getElementById('grip-content'); var source = new EventSource(eventSourceUrl); var isRendering = false; source.onmessage = function(ev) { var msg = JSON.parse(ev.data); if (msg.updating) { isRendering = true; document.title = '(Rendering) ' + document.title; } else { isRendering = false; document.title = initialTitle; contentElement.innerHTML = msg.content; showCanonicalImages(); } } source.onerror = function(e) { if (e.readyState === EventSource.CLOSED && isRendering) { isRendering = false; document.title = initialTitle; } } } window.onhashchange = function() { scrollToHash(); } window.onload = function() { scrollToHash(); } showCanonicalImages(); var autorefreshUrl = document.getElementById('preview-page').getAttribute('data-autorefresh-url'); if (autorefreshUrl) { autorefreshContent(autorefreshUrl); }</script>