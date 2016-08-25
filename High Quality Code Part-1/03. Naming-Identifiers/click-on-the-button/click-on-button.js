function buttonClick(event, otherArguments) {
    var myWindow = window,
        browser = myWindow.navigator.appCodeName,
        isMozzila = (browser == "Mozilla");

    if (isMozzila) {
        alert("Yes");
    } else {
        alert("No");
    }
}