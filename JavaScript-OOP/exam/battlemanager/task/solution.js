function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!',
        INVALID_ALIGNMENT: 'Alignment must be good, neutral or evil!',
        INVALID_FUNCTION: 'Effect must be a function with 1 parameter!'
    };

    let validator = {
        nameLength: function (str) {
            if (str.length < 2 || str.length > 20) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        stringIsString: function (str) {
            if (typeof str !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
        },
        stringContainsLettersAndSpaces: function (str) {
            if (!(/^[A-Za-z ]+$/.test(str))) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        manaValidator: function (mana) {
            if (parseInt(mana) !== mana || mana < 1) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        alignmentIsCorrect: function (str) {
            if (str !== 'good' && str != 'neutral' && str !== 'evil') {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        damageCheck: function (dmg) {
            if (dmg < 0 || dmg > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        healthCheck: function (hp) {
            if (hp < 0 || hp > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        countCheck: function (x) {
            if (x < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        speedCheck: function (x) {
            if (x <= 0 || x > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        },
        validateEffect: function (f) {
            if (typeof f !== 'function' || f.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_FUNCTION);
            }
        },
        validateSpellLike: function (obj) {
            if (obj.name === undefined || obj.manaCost === undefined || obj.effect === undefined) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
            try {
                new Spell(obj.name, obj.manaCost, obj.effect);
            } catch (error) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        validateUnitLike: function (obj) {
            if (obj.damage === undefined || obj.health === undefined || obj.count === undefined) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }
            try {
                new ArmyUnit("name", "good", obj.damage, obj.health, obj.count, 50);
            } catch (error) {
                throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            }
        }
    };

    let commanders = [];
    let units = [];

    let generator = {
        get: (function () {
            return (function () {
                var lastId = 0;
                return {
                    getNext: function () {
                        return lastId += 1;
                    }
                };
            } ());
        })
    };

    let idGenerator = generator.get();

    // your implementation goes here
    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        set name(x) {
            validator.nameLength(x);
            validator.stringContainsLettersAndSpaces(x);
            validator.stringIsString(x);

            this._name = x;
        }

        get name() {
            return this._name;
        }

        set mana(x) {
            validator.manaValidator(x);

            this._mana = x;
        }

        get mana() {
            return this._mana;
        }

        set effect(x) {
            validator.validateEffect(x);

            this._effect = x;
        }

        get effect() {
            return this._effect;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        set name(x) {
            validator.nameLength(x);
            validator.stringContainsLettersAndSpaces(x);
            validator.stringIsString(x);

            this._name = x;
        }

        get name() {
            return this._name;
        }

        set alignment(x) {
            validator.alignmentIsCorrect(x);

            this._alignment = x;
        }

        get alignment() {
            return this._alignment;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);
            this.id = idGenerator.getNext();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        set damage(x) {
            validator.damageCheck(x);

            this._damage = x;
        }

        get damage() {
            return this._damage;
        }

        set health(x) {
            validator.healthCheck(x);

            this._hp = x;
        }

        get health() {
            return this._hp;
        }

        set speed(x) {
            validator.speedCheck(x);

            this._speed = x;
        }

        get speed() {
            return this._speed;
        }

        set count(x) {
            validator.countCheck(x);

            this._count = x;
        }

        get count() {
            return this._count;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        set mana(x) {
            validator.manaValidator(x);
            if (typeof x !== 'number' || x < 1) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
            this._mana = x;
        }

        get mana() {
            return this._mana;
        }
    }

    let getCommander = function (name, alignment, mana) {
        return new Commander(name, alignment, mana);
    };

    let getArmyUnit = function (options) {
        return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
    };

    let getSpell = function (name, cost, effect) {
        return new Spell(name, cost, effect);
    };


    let addCommanders = function (...commanderi) {
        commanderi.forEach(function (element) {
            commanders.push(element);
        }, this);

        return this;
    };

    let findCommander = function (name) {
        return findCommanders({ name: name })[0];
    };

    let addArmyUnitTo = function (commanderName, unit) {
        let commander = findCommander(commanderName);

        commander.army.push(unit);
        units.push(unit);

        return this;
    };

    let addSpellsTo = function (commanderName, ...spells) {
        spells.forEach(function (element) {
            validator.validateSpellLike(element);
        }, this);

        let commander = findCommander(commanderName);
        spells.forEach(function (spell) {
            commander.spellbook.push(spell);
        }, this);


        return this;
    };

    let findArmyUnitById = function (id) {
        return units.find(u => u.id === id);
    };

    let findCommanders = function (query) {
        let result = [];
        let name = query.name;
        let alignment = query.alignment;

        commanders.forEach(function (element) {
            if (name !== undefined) {
                if (alignment !== undefined) {
                    if (element.name === name && element.alignment === alignment) {
                        result.push(element);
                    }
                } else {
                    if (element.name === name) {
                        result.push(element);
                    }
                }
            } else {
                if (alignment !== undefined) {
                    if (element.alignment === alignment) {
                        result.push(element);
                    }
                }
            }

        }, this);

        result.sort(function (a, b) {
            return a.name - b.name;
        });

        return result;
    };

    let findArmyUnits = function (query) {
        let result = [];
        let name = query.name;
        let alignment = query.alignment;

        if (query.id) {
            return this.findArmyUnitById(query.id);
        }

        commanders.forEach(function (com) {
            com.army.forEach(function (element) {
                if (name !== undefined) {
                    if (alignment !== undefined) {
                        if (element.name === name && element.alignment === alignment) {
                            result.push(element);
                        }
                    } else {
                        if (element.name === name) {
                            result.push(element);
                        }
                    }
                } else {
                    if (alignment !== undefined) {
                        if (element.alignment === alignment) {
                            result.push(element);
                        }
                    }
                }
            }, this);


        }, this);

        result.sort(function (a, b) {
            let ret = b.speed - a.speed;
            if (ret === 0) {
                return a.name - b.name;
            }
            return ret;
        });

        return result;
    };

    let battle = function (attacker, defender) {
        validator.validateUnitLike(attacker);
        validator.validateUnitLike(defender);

        let damage = attacker.damage * attacker.count;
        let defence = defender.health * defender.count;

        defence -= damage;

        let newCount = Math.ceil(defence / defender.health);
        if (newCount < 0) {
            newCount = 0;
        }

        defender.count = newCount;

        return this;
    };

    let spellcast = function (casterName, spellName, targetId) {
        let commander = 0;

        commanders.forEach(function (element) {
            if (element.name === casterName) {
                commander = element;
            }
        }, this);

        if (commander === 0) {
            throw new Error("Can\'t cast with non-existant commander " + casterName + '!');
        }

        let spell = 0;

        commander.spellbook.forEach(function (element) {
            if (element.name === spellName) {
                spell = element;
            }
        }, this);

        if (spell === 0) {
            throw new Error(casterName + " doesn\'t know " + spellName);
        }

        if (commander.mana < spell.manaCost) {
            throw new Error('Not enough mana!');
        }

        let unit = findArmyUnitById(targetId);

        if (unit === undefined) {
            throw new Error('Target not found!');
        }

        spell.effect(unit);

        commander.mana -= spell.manaCost;

        return this;
    };

    const battlemanager = {
        getCommander: getCommander,
        getArmyUnit: getArmyUnit,
        getSpell: getSpell,
        addCommanders: addCommanders,
        addArmyUnitTo: addArmyUnitTo,
        addSpellsTo: addSpellsTo,
        findArmyUnitById: findArmyUnitById,
        findCommanders: findCommanders,
        findArmyUnits: findArmyUnits,
        battle: battle,
        spellcast: spellcast
    };

    return battlemanager;
}

module.exports = solve;