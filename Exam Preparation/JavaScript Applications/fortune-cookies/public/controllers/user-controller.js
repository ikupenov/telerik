/* globals userModel, templateHandler, toastr */

const userController = (function () {
    function signIn(sammy) {
        const username = sammy.params.username;
        const password = sammy.params.password;

        userModel.signIn(username, password)
            .then(() => {
                toastr.success("You have signed in successfully.");
                sammy.redirect('#/');
            })
            .catch(error => toastr.error(error.responseText));
    }

    function signUp(sammy) {
        const username = sammy.params.username;
        const password = sammy.params.password;

        userModel.signUp(username, password)
            .then(() => {
                toastr.success("You have signed up successfully.");
                sammy.redirect('#/user/sign-in');
            })
            .catch(error => toastr.error(error.responseText));
    }

    function signOut(sammy) {
        userModel.signOut()
            .then(() => {
                toastr.success("You have signed out successfully.");
                sammy.redirect('#/');
            }).catch(error => toastr.error(error.responseText));
    }

    function loadHourlyCookiePage() {
        userModel.getHourlyCookie()
            .then(cookie => {
                cookie = cookie.result;
                templateHandler.setTemplate('cookies-gallery', '#content', [cookie]);
            });
    }

    function rateCookie(sammy) {
        const rateType = sammy.params.type;
        const cookieId = sammy.params.id;

        userModel.rateCookie(rateType, cookieId);
    }

    function reshareCookie(sammy) {
        const cookieId = sammy.params.id;
        userModel.reshareCookie(cookieId)
            .then(() => toastr.success('Cookie re-shared successfully.'));
    }

    return {
        signIn,
        signUp,
        signOut,
        rateCookie,
        reshareCookie,
        loadHourlyCookiePage
    }
} ());