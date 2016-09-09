function solve() {
    const MIN_ITEM_NAME_LENGTH = 2,
        MAX_ITEM_NAME_LENGTH = 40;

    const MIN_BOOK_GENRE_LENGTH = 2,
        MAX_BOOK_GENRE_LENGTH = 20;

    const MIN_CATALOG_NAME_LENGTH = 2,
        MAX_CATALOG_NAME_LENGTH = 40;

    function* idGenerator() {
        let start = 0;

        while (true) {
            yield (start += 1);
        }
    }

    let itemIdGenerator = idGenerator();

    class Item {
        constructor(name, description) {
            this.name = name;
            this.description = description;
            this.id = itemIdGenerator.next().value;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            if (typeof value !== 'string') {
                throw 'Item name must be a string!';
            }

            if (value.length < MIN_ITEM_NAME_LENGTH ||
                value.length > MAX_ITEM_NAME_LENGTH) {
                throw 'Item name length is longer than expected!';
            }

            this._name = value;
        }

        get description() {
            return this._description;
        }
        set description(value) {
            if (typeof value !== 'string') {
                throw 'Item description must be a string!';
            }

            if (value === '') {
                throw 'Item description cannot be empty!';
            }

            this._description = value;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);

            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }
        set isbn(value) {
            if (typeof value !== 'string') {
                throw 'ISBN must be a string!';
            }

            if (value.length !== 10 && value.length !== 13) {
                throw 'ISBN length can be either 10 or 13 symbols long!';
            }

            if (!value.match(/^[0-9]+$/)) {
                throw 'ISBN can contain only digits!';
            }

            this._isbn = value;
        }

        get genre() {
            return this._genre;
        }
        set genre(value) {
            if (typeof value !== 'string') {
                throw 'Genre must be a string!';
            }

            if (value.length < MIN_BOOK_GENRE_LENGTH ||
                value.length > MAX_BOOK_GENRE_LENGTH) {
                throw 'Book genre length is longer than expected!';
            }

            this._genre = value;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);

            this.rating = rating;
            this.duration = duration;
        }

        get rating() {
            return this._rating;
        }
        set rating(value) {
            if (typeof value !== 'number') {
                throw 'Rating must be a number!';
            }

            if (value < 1 || value > 5) {
                throw 'Rating must be between 1 and 5, inclusive!';
            }

            this._rating = value;
        }

        get duration() {
            return this._duration;
        }
        set duration(value) {
            if (typeof value !== 'number') {
                throw 'Duration must be a number!';
            }

            if (value <= 0) {
                throw 'Duration must be greater than 0!';
            }

            this._duration = value;
        }
    }

    let catalogIdGenerator = idGenerator();

    class Catalog {
        constructor(name) {
            this.name = name;
            this.items = [];
            this.id = catalogIdGenerator.next().value;
        }

        get name() {
            return this._name;
        }
        set name(value) {
            if (typeof value !== 'string') {
                throw 'Catalog name must be a string!';
            }

            if (value.length < MIN_CATALOG_NAME_LENGTH ||
                value.length > MAX_CATALOG_NAME_LENGTH) {
                throw 'Catalog name length is longer than expected';
            }

            this._name = value;
        }

        add(...items) {
            if (Array.isArray(items[0])) {
                items = items[0]
            }

            if (!items.length) {
                throw 'At least one item must be passed as a parameter!';
            }

            items.forEach(x => {
                if (!(x instanceof Item)) {
                    throw 'All items must be an instance of Item!';
                }
            });

            this.items.push(...items);

            return this;
        }

        find(options) {
            if (options == null) {
                throw 'Invalid parameters provided!';
            }

            if (typeof options !== 'number' &&
                typeof options !== 'object') {
                throw 'Options must be either a number or an object!';
            }

            let isSingle = false;

            if (typeof options === 'number') {
                let id = options;
                options = { id: id };

                isSingle = true;
            }

            let items = this.items.filter(x => {
                return Object.keys(options)
                    .every(k => x[k] === options[k]);
            });

            if (isSingle) {
                items = items.length ? items[0] : null;
            }

            return items;
        }

        search(pattern) {
            if (typeof pattern !== 'string') {
                throw 'Search pattern must be a string!';
            }

            if (pattern.length < 1) {
                throw 'Search pattern must be at least 1 symbol long!';
            }

            let items = this.items.filter(x => {
                return (x.name.includes(pattern) ||
                    x.description.includes(pattern));
            });

            return items;
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

            books.forEach(b => {
                if (!(b instanceof Book)) {
                    throw 'All books must be an instance of Book!';
                }
            });

            super.add(books);
            return this;
        }

        getGenres() {
            let genres = {};
            this.items.forEach(b => genres[b.genre] = b.genre);

            return Object.keys(genres);
        }

        find(options) {
            return super.find(options);
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

            media.forEach(m => {
                if (!(m instanceof Media)) {
                    throw 'All media must be an instance of Media!';
                }
            });

            super.add(media);
            return this;
        }

        getTop(count) {
            if (typeof count !== 'number') {
                throw 'Count must be a number!';
            }

            if (count < 1) {
                throw 'Count must be greater than 1!';
            }

            let topMedia = this.items
                .slice(0, count)
                .sort((a, b) => b.rating - a.rating)
                .map(x => ({ id: x.id, name: x.name }));

            return topMedia;
        }

        getSortedByDuration() {
            let sortedByDuration = this.items
                .sort((a, b) => {
                    if (a.duration === b.duration) {
                        return a.id - b.id;
                    } else {
                        return b.duration - a.duration
                    }
                });

            return sortedByDuration;
        }

        find(options) {
            return super.find(options);
        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        },
    }
}

module.exports = solve;