function solve(args) {
    var pointX = parseFloat(args[0]);
    var pointY = parseFloat(args[1]);

    var isInsideCircle;
    var isInsideRectangle;

    var r = 1.5;
    var distance = Math.sqrt((Math.pow(pointX - 1, 2) + Math.pow(pointY - 1, 2)));

    if (distance <= r) {
        isInsideCircle = "inside circle";
    }
    else {
        isInsideCircle = "outside circle";
    }

    if (pointX >= -1 && pointX <= 5 && pointY <= 1 && pointY >= -1) {
        isInsideRectangle = "inside rectangle";
    }
    else {
        isInsideRectangle = "outside rectangle";
    }

    console.log(isInsideCircle + " " + isInsideRectangle);
}