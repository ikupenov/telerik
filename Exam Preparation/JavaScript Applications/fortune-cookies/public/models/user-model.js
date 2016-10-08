/* globals encryptor, requester, Promise, toastr */

const userModel = (function () {
    function signIn(username, password) {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (isLoggedIn) {
            toastr.error("You're already logged in.");
            return;
        }

        let passwordHash = encryptor.encrypt(password);
        return requester.signInUser(username, passwordHash)
            .then(userInfo => {
                userInfo = userInfo.result;
                localStorage.setItem('authKey', userInfo.authKey);
                localStorage.setItem('username', userInfo.username);

                return userInfo;
            });
    }

    function signUp(username, password) {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (isLoggedIn) {
            toastr.error("You're already logged in.");
            return;
        }

        let passwordHash = encryptor.encrypt(password);

        return requester.signUpUser(username, passwordHash);
    }

    function signOut() {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (!isLoggedIn) {
            toastr.error("You're already signed out.");
            return;
        }

        return new Promise((resolve) => {
            localStorage.removeItem('authKey');
            localStorage.removeItem('username');
            resolve();
        });
    }

    function getHourlyCookie() {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (!isLoggedIn) {
            toastr.error('You must be logged in to view your hourly cookie!');
            return;
        }

        return requester.getHourlyCookie();
    }

    function rateCookie(rateType, cookieId) {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (!isLoggedIn) {
            toastr.danger('You must be logged in to rate a cookie.');
            return;
        }

        return requester.rateCookie(rateType, cookieId);
    }

    function reshareCookie(cookieId) {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        if (!isLoggedIn) {
            toastr.danger('You must be logged in to re-share a cookie.');
            return;
        }

        return requester.reshareCookie(cookieId);
    }

    return {
        signIn,
        signUp,
        signOut,
        rateCookie,
        reshareCookie,
        getHourlyCookie
    }
} ());