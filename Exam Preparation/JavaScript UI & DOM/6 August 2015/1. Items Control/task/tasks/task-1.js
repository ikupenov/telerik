/* globals module, document, HTMLElement, console */

function solve() {
    return function (selector, isCaseSensitive) {
        selector = document.querySelector(selector);
        isCaseSensitive = !!isCaseSensitive;

        selector.className = 'items-control';

        //Adding Elements
        var addingDiv = document.createElement('div');
        addingDiv.className = 'add-controls';

        var textEnter = document.createElement('label');
        textEnter.innerHTML = 'Enter text';
        var inputEnter = document.createElement('input');

        var buttonAdd = document.createElement('button');
        buttonAdd.className = 'button';
        buttonAdd.innerHTML = 'Add';
        buttonAdd.addEventListener('click', addItem);

        addingDiv.appendChild(textEnter);
        addingDiv.appendChild(inputEnter);
        addingDiv.appendChild(buttonAdd);

        selector.appendChild(addingDiv);
        //Adding Elements End

        //Search Elements
        var searchDiv = document.createElement('div');
        searchDiv.className = 'search-controls';

        var textSearch = document.createElement('label');
        textSearch.innerHTML = 'Search:';

        var inputSearch = document.createElement('input');
        inputSearch.addEventListener('input', search);

        searchDiv.appendChild(textSearch);
        searchDiv.appendChild(inputSearch);

        selector.appendChild(searchDiv);
        //Search Elements End

        //Result Elements
        var resultDiv = document.createElement('div');
        resultDiv.className = 'result-controls';

        var resultList = document.createElement('ul');
        resultList.className = 'items-list';

        resultDiv.appendChild(resultList);

        selector.appendChild(resultDiv);
        //Result Elements End

        //Add Item Event
        function addItem() {
            var inputValue = document.createElement('label');
            inputValue.innerHTML = inputEnter.value;
            inputValue.className = 'inner-text';

            var list = resultList;

            var li = document.createElement('li');
            li.className = 'list-item';

            var buttonDelete = document.createElement('button');
            buttonDelete.className = 'button';
            buttonDelete.innerHTML = 'X';

            buttonDelete.addEventListener('click', function (ev) {
                var target = ev.target;
                if (target.parentNode.className === 'list-item') {
                    target.parentNode.parentNode.removeChild(li);
                }
            }, false);

            li.appendChild(inputValue);
            li.appendChild(buttonDelete);

            list.appendChild(li);
        }
        //Add Item Event End

        //Search Item Event 
        function search() {
            var items = resultList.querySelectorAll('li');
            var searchingFor = inputSearch.value;

            for (var i = 0; i < items.length; i += 1) {
                var text = items[i].querySelector('.inner-text').innerHTML;
                if (isCaseSensitive) {
                    if (!text.includes(searchingFor)) {
                        items[i].style.display = 'none';
                    } else {
                        items[i].style.display = '';
                    }
                } else {
                    if (!text.toLowerCase().includes(searchingFor.toLowerCase())) {
                        items[i].style.display = 'none';
                    } else {
                        items[i].style.display = '';
                    }
                }
            }
        }
        //Search Item Event End
    };
}


module.exports = solve;