/* globals Sammy, generalController, userController, toastr */

(function () {
    const app = Sammy(function () {
        this.before({}, () => generalController.updateHeader());

        this.get('#/', sammy => sammy.redirect('#/home'));
        this.get('#/home', generalController.loadHome);

        this.get('#/user/sign-in', generalController.loadSignInPage);
        this.get('#/user/sign-up', generalController.loadSignUpPage);

        // User Controllers
        this.put('#/user/sign-in', userController.signIn);
        this.post('#/user/sign-up', userController.signUp);
        this.get('#/user/sign-out', userController.signOut);
        this.get('#/user/my-cookie', userController.loadHourlyCookiePage);

        this.post('#/cookie/reshare/:id', userController.reshareCookie);
        this.post('#/cookie/:type/:id', userController.rateCookie);
    });

    $(function () {
        app.run('#/');

        // Update rating dynamically
        $('#content').on('click', '.btn-like, .btn-dislike', (ev) => {
            let isLoggedIn = localStorage.getItem('authKey') ? true : false;

            if (!isLoggedIn) {
                toastr.error('You must be logged in to rate a cookie');
                return;
            }

            let $target = $(ev.target);

            let splitHtml = $target.html().split(':');
            let rateType = splitHtml[0].trim();
            let currentRating = splitHtml[1].trim();

            $target.html(`${rateType}: ${+currentRating + 1}`);
        })
    });
} ());