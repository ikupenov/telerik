function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        Date.prototype.daysInMonth = function () {
            return new Date(this.getFullYear(), this.getMonth() + 1, 0).getDate();
        };

        Date.prototype.getPreviousMonth = function () {
            if (this.getMonth() === 0) {
                return new Date(this.getFullYear() - 1, 11, this.getDate());
            } else {
                return new Date(this.getFullYear(), this.getMonth() - 1, this.getDate());
            }
        };

        Date.prototype.getNextMonth = function () {
            if (this.getMonth() === 11) {
                return new Date(this.getFullYear() + 1, 0, this.getDate());
            } else {
                return new Date(this.getFullYear(), this.getMonth() + 1, 1);
            }
        };

        Date.prototype.getPreviousDay = function () {
            if (this.getDate() === 1) {
                var previousMonth = this.getPreviousMonth();
                var daysInMonth = previousMonth.daysInMonth();
                return new Date(previousMonth.getFullYear(), previousMonth.getMonth(), daysInMonth);
            } else {
                return new Date(this.getFullYear(), this.getMonth(), this.getDate() - 1);
            }
        };

        Date.prototype.getNextDay = function () {
            if (this.getDate() === this.daysInMonth()) {
                var nextMonth = this.getNextMonth();
                return new Date(nextMonth.getFullYear(), nextMonth.getMonth(), 1);
            } else {
                return new Date(this.getFullYear(), this.getMonth(), this.getDate() + 1);
            }
        };

        function createCalendar(year, month) {
            $('.calendar').empty();

            var selectedDate = new Date(year, month, 1);

            do {
                selectedDate = selectedDate.getPreviousDay();
            }
            while (selectedDate.getDayName() !== WEEK_DAY_NAMES[0]);

            var $tr = $('<tr/>');
            for (var i = 0; i < 7; i += 1) {
                var $th = $('<th/>');
                $th.text(WEEK_DAY_NAMES[i]);
                $th.appendTo($tr);
            }
            $('.calendar').append($tr);

            for (var i = 0; i < 6; i += 1) {
                var $tr = $('<tr/>');
                for (var j = 0; j < 7; j += 1) {
                    var $td = $('<td/>');
                    $td.text(selectedDate.getDate());

                    if (selectedDate.getMonth() === month) {
                        $td.addClass('current-month');
                    } else {
                        $td.addClass('another-month');
                    }

                    $td.attr('date-display', selectedDate.getDate() + '/' + (selectedDate.getMonth() + 1) + '/' + selectedDate.getFullYear());

                    $tr.append($td);

                    selectedDate = selectedDate.getNextDay();
                }
                $tr.appendTo('.calendar');
            }
        }

        var date = new Date();
        var currentDate = new Date();

        Date.prototype.getFullDate = function () {
            return (date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear());
        };

        $('#date').addClass('datepicker').wrap('<div class="datepicker-wrapper"/>');

        $('<div class="picker"/>').appendTo('.datepicker-wrapper');

        $('<div class="controls"/>').appendTo('.picker');

        $('<button class="btn left-btn"><</button>').appendTo('.controls');

        $('<label class="current-month"/>').appendTo('.controls');
        $('.current-month').text(date.getMonthName() + ' ' + date.getFullYear());

        $('<button class="btn right-btn">></button>').appendTo('.controls');

        $('<table class="calendar"/>').appendTo('.picker');
        createCalendar(date.getFullYear(), date.getMonth());

        $('<div class="current-date"/>').appendTo('.picker');

        $('<a href="#" class="current-date-link"/>').appendTo('.current-date');
        $('.current-date-link').text(currentDate.getFullDate());

        $('#date').on('focus', function () {
            $('.picker').addClass('picker-visible');
        });

        $(document).on('click', function (event) {
            var $target = $(event.target);

            if ($target.parents('.picker').length !== 1 &&
                !$('#date').is(':focus')) {
                $('.picker').removeClass('picker-visible');
            }
        });

        $('.current-date-link').on('click', function () {
            $('#date').val(currentDate.getDate() + '/' + (currentDate.getMonth() + 1) + '/' + currentDate.getFullYear());
            $('.picker').removeClass('picker-visible');
        });

        $('.left-btn').on('click', function () {
            date = date.getPreviousMonth();
            createCalendar(date.getFullYear(), date.getMonth());
            $('label.current-month').text(date.getMonthName() + ' ' + date.getFullYear());
        });

        $('.right-btn').on('click', function () {
            date = date.getNextMonth();
            createCalendar(date.getFullYear(), date.getMonth());
            $('label.current-month').text(date.getMonthName() + ' ' + date.getFullYear());
        });

        $('.calendar').on('click', 'td.current-month', function () {
            var $this = $(this);
            $('#date').val($this.attr('date-display'));
        });

        return $(this);
    };
}

module.exports = solve;