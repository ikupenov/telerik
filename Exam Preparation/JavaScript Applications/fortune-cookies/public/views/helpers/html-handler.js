/* globals Promise, */

const htmlHandler = (function () {
    function getHtml(htmlName) {
        return new Promise((resolve, reject) => {
            const htmlUrl = `views/${htmlName}.html`;

            $.get(htmlUrl)
                .done(resolve)
                .fail(reject);
        });
    }

    function setHtml(htmlName, selector) {
        return getHtml(htmlName)
            .then(html => {
                let $htmlWrapper = $('<div class="html-wrapper"/>');
                $htmlWrapper.html(html);

                $(selector).html($htmlWrapper.html());

                return $htmlWrapper;
            });
    }

    return {
        getHtml, setHtml
    };
} ());