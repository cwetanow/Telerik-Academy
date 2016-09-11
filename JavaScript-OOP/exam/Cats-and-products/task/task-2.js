/* globals module */

"use strict";

function solve() {
    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }

        add(product) {
            this.products.push(product);

            return this;
        }

        remove(product) {
            if (this.products.length === 0) {
                throw new Error();
            }

            let index = this.products.indexOf(product);

            if (index < 0) {
                throw new Error();
            }

            this.products.splice(index, 1);
        }

        showCost() {
            if (this.products.length === 0) {
                return 0;
            }

            let sum = 0;

            this.products.forEach(function (product) {
                sum += product.price;
            }, this);

            return sum;
        }

        showProductTypes() {
            let result = [];
            if (this.products.length === 0) {
                return result;
            }

            this.products.forEach(function (element) {
                let type = element.productType;
                if (result.indexOf(type < 0)) {
                    result.push(type);
                }
            }, this);

            result = result.filter(function (value, index, self) {
                return self.indexOf(value) === index;
            });
            result.sort();

            return result;
        }

        getInfo() {
            let result = {
                products: [],
                totalPrice: 0
            }

            result.totalPrice = this.showCost();

            let names = [];
            this.products.forEach(function (element) {
                let name = element.name;

                if (names.indexOf(name < 0)) {
                    names.push(name);
                }

            }, this);

            names = names.filter(function (value, index, self) {
                return self.indexOf(value) === index;
            });

            names.forEach(function (name) {
                result.products.push({ name: name, quantity: 0, totalPrice: 0 });
            }, this);

            result.products.forEach(function (prod) {
                this.products.forEach(function (element) {
                    if (prod.name === element.name) {
                        prod.quantity += 1;
                        prod.totalPrice += element.price;
                    }
                }, this);
            }, this);

            return result;
        }
    }

    return {
        Product, ShoppingCart
    };
}

module.exports = solve;