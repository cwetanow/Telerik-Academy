(function () {
    let promise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                resolve(position);
            },
            (error) => {
                reject(error);
            }
        );
    });

    let parseCoordinates = (locationObj) => {

        return {
            lat: locationObj.coords.latitude,
            long: locationObj.coords.longitude
        };

    };

    let createImage = (locations) => {
        let img = document.getElementById('map'),
            imgSrc = `http://maps.googleapis.com/maps/api/staticmap?center=${locations.lat},${locations.long}&zoom=17&size=500x500&sensor=false`;

        img.setAttribute('src', imgSrc);
    };

    promise
        .then(parseCoordinates)
        .then(createImage)
        .catch();
})();