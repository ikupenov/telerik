/* globals templateHandler, requester, toastr */
const generalController = (function () {
    function updateHeader() {
        let isLoggedIn = localStorage.getItem('authKey') ? true : false;

        templateHandler.setTemplate('header', '#header', { isLoggedIn });
    }

    function loadHome(sammy) {
        let searchedCategory = sammy.params.category;

        if (searchedCategory) {
            requester.searchByCategory(searchedCategory)
                .then(cookiesFound => {
                    if (!cookiesFound.length) {
                        toastr.warning('No cookies found.');
                        return;
                    }

                    templateHandler.setTemplate('cookies-gallery', '#content', cookiesFound);
                });
        } else {
            requester.getCookies()
                .then(cookies => {
                    cookies = cookies.result;
                    templateHandler.setTemplate('cookies-gallery', '#content', cookies);
                });
        }
    }

    function loadSignInPage() {
        templateHandler.setTemplate('sign-up_sign-in', '#content', { isSignInForm: true });
    }

    function loadSignUpPage() {
        templateHandler.setTemplate('sign-up_sign-in', '#content', { isSignInForm: false });
    }

    return {
        updateHeader,
        loadHome,
        loadSignInPage,
        loadSignUpPage,
    }
} ());