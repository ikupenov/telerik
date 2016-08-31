function CheckCurrentBrowser(browserName) {
    var browser = window.navigator.appCodeName,
        isCorrectBrowser = browser === browserName;

    if (isCorrectBrowser) {
        alert("Yes");
    } else {
        alert("No");
    }
}