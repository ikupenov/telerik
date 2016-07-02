function solve(args) {
    var result = '',
        text = args[0],
        offset = +args[1],
        alphabet = 'abcdefghijklmnopqrstuvwxyz',
        cypher = alphabet.substr(alphabet.length - offset, offset) +
            alphabet.substring(0, alphabet.length - offset);

    function isDigit(char) {
        if (char.charCodeAt(0) >= 48 && char.charCodeAt(0) <= 57) {
            return true;
        }
        return false;
    }

    function compress(counter, letter) {
        if (counter > 2) {
            compressed += counter.toString() + letter;
        }
        else if (counter === 2) {
            compressed += letter + letter;
        }
        else {
            compressed += letter;
        }
    }

    var compressed = '',
        textLen = text.length,
        counter = 1,
        i;

    for (i = 0; i < textLen - 1; i += 1) {
        if (text[i] === text[i + 1]) {
            counter += 1;
            if (i === textLen - 2) {
                compress(counter, text[i]);
            }
        }
        else {
            if (i === textLen - 2) {
                compress(counter, text[i]);
                counter = 1;
                compress(counter, text[i + 1]);
            }
            else {
                compress(counter, text[i]);
                counter = 1;
            }
        }
    }

    var compressedLength = compressed.length,
        cypherIndex;

    for (i = 0; i < compressedLength; i += 1) {
        if (isDigit(compressed[i])) {
            result += compressed[i];
        }
        else {
            cypherIndex = alphabet.indexOf(compressed[i]);
            result += compressed[i].charCodeAt(0) ^ cypher[cypherIndex].charCodeAt(0);
        }
    }

    var sum = 0,
        product = 1,
        len = result.length;

    for (i = 0; i < len; i += 1) {
        if (result[i] % 2 === 0) {
            sum += +result[i];
        }
        else {
            product *= +result[i];
        }
    }

    console.log(sum);
    console.log(product);
}