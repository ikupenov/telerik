/// <reference path="typings/index.d.ts" />

$.fn.tabs = function () {
    var $tabsContent = $('.tab-item-content').css('display', 'none')
        .css('position', 'absolute')
        .css('width', '370px')
        .css('height', '250px')
        .css('bottom', '5px')
        .css('left', '5px')
        .css('text-align', 'left');

    var $tabItems = $('.tab-item')
        .css('float', 'left')
        .css('padding', '10px')
        .css('border', '1px solid black')
        .css('border-top', 'none')
        .css('width', '14.5%')
        .css('text-align', 'center')
        .css('background-color', 'white');

    var leftTab = $tabItems.first();
    $(leftTab).css('border-left', '0');

    var rightTab = $tabItems.last();
    $(rightTab).css('border-right', '0');

    var $tabsContainer = $('#tabs-container')
        .css('border', '1px solid black')
        .css('width', '400px')
        .css('height', '300px')
        .css('border-radius', '10px')
        .css('position', 'relative')
        .css('background-color', '#CCCCCC');

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
                $currTab.css('border-bottom', '1px solid black');
                $currTab.css('background-color', 'white');
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

            $tab.css('border-bottom', 'none')
                .css('background-color', '#CCCCCC');

            $container.css('display', 'block');

            $currTab = $tab;
            $selected = $container;
        }
    });
};