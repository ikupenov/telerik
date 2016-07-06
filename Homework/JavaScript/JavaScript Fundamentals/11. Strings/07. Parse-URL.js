function solve(args) {
    var url = args[0],
        indexes = [],
        protocol,
        server,
        resource;

    indexes[0] = +url.indexOf(':');
    protocol = url.substring(0, indexes[0]);

    indexes[0] = +url.indexOf('\/\/') + 2;
    indexes[1] = +url.indexOf('\/', indexes[0] + 2);
    server = url.substring(indexes[0], indexes[1]);

    resource = url.substring(indexes[1]);

    console.log('protocol: ' + protocol);
    console.log('server: ' + server);
    console.log('resource: ' + resource);
}