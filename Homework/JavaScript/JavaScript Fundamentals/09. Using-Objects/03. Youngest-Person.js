function solve(args) {
    var youngestPerson = args[0] + " " + args[1],
        leastAge = +args[2],
        length = args.length,
        person, i;

    function makePerson(firstName, lastName, age) {
        return {
            firstName: firstName,
            lastName: lastName,
            age: age
        };
    }

    for (i = 0; i < length; i += 1) {
        person = makePerson(args[i * 3], args[i * 3 + 1], +args[i * 3 + 2]);

        if (person.age < leastAge) {
            leastAge = +person.age;
            youngestPerson = person.firstName + " " + person.lastName;
        }
    }

    return youngestPerson;
}