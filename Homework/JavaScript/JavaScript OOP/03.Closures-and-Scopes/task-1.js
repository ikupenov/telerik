/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(args) {
            var sortedBooks = books.slice();

            sortedBooks.sort((a, b) => a.ID - b.ID);

            if (args) {
                for (var key in args) {
                    if (args.hasOwnProperty(key)) {
                        var val = args[key];

                        sortedBooks = sortedBooks.filter(el => el[key] === val);
                    }
                }
            }

            return sortedBooks;
        }

        function addBook(book) {
            if (!book) {
                throw 'Arguments must be provided';
            } else if (!book.author) {
                throw 'Author must be provided';
            } else if (book.isbn.length !== 10 && book.isbn.length !== 13) {
                throw 'Book ISBN must be either 10 or 13 digits long';
            }

            var isNotUniqueIsbn = books
                .map(x => x.isbn)
                .some(x => x === book.isbn);

            var isNotUniqueTitle = books
                .map(x => x.title)
                .some(x => x === book.title);

            if (isNotUniqueIsbn || isNotUniqueTitle) {
                throw 'Book title and ISBN must be unique';
            }

            verifyLength(book.title, 2, 100);
            verifyLength(book.category, 2, 100);

            book.ID = books.length + 1;
            books.push(book);

            if (categories.indexOf(book.category) === -1) {
                categories.push(book.category);
            }

            return book;
        }

        function listCategories() {
            var sortedCategories = categories.sort((a, b) => a.ID - b.ID);

            return sortedCategories;
        }

        function verifyLength(title, min, max) {
            if (title.length < min || title.length > max) {
                throw 'Invalid book/category length';
            }
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    } ());

    return library;
}

module.exports = solve;