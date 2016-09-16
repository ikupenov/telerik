/* globals Promise */

(function () {
    let getLocationPromise = new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            location => resolve(location.coords),
            error => reject(error)
        )
    });

    getLocationPromise.then(coords => {
        let img = document.getElementById('location-img');

        let latitude = coords.latitude;
        let longitude = coords.longitude;

        let imgUrl = `http://maps.googleapis.com/maps/api/staticmap?center=${latitude},${longitude}&zoom=13&size=500x500&sensor=false`;

        img.src = imgUrl;
        console.log('loaded promise');
    });
} ())