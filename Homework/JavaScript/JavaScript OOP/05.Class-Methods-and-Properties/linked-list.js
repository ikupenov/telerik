'use strict';

class ListNode {
    constructor(value, next) {
        this._value = value;
        this._next = next;
    }

    get value() {
        return this._value;
    }
    set value(val) {
        this._value = val;
    }

    get next() {
        return this._next;
    }
    set next(val) {
        this._next = val;
    }
}

class LinkedList {
    /* globals Symbol */

    constructor() {
        this._length = 0;
        this._first = null;
        this._last = null;
    }

    append(...values) {
        if (!values.length) {
            throw 'At least one item to append must be provided!';
        }

        if (!this._first) {
            this._initialize(values[0]);
            values.splice(0, 1);
        }

        for (let i = 0, len = values.length; i < len; i += 1) {
            let nodeToApend = new ListNode(values[i], null);

            if (!this._first.next) {
                this._first.next = nodeToApend;
            } else {
                this._last.next = nodeToApend;
            }

            this._last = nodeToApend;
            this._length += 1;
        }

        return this;
    }

    prepend(...values) {
        if (!values.length) {
            throw 'At least one item to prepend must be provided.';
        }

        if (!this._first) {
            this._initialize(values[values.length - 1]);
            values.splice(values.length - 1, 1);
        }

        for (let i = values.length - 1; i >= 0; i -= 1) {
            let nodeToPrepend = new ListNode(values[i], this._first);

            this._first = nodeToPrepend;
            this._length += 1;
        }

        return this;
    }

    insert(index, ...values) {
        if (!values.length) {
            throw 'At least one item to insert must be provided';
        }

        if (index > this._length + 1) {
            throw 'Insert index cannot be greater than the LinkedList length';
        } else if (index < 0) {
            throw 'Insert index cannot be negative';
        }

        if (!this._first) {
            this._initialize(values[values.length - 1]);
            values.splice(values.length - 1, 1);
        }

        for (let i = values.length - 1; i >= 0; i -= 1) {
            let nodeBeforeIndex, nodeAfterIndex;

            if (index === 0) {
                nodeBeforeIndex = null;
                nodeAfterIndex = this._first;
            } else {
                nodeBeforeIndex = this._getElementAt(index - 1);
                nodeAfterIndex = nodeBeforeIndex.next;
            }

            let nodeToInsert = new ListNode(values[i], nodeAfterIndex);

            if (!nodeAfterIndex) {
                this._last = nodeToInsert;
            }

            if (nodeBeforeIndex) {
                nodeBeforeIndex.next = nodeToInsert;
            } else {
                this._first = nodeToInsert;
            }

            this._length += 1;
        }

        return this;
    }

    at(index, value) {
        if (typeof index === 'undefined' && typeof value === 'undefined') {
            throw 'All required parameters must be provided (index[, value])';
        } else if (index < 0 || index > this._length - 1) {
            throw 'Index out of range';
        }

        let elementAtIndex = this._getElementAt(index);

        if (typeof value === 'undefined') {
            return elementAtIndex.value;
        } else {
            elementAtIndex.value = value;
        }
    }

    removeAt(index) {
        if (index < 0 || index > this.length - 1) {
            throw 'Index out of range';
        }

        let elementAtIndex = this._getElementAt(index);

        if (this._length === 1) {
            this._first = null;
        } else {
            let elementBeforeIndex = this._getElementAt(index - 1),
                elementAfterIndex = this._getElementAt(index + 1);

            if (!elementBeforeIndex) {
                this._first = elementAfterIndex;
            } else if (!elementAfterIndex) {
                elementBeforeIndex.next = null;
                this._last = elementBeforeIndex;
            } else {
                elementBeforeIndex.next = elementAfterIndex;
            }
        }

        this._length -= 1;

        return elementAtIndex.value;
    }

    toString() {
        let values = this.toArray(),
            valuesToString = values.join(' -> ');

        return valuesToString;
    }

    toArray() {
        let values = [],
            currentNode = this._first;

        while (currentNode) {
            values.push(currentNode.value);
            currentNode = currentNode.next;
        }

        return values;
    }

    _initialize(value) {
        let node = new ListNode(value, null);
        this._first = node;
        this._last = node;

        this._length += 1;
    }

    _getElementAt(index) {
        if (index < 0 || index > this._length - 1) {
            return null;
        }

        let currentNode = this._first;

        for (let i = 0; i < index; i += 1) {
            currentNode = currentNode.next;
        }

        return currentNode;
    }

    get length() {
        return this._length;
    }

    get first() {
        if (!this._first) {
            return null;
        }

        return this._first.value;
    }

    get last() {
        if (!this._last) {
            return null;
        }

        return this._last.value;
    }

    *[Symbol.iterator]() {
        let currentNode = this._first;

        while (currentNode) {
            yield currentNode.value;
            currentNode = currentNode.next;
        }
    }
}

module.exports = LinkedList;