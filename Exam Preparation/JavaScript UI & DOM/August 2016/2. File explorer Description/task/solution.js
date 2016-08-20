/// <reference path="typings\index.d.ts" />

function solve() {
    return function (fileContentsByName) {
        var $itemsList = $('.items');

        var $dirItems = $('.dir-item');

        var $addBtn = $('.add-btn');
        var $input = $('[type="text"]');

        var $fileContent = $('.file-content');

        $addBtn.on('click', function () {
            $addBtn.removeClass('visible');
            $input.addClass('visible');
        });

        $input.on('keydown', function (ev) {
            if (ev.which === 13) {
                var inputVal = $input.val();

                var $itemContainer = $('<li class="file-item item"/>');

                var $itemName = $('<a class="item-name"/>');

                var $delBtn = $('<a class="del-btn"/>');

                $itemContainer.append($itemName);
                $itemContainer.append($delBtn);

                $input.val('');
                fileContentsByName[inputVal] = '';

                $input.removeClass('visible');
                $addBtn.addClass('visible');

                if (inputVal.includes('/')) {
                    var dirName = inputVal.split('/')[0];

                    var fileName = inputVal.split('/')[1];
                    $itemName.html(fileName);

                    var $allDirNames = $('.item-name');

                    for (var i = 0; i < $allDirNames.length; i += 1) {
                        if ($($allDirNames[i]).html() === dirName) {
                            $($allDirNames[i]).next().append($itemContainer);
                        }
                    }

                } else {
                    $itemName.html(inputVal);
                    
                    $itemsList.append($itemContainer);
                }
            }
        });

        $itemsList.on('click', '.item', function (ev) {
            var $this = $(this);
            var $target = $(ev.target);

            if ($target.hasClass('del-btn')) {
                $this.remove();
            } else if ($target.hasClass('item-name')) {
                var content = fileContentsByName[$target.html()];

                $fileContent.text(content);
            }
        });

        $dirItems.on('click', function () {
            var $this = $(this);

            if ($this.hasClass('collapsed')) {
                $this.removeClass('collapsed');
            } else {
                $this.addClass('collapsed');
            }
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}