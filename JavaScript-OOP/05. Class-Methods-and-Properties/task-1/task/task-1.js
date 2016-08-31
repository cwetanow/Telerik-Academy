'use strict';

class listNode {
    constructor(value, previous) {
        this._value = value;
        this._next = null;
        if (previous !== undefined) {
            previous.next = this;
        }
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
    constructor() {
        this._first = null;
        this._last = null;
        this._length = 0;
    }

    get first() {
        return this._first.value;
    }

    get last() {
        return this._last.value;
    }

    get length() {
        return this._length;
    }

    append(...elements) {
        elements.forEach(function (element) {
            if (this.length === 0) {
                this._first = new listNode(element);
                this._last = this._first;
            } else {
                this._last = new listNode(element, this._last);
            }
            this._length += 1;
        }, this);
        return this;
    }

    prepend(...elements) {
        return this.insert(0, ...elements);
    }

    insert(index, ...elements) {
        if (index < 0 || index >= this.length) {
            throw new Error('Invalid index');
        }

        if (index === 0) {
            elements = elements.reverse();
            elements.forEach(function (element) {
                let node = new listNode(element);
                node.next = this._first;
                this._first = node;
                this._length += 1;
            }, this);
            return this;
        }

        let counter = 0;
        let currentNode = this._first;
        while (counter < index - 1) {
            currentNode = currentNode.next;
            counter += 1;
        }

        elements.forEach(function (element) {
            let node = new listNode(element);
            node.next = currentNode.next;
            currentNode.next = node;
            currentNode = node;
            this._length += 1;
        }, this);

        return this;
    }

    toArray() {
        let result = [];
        let node = this._first;

        while (node !== null) {
            result.push(node.value);
            node = node.next;
        }

        return result;
    }

    toString() {
        return this.toArray().join(' -> ');
    }

    at(index, value) {
        if (index < 0 || index >= this.length) {
            throw new Error('Invalid index');
        }

        let currentNode = this._first;
        for (var i = 0; i < index; i += 1) {
            currentNode = currentNode.next;
        }

        if (value !== undefined) {
            currentNode.value = value;
        } else {
            return currentNode.value;
        }
    }

    removeAt(index) {
        if (index < 0 || index >= this.length) {
            throw new Error('Invalid index');
        }

        let current = 0;
        let currentNode = this._first;
        let prevNode = null;
        let result = null;

        while (current < index) {
            prevNode = currentNode;
            currentNode = prevNode.next;
            current += 1;
        }

        this._length--;

        if (this.length === 0) {
            result = this._first.value;
            this._first = null;
        }
        else if (prevNode === null) {
            result = currentNode.value;
            this._first = currentNode.next;
        }
        else {
            result = currentNode.value;
            prevNode.next = currentNode.next;
        }

        let last = null;

        if (this._first !== null) {
            last = this._first;
            while (last.next !== null) {
                last = last.next;
            }
        }
        this._last = last;

        return result;
    }

    [Symbol.iterator]() {
        let currentNode = this._first;

        return {
            i: 0,
            next() {
                if (currentNode) {
                    this.i += 1;

                    let now = currentNode;
                    currentNode = currentNode.next;

                    return {
                        value: now.value,
                        done: false
                    }
                } else {
                    return {
                        value: undefined,
                        done: true
                    };
                }
            }
        };
    }
}

module.exports = LinkedList;