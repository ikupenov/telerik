/// <reference path="typings\index.d.ts" />

(function () {
    /* globals Promise */

    let promise = new Promise((resolve, reject) => {
        let $msgWrapper = $('#msg-wrapper');
        let $msgTitle = $('#msg-title');
        let $msgContainer = $('#msg-container');
        let $message = { wrapper: $msgWrapper, title: $msgTitle, container: $msgContainer };

        if ($message.wrapper && $message.container) {
            resolve($message);
        } else {
            reject('Element not found!');
        }
    });

    function openMsg(msgTitle, msgText) {
        promise.then(msg => {
            let $msgWrapper = msg.wrapper;
            $msgWrapper.animate({
                opacity: 1,
                top: '0.5em',
            }, 750);

            let $msgTitle = msg.title;
            $msgTitle.text(msgTitle);

            let $msgContainer = msg.container;
            $msgContainer.text(msgText);

            return msg;
        }).then(msg => {
            let $msgWrapper = msg.wrapper;

            setTimeout(() => {
                $msgWrapper.animate({
                    opacity: 0,
                    top: '-5em',
                }, 500);
            }, 2000);

            return msg;
        }).catch(errMsg => { throw new Error(errMsg) });
    }

    openMsg('Message Title!', 'Message text.');
} ());