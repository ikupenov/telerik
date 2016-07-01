function solve(args) {
    var index, length, i;

    Array.prototype.remove = function remove(element) {
        index = args.indexOf(element);
        for (i = 0, length = args.length; i < length; i += 1) {
            if (index >= 0) {
                args.splice(index, 1);
            }
            index = args.indexOf(element, index + 1);
        }
    };

    args.remove(args[0]);

    args.forEach(function (el) {
        console.log(el);
    });
}