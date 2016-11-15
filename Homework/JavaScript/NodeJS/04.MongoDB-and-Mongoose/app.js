const instanode = require('./instanode-db');

instanode.saveImage({
    url: 'https://gosheto.com',
    creationDate: new Date(2010, 10, 27),
    description: 'az sum gosheto',
    tags: ['gosheto', 'az', 'u nas']
});

instanode.saveImage({
    url: 'https://imgur.com/my-car',
    creationDate: new Date(2003, 6, 15),
    description: 'az sum gosheto',
    tags: ['car', 'my-car', 'bmw']
});

instanode
    .findByTag('gosheto')
    .then(console.log)
    .catch(console.log);

instanode
    .filter({
        minDate: new Date(2005),
        results: 5
    })
    .then(console.log)
    .catch(console.log)