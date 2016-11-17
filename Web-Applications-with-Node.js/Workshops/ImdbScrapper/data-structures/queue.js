class Queue {
    constructor() {
        this.items = [];
    }

    enqueue(item) {
        this.items.push(item);
    }

    dequeue() {
        return this.items.shift();
    }

    peek() {
        return this.items[this.items.length - 1];
    }

    get length() {
        return this.items.length;
    }

    isEmpty() {
        return this.length == 0;
    }
}

module.exports.getQueue = () => {
    return new Queue();
}