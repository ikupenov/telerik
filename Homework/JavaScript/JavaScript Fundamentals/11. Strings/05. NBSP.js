function solve(args) {
    var text = args[0].toString();

    text = text.replace(/\s/g, '&nbsp;');
    console.log(text);
}