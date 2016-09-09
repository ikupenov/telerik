function solve() {
    function* idGenerator() {
        let start = 0;

        while (true) {
            yield start += 1;
        }
    }

    const VALIDATOR = {
        validateStringLength: function validateStringLength(str, min, max) {
            if (!str) {
                throw 'Element must be provided!';
            }

            if (str.length < min || str.length > max) {
                throw 'String length is invalid!';
            }
        },

        validateIsbn: function validateIsbn(isbn) {
            if (isbn.length !== 10 && isbn.length !== 13) {
                throw 'ISBN length must be exactly 10 or 13 digits long!';
            }

            if (isNaN(+isbn)) {
                throw 'ISBN can contain only digits!';
            }
        }
    }


    let itemIdGenerator = idGenerator();

    class Item {
        constructor(description, name) {
            this.description = description;
            this.name = name;
            this.id = itemIdGenerator.next().value;
        }

        get description() {
            return this._description;
        }
        set description(value) {
            if (!value) {
                throw 'Description must be a non-empty string!';
            }

            this._description = value;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            VALIDATOR.validateStringLength(value, 2, 40);

            this._name = value;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(description, name);

            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }
        set isbn(value) {
            VALIDATOR.validateIsbn(value);

            this._isbn = value;
        }

        get genre() {
            return this._genre;
        }
        set genre(value) {
            VALIDATOR.validateStringLength(value, 2, 20);

            this._genre = value;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(description, name);

            this.duration = duration;
            this.rating = rating;
        }

        get duration() {
            return this._duration;
        }
        set duration(value) {
            if (typeof value !== 'number') {
                throw 'Duration must be a number!';
            }

            if (value <= 0) {
                throw 'Duration cannot be equal or lass than 0!';
            }

            this._duration = value;
        }

        get rating() {
            return this._rating;
        }
        set rating(value) {
            if (typeof value !== 'number') {
                throw 'Rating must be a number!';
            }

            if (value < 1 || value > 5) {
                throw 'Rating must be between 1 and 5 inclusive!';
            }

            this._rating = value;
        }
    }

    let catalogIdGenerator = idGenerator();

    class Catalog {
        constructor(name) {
            this.name = name;
            this._items = [];
            this._id = catalogIdGenerator.next().value;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            VALIDATOR.validateStringLength(value, 2, 40);

            this._name = value;
        }

        get items() {
            return this._items;
        }

        get id() {
            return this._id;
        }

        add(...items) {
            if (Array.isArray(items[0])) {
                items = items[0];
            }

            if (!items.length) {
                throw 'You must provide at least one item to add!';
            }

            let len = items.length;

            for (let i = 0; i < len; i += 1) {
                if (!(items[i] instanceof Item)) {
                    throw 'All provided items must be of type Item!';
                }
            }

            this.items.push(...items);

            return this;
        }

        find(options) {
            let filteredItems = this._findItems(options);

            return filteredItems;
        }

        search(pattern) {
            if (pattern.length < 1) {
                throw 'The pattern length must be at least 1 symbol long!';
            }

            let items = this._items,
                len = items.length,
                filteredItems = [];

            for (let i = 0; i < len; i += 1) {
                let name = items[i].name;
                let description = items[i].description;

                if (name.includes(pattern)) {
                    filteredItems.push(items[i]);
                } else if (description.includes(pattern)) {
                    filteredItems.push(items[i]);
                }
            }

            return filteredItems;
        }

        _findItems(searchOptions) {
            if (typeof searchOptions === 'undefined') {
                throw 'All required parameters must be provided!';
            }

            let options = {};
            let singleItem = false;

            if (typeof searchOptions === 'number') {
                options.id = searchOptions;
                singleItem = true;
            } else if (typeof searchOptions === 'object') {
                options = searchOptions;
            } else {
                throw 'Search options can be either an integer or an object!';
            }

            let items = this._items;

            let searchOptionProps = Object.keys(options);

            let filteredItems = items.filter(item => {
                return searchOptionProps.every(prop => item[prop] === options[prop])
            });

            if (singleItem) {
                filteredItems = filteredItems[0];
                return filteredItems || null;
            } else {
                return filteredItems;
            }
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (Array.isArray(books[0])) {
                books = books[0];
            }

            let len = books.length;

            for (let i = 0; i < len; i += 1) {
                if (!(books[i] instanceof Book)) {
                    throw 'All elements in the book catalog must be an instance of Book!';
                }
            }

            super.add(books);

            return this;
        }

        getGenres() {
            let books = this.items,
                len = books.length,
                genres = [];

            for (let i = 0; i < len; i += 1) {
                let bookGenre = books[i].genre.toLowerCase();

                if (genres.indexOf(bookGenre) === -1) {
                    genres.push(bookGenre);
                }
            }

            return genres;
        }

        find(options) {
            let filteredItems = super.find(options);

            return filteredItems;
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...media) {
            if (Array.isArray(media[0])) {
                media = media[0];
            }

            let len = media.length;

            for (let i = 0; i < len; i += 1) {
                if (!(media[i] instanceof Media)) {
                    throw 'All elements in the media catalog must be an instance of Media!';
                }
            }

            super.add(media);

            return this;
        }

        getTop(count) {
            if (typeof count !== 'number') {
                throw 'Count must be a number!';
            }

            if (count < 1) {
                throw 'Count cannot be below 1!';
            }

            let media = this.items;
            let topMedia = media
                .sort((a, b) => b.rating - a.rating)
                .map(x => {
                    return {
                        id: x.id,
                        name: x.name
                    }
                })
            topMedia.splice(count);

            return topMedia;
        }

        getSortedByDuration() {
            let media = this.items;
            let sorted = media.sort((a, b) => b.duration - a.duration);
            sorted.sort((a, b) => a.id - b.id);

            return sorted;
        }

        find(options) {
            let filteredItems = super.find(options);

            return filteredItems;
        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            let book = new Book(name, isbn, genre, description);

            return book;
        },
        getMedia: function (name, rating, duration, description) {
            let media = new Media(name, rating, duration, description);

            return media;
        },
        getBookCatalog: function (name) {
            let bookCatalog = new BookCatalog(name);

            return bookCatalog;
        },
        getMediaCatalog: function (name) {
            let mediaCatalog = new MediaCatalog(name);

            return mediaCatalog;
        },
    }
}

let modul = solve();

// let book1 = modul.getBook('Book1', '1234567891', 'Action', 'Nqma description');
// let book2 = modul.getBook('Book2', '1234517891321', 'Comedy', 'NoDesc');

let media1 = modul.getMedia('Media1', 5, 3.35, 'None');
let media2 = modul.getMedia('Media2', 3, 2.35, 'NNNNNone');

// let catalog = modul.getBookCatalog('katalog');
// catalog.add();

// let bookCatalog = modul.getBookCatalog('bookCatalog');
// bookCatalog.add(book1).add(book2);

let mediaCatalog = modul.getMediaCatalog('MediaCatalog');
mediaCatalog.add(media1).add(media2);

console.log(mediaCatalog.getTop(1));

// console.log(catalog);

module.exports = solve;