/* globals Promise, Handlebars */

const templateHandler = (function () {
    function getTemplate(templateName) {
        return new Promise((resolve, reject) => {
            const templateUrl = `views/templates/${templateName}.handlebars`;

            $.get(templateUrl)
                .done(resolve)
                .fail(reject);
        });
    }

    function setTemplate(templateName, selector, dataObject) {
            return getTemplate(templateName)
                .then(template => {
                    let compiledTemplate = Handlebars.compile(template);
                    let templateHtml = compiledTemplate(dataObject);
                    let $templateWrapper = $('<div class="template-wrapper"/>');

                    $templateWrapper.html(templateHtml);
                    $(selector).html($templateWrapper.html());

                    return $templateWrapper;
                });
    }

    return {
        getTemplate, setTemplate
    }
} ());