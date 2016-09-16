window.alert("You will be redirected");

(function () {
    let promise = new Promise((resolve, reject) => {
        setTimeout(function (resolve) {
            window.location = "http://telerikacademy.com";
        }, 2000);
    });
})();