<div class="page">

<div id="preview-page" class="preview-page" data-autorefresh-url="">

<div role="main" class="main-content">

<div class="container new-discussion-timeline experiment-repo-nav">

<div class="repository-content">

<div id="readme" class="readme boxed-group clearfix announce instapaper_body md">

### <span class="octicon octicon-book"></span>Gold fever

<article class="markdown-body entry-content" itemprop="text" id="grip-content">

# [<span aria-hidden="true" class="octicon octicon-link"></span>](#gold-fever)Gold fever

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#description)Description

[Dim4ou](https://www.youtube.com/watch?v=r7jR_xf-kGw) is a famous BG rapper who was one day accidentally hit by a thunderbolt. From that day on Dim4ou started seeing everything in numbers, but not in black and green as Neo from the Matrix and instead in black and yellow (as [Wiz Khalifa](https://www.youtube.com/watch?v=UePtoxDhJSw)). What Dim4ou encountered is that these numbers are actually the price of gold ([$](https://www.youtube.com/watch?v=5cn_fdCkZlc)).

As he knows the price of gold ounce for the next **N** days you need to help him maximize the potential profit. What you can do on each day is to either buy one ounce, sell any number of ounces that you already own, or not make any transaction at all. Your end goal is to calculate the maximum profit you and Dim4ou can obtain with an optimal trading strategy.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#input)Input

*   Input is read from the console
    *   On the first line in the console is a number **N** denoting the **N** days for which you will know the price per ounce.
    *   The second line contains **N** integers separated by white space, denoting the predicted price per gold ounce for the next **N** days.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#output)Output

*   Output should be printed on the console
    *   A single line denoting the maximum profit which can be obtained.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#constraints)Constraints

*   1 <= N <= 50000
*   1 <= price per ounce <= 100000
*   **Time limit**: **0.1s**
*   **Memory limit**: **16 MB**

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-tests)Sample tests

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-1)Sample test 1

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-1)Input

```
4
1 2 1 2

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-1)Output

```
2

```

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-2)Sample test 2

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-2)Input

```
3
10 7 5

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-2)Output

```
0

```

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-test-3)Sample test 3

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-3)Input

```
3
1 3 200

```

#### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-3)Output

```
396

```

</article>

</div>

</div>

</div>

</div>

</div>

</div>

<script>function showCanonicalImages() { var images = document.getElementsByTagName('img'); if (!images) { return; } for (var index = 0; index < images.length; index++) { var image = images[index]; if (image.getAttribute('data-canonical-src') && image.src !== image.getAttribute('data-canonical-src')) { image.src = image.getAttribute('data-canonical-src'); } } } function scrollToHash() { if (location.hash && !document.querySelector(':target')) { var element = document.getElementById('user-content-' + location.hash.slice(1)); if (element) { element.scrollIntoView(); } } } function autorefreshContent(eventSourceUrl) { var initialTitle = document.title; var contentElement = document.getElementById('grip-content'); var source = new EventSource(eventSourceUrl); var isRendering = false; source.onmessage = function(ev) { var msg = JSON.parse(ev.data); if (msg.updating) { isRendering = true; document.title = '(Rendering) ' + document.title; } else { isRendering = false; document.title = initialTitle; contentElement.innerHTML = msg.content; showCanonicalImages(); } } source.onerror = function(e) { if (e.readyState === EventSource.CLOSED && isRendering) { isRendering = false; document.title = initialTitle; } } } window.onhashchange = function() { scrollToHash(); } window.onload = function() { scrollToHash(); } showCanonicalImages(); var autorefreshUrl = document.getElementById('preview-page').getAttribute('data-autorefresh-url'); if (autorefreshUrl) { autorefreshContent(autorefreshUrl); }</script>