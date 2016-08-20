/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        var root = document.querySelector(selector);

        var suggestions = document.createElement('ul');
        suggestions.className = 'suggestions-list';

        //If Initial Suggestions Are Passed
        if (initialSuggestions) {
            // Remove duplicates
            var uniqueArr = [];
            for (var i = 0; i < initialSuggestions.length; i += 1) {
                var isAdded = false;
                for (var j = 0; j < uniqueArr.length; j += 1) {
                    if (initialSuggestions[i].toLowerCase() === uniqueArr[j].toLowerCase()) {
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded) {
                    uniqueArr.push(initialSuggestions[i]);
                }
            }

            for (var i = 0; i < uniqueArr.length; i += 1) {
                var li = document.createElement('li');
                li.style.display = 'none';
                li.className = 'suggestion';

                var a = document.createElement('a');
                a.setAttribute('href', '#');
                a.className = 'suggestion-link';
                a.innerHTML = uniqueArr[i];

                li.appendChild(a);
                suggestions.appendChild(li);
            }
        }

        var input = document.querySelector('.tb-pattern');

        var addBtn = document.querySelector('.btn-add');

        //Add input value to suggestions
        addBtn.addEventListener('click', function () {
            var inputVal = input.value;

            if (!inputVal) {
                return;
            }

            //Check if suggestion already exists
            var allCurrentSuggestions = document.querySelectorAll('.suggestion-link');
            for (var i = 0; i < allCurrentSuggestions.length; i += 1) {
                if (allCurrentSuggestions[i].innerHTML.toLowerCase() === inputVal.toLowerCase()) {
                    return;
                }
            }

            //Else add input value to suggestion list 
            var li = document.createElement('li');
            li.className = 'suggestion';

            var a = document.createElement('a');
            a.setAttribute('href', '#');
            a.className = 'suggestion-link';
            a.innerHTML = inputVal;

            li.appendChild(a);
            suggestions.appendChild(li);
        });

        //Auto complete
        input.addEventListener('input', function () {
            var inputVal = input.value;

            var allCurrentSuggestions = document.querySelectorAll('.suggestion-link');

            for (var i = 0; i < allCurrentSuggestions.length; i += 1) {
                var suggestionText = allCurrentSuggestions[i].innerHTML.toLowerCase();

                if (!suggestionText.includes(inputVal.toLowerCase())) {
                    allCurrentSuggestions[i].parentElement.style.display = 'none';
                } else {
                    allCurrentSuggestions[i].parentElement.style.display = '';
                }
            }

            if (!inputVal) {
                for (var i = 0; i < allCurrentSuggestions.length; i += 1) {
                    allCurrentSuggestions[i].parentElement.style.display = 'none';
                }
            }
        });

        //Add to input
        suggestions.addEventListener('click', function (ev) {
            var target = ev.target;

            if (target.className === 'suggestion-link') {
                input.value = target.innerHTML;
            }
        });

        root.appendChild(suggestions);
    };
}

module.exports = solve;