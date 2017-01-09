<div class="page">

<div id="preview-page" class="preview-page" data-autorefresh-url="">

<div role="main" class="main-content">

<div class="container new-discussion-timeline experiment-repo-nav">

<div class="repository-content">

<div id="readme" class="readme boxed-group clearfix announce instapaper_body md">

### <span class="octicon octicon-book"></span>Player ranking

<article class="markdown-body entry-content" itemprop="text" id="grip-content">

# [<span aria-hidden="true" class="octicon octicon-link"></span>](#player-ranking)Player ranking

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#description)Description

You are implementing a player ranking system. Each player has a name, type, age and current position. The ranking system should be able to add new players, find all players of certain type and get the ranking in some range (start and end positions).

You are given a sequence of commands that must be implemented:

*   **add PLAYER_NAME PLAYER_TYPE PLAYER_AGE PLAYER_POSITION** - adds new player to the rank list
    *   **PLAYER_NAME** can be any sequence from 1 to 20 characters and may not be unique
    *   **PLAYER_TYPE** can be any sequence from 1 to 10 characters and may not be unique
    *   **PLAYER_AGE** can be any integer between 10 and 50
    *   **PLAYER_POSITION** can be any integer between 1 and the current players count plus one (e.g. if the ranking system already has 2 players, **PLAYER_POSITION** can be 1, 2 or 3). If a player is inserted to an already used position, all players' positions from this position till the end are incremented by one (e.g. if the ranking system has Player1 in poistion 1, Player2 in position 2 and is inserting Player3 in position 1 => Player1 goes to position 2 and Player2 goes to position 3).
    *   Print **"Added player PLAYER_NAME to position PLAYER_POSITION"**
*   **find PLAYER_TYPE** - finds the top 5 units, first ordered by name in ascending order and then by age in descending order
    *   Print the results in the following format **"Type PLAYER_TYPE: PLAYER; PLAYER; PLAYER"** where **PLAYER** should be printed in the format **"PLAYER_NAME(PLAYER_AGE)"**. If no players are found just print **"Type PLAYER_TYPE: "** (ending whit one space).
*   **ranklist START END** - prints the rank list from **START** to **END** positions
    *   **START** can be any integer between 1 and current players count.
    *   **END** can be any integer between 1 and current players count (and will be greater than or equal to **START**).
*   **end** - marks the end of the commands and no other commands will follow afterwards.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#input)Input

*   Input is read from the console
    *   The input consists of a sequence of commands, each at a separate line, ending by the command **"end"**. The commands will be valid (as described in the above list), in the specified format, within the constraints given below. **There is no need to check the input data explicitly.**

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#output)Output

*   Output should be printed on the console
    *   For each command from the input sequence print at the standard output its results as a single line.

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#constraints)Constraints

*   All **PLAYER_NAME** and **PLAYER_TYPE** will consist of letters and digits only. No spaces are allowed.
*   The total number of lines in the input will be in the range [1 ... 100000].
*   **Time limit**: **1.3s**
*   **Memory limit**: **96 MB**

## [<span aria-hidden="true" class="octicon octicon-link"></span>](#sample-tests)Sample tests

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#input-1)Input

```
add Ivan Aggressive 20 1
add Pesho Defensive 25 2
add Georgi Neutral 30 3
add Stamat Aggressive 22 2
add Stamat Aggressive 40 1
find Aggressive
ranklist 1 5
add Pencho Neutral 33 2
find Neutral
ranklist 1 3
end

```

### [<span aria-hidden="true" class="octicon octicon-link"></span>](#output-1)Output

```
Added player Ivan to position 1
Added player Pesho to position 2
Added player Georgi to position 3
Added player Stamat to position 2
Added player Stamat to position 1
Type Aggressive: Ivan(20); Stamat(40); Stamat(22)
1\. Stamat(40); 2\. Ivan(20); 3\. Stamat(22); 4\. Pesho(25); 5\. Georgi(30)
Added player Pencho to position 2
Type Neutral: Georgi(30); Pencho(33)
1\. Stamat(40); 2\. Pencho(33); 3\. Ivan(20)

```

</article>

</div>

</div>

</div>

</div>

</div>

</div>

<script>function showCanonicalImages() { var images = document.getElementsByTagName('img'); if (!images) { return; } for (var index = 0; index < images.length; index++) { var image = images[index]; if (image.getAttribute('data-canonical-src') && image.src !== image.getAttribute('data-canonical-src')) { image.src = image.getAttribute('data-canonical-src'); } } } function scrollToHash() { if (location.hash && !document.querySelector(':target')) { var element = document.getElementById('user-content-' + location.hash.slice(1)); if (element) { element.scrollIntoView(); } } } function autorefreshContent(eventSourceUrl) { var initialTitle = document.title; var contentElement = document.getElementById('grip-content'); var source = new EventSource(eventSourceUrl); var isRendering = false; source.onmessage = function(ev) { var msg = JSON.parse(ev.data); if (msg.updating) { isRendering = true; document.title = '(Rendering) ' + document.title; } else { isRendering = false; document.title = initialTitle; contentElement.innerHTML = msg.content; showCanonicalImages(); } } source.onerror = function(e) { if (e.readyState === EventSource.CLOSED && isRendering) { isRendering = false; document.title = initialTitle; } } } window.onhashchange = function() { scrollToHash(); } window.onload = function() { scrollToHash(); } showCanonicalImages(); var autorefreshUrl = document.getElementById('preview-page').getAttribute('data-autorefresh-url'); if (autorefreshUrl) { autorefreshContent(autorefreshUrl); }</script>