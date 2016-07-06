
function solve(args) {
    var output = '',
        matchTags = /<.*>/ig;

    args.forEach(function (line) {
        output += line.replace(matchTags, '').trim();
    });

    console.log(output);
}