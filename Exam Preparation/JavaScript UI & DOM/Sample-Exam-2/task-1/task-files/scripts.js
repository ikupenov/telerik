function createCalendar(selector, events) {
    var root = document.querySelector(selector);

    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    Date.prototype.getDayName = function () {
        return days[this.getDay()];
    };

    var table = document.createElement('table');
    table.style.borderCollapse = 'collapse';
    table.style.width = '740px';
    table.style.height = '600px';

    var date = new Date(2014, 5, 1);

    for (var i = 0; i < 5; i += 1) {
        var tr = document.createElement('tr');
        for (var j = 0; j < 7; j += 1) {
            var td = document.createElement('td');
            td.className = 'date';
            td.style.border = '1px solid black';
            td.style.padding = '0';

            var dateTitle = document.createElement('h5');
            dateTitle.innerHTML = `${date.getDayName()} ${date.getDate()} Jun 2014`;
            dateTitle.className = 'date-title';
            dateTitle.style.backgroundColor = '#CCCCCC';
            dateTitle.style.borderTop = '1px solid black';
            dateTitle.style.borderBottom = '1px solid black';
            dateTitle.style.textAlign = 'center';
            dateTitle.style.margin = '0';

            td.appendChild(dateTitle);

            for (var k = 0; k < events.length; k += 1) {
                if (+events[k].date === date.getDate()) {
                    var time = document.createElement('span');
                    time.innerHTML = events[k].hour + ' ';
                    var title = document.createElement('strong');
                    title.innerHTML = events[k].title;
                    
                    td.appendChild(time);
                    td.appendChild(title);

                    break;
                }
            }

            tr.appendChild(td);

            if (date.getDate() === 30) {
                break;
            }

            date.setDate(date.getDate() + 1);
        }

        table.appendChild(tr);
    }

    var selected;

    table.addEventListener('mouseover', function (ev) {
        var target = ev.target;
        var title;

        if (target.parentElement.className === 'date') {
            title = target.parentElement.getElementsByClassName('date-title')[0];
            title.style.backgroundColor = 'red';
        } else if (target.className === 'date-title') {
            target.style.backgroundColor = 'red';
        } else if (target.className === 'date') {
            title = target.getElementsByClassName('date-title')[0];
            title.style.backgroundColor = 'red';
        }
    });

    table.addEventListener('mouseout', function (ev) {
        var target = ev.target;
        var title;

        if (target.parentElement.className === 'date') {
            title = target.parentElement.getElementsByClassName('date-title')[0];
            title.style.backgroundColor = '#CCCCCC';
        } else if (target.className === 'date-title') {
            target.style.backgroundColor = '#CCCCCC';
        } else if (target.className === 'date') {
            title = target.getElementsByClassName('date-title')[0];
            title.style.backgroundColor = '#CCCCCC';
        }
    });

    table.addEventListener('click', function (ev) {
        var target = ev.target;

        if (selected) {
            selected.style.backgroundColor = '';
        }

        if (target.parentElement.className === 'date') {
            target.parentElement.style.backgroundColor = 'yellow';
            selected = target.parentElement;
        } else if (target.className === 'date') {
            target.style.backgroundColor = 'yellow';
            selected = target;
        }
    });

    root.appendChild(table);
}