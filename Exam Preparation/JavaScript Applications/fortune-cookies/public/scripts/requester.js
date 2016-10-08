/* globals Promise */

const requester = (function () {
    function getCookies() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/cookies')
                .done(resolve)
                .fail(reject);
        });
    }

    function getCookieById(cookieId) {
        return getCookies()
            .then(cookies => {
                cookies = cookies.result;

                let foundCookie = cookies.find(x => x.id === cookieId);
                return foundCookie;
            });
    }

    function shareCookie(cookieText, cookieCategory, cookieImg) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: 'api/cookies',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ text: cookieText, category: cookieCategory, img: cookieImg }),
                headers: {
                    'x-auth-key': localStorage.getItem('authKey')
                }
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function reshareCookie(cookieId) {
        return getCookieById(cookieId)
            .then(cookie => shareCookie(cookie.text, cookie.category, cookie.img));
    }

    function getHourlyCookie() {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: 'api/my-cookie',
                method: 'GET',
                contentType: 'application/json',
                headers: {
                    'x-auth-key': localStorage.getItem('authKey')
                }
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function rateCookie(rateType, cookieId) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: `api/cookies/${cookieId}`,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({ type: rateType }),
                headers: {
                    'x-auth-key': localStorage.getItem('authKey')
                }
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function signInUser(username, passHash) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: 'api/auth',
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({ username, passHash })
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function signUpUser(username, passHash) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: 'api/users',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ username, passHash })
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function searchByCategory(searchedCategory) {
        return getCookies()
            .then(cookies => {
                cookies = cookies.result;

                let cookiesFound = cookies.filter(x => x.category === searchedCategory);
                return cookiesFound;
            }).catch(error => Promise.reject(error));
    }

    return {
        getCookies,
        rateCookie,
        shareCookie,
        reshareCookie,
        signInUser,
        signUpUser,
        getHourlyCookie,
        searchByCategory
    }
} ());