const mongoose = require('mongoose');
mongoose.Promise = global.Promise;

const connectionString = 'mongodb://localhost:27017/instanode-db';
mongoose.connect(connectionString);

const imageSchema = mongoose.Schema({
    url: String,
    creationDate: Date,
    description: String,
    tags: []
});

const tagSchema = mongoose.Schema({
    name: String,
    creationDate: Date,
    images: [imageSchema]
});

const Tag = mongoose.model('Tag', tagSchema);
const Image = mongoose.model('Image', imageSchema);

const saveImage = function(options) {
    new Image({
        url: options.url,
        creationDate: options.creationDate,
        description: options.description,
        tags: options.tags
    }).save();
};

const saveTag = function(options) {
    new Tag({
        name: options.name,
        creationDate: options.creationDate,
        images: options.images
    }).save();
};

const findByTag = function(tagName) {
    return Image.find({ tags: tagName });
}

const filter = function(options) {
    return Image
        .where('creationDate')
        .gt(options.minDate || new Date(1900, 1, 1))
        .lt(options.maxDate || new Date(2100, 12, 30))
        .limit(options.results || 10)
}

module.exports.saveImage = saveImage;
module.exports.saveTag = saveTag;
module.exports.findByTag = findByTag;
module.exports.filter = filter;