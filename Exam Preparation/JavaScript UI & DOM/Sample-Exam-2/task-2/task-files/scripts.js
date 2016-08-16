/// <reference path="typings/index.d.ts" />

$.fn.tabs = function () {
    var $tabsContent = $('.tab-item-content').css({
        display: 'none',
        position: 'absolute',
        width: '370px',
        height: '250px',
        bottom: '5px',
        left: '5px',
        textAlign: 'left'
    });

    var $tabItems = $('.tab-item').css({
        float: 'left',
        padding: '10px',
        border: '1px solid black',
        borderTop: 'none',
        width: '14.5%',
        textAlign: 'center',
        backgroundColor: 'white'
    });

    var leftTab = $tabItems.first();
    $(leftTab).css('border-left', '0');

    var rightTab = $tabItems.last();
    $(rightTab).css('border-right', '0');

    var $tabsContainer = $('#tabs-container').css({
        border: '1px solid black',
        width: '400px',
        height: '300px',
        borderRadius: '10px',
        position: 'relative',
        backgroundColor: '#CCCCCC'
    });

    var $selected;
    var $currTab;

    $tabsContainer.on('click', function (ev) {
        var $target = $(ev.target);

        if ($target.hasClass('tab-item') ||
            $target.parents('.tab-item').length) {

            if ($selected) {
                $selected.css('display', 'none');
            }

            if ($currTab) {
                $currTab.css({
                    borderBottom: '1px solid black',
                    backgroundColor: 'white'
                });
            }

            var $tab;
            var $container;

            if ($target.find('.tab-item-content').length) {
                $tab = $target;
                $container = $target.find('.tab-item-content');
            } else {
                $tab = $target.parents('.tab-item');
                $container = $target.parents('.tab-item').find('.tab-item-content');
            }

            $tab.css({
                borderBottom: 'none',
                backgroundColor: '#CCCCCC'
            });

            $container.css('display', 'block');

            $currTab = $tab;
            $selected = $container;
        }
    });
};