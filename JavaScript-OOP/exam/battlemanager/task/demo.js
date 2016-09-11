'use strict';

const result = require('./solution'),
    // helpers
    toStringArmyUnit = t => `${t.alignment} ${t.name}(id: ${t.id}) - dmg: ${t.damage}, health: ${t.health}, speed: ${t.speed}, count: ${t.count}`,
    toStringSpell = s => `${s.name} - cost: ${s.manaCost}`,
    battlemanager = result();

const horses = battlemanager.getArmyUnit({
        name: 'Horses',
        alignment: 'neutral',
        damage: 10,
        health: 70,
        count: 40,
        speed: 70
    }),
    programmers = battlemanager.getArmyUnit({
        name: 'Devs on horses',
        alignment: 'good',
        damage: 40,
        health: 10,
        count: 100,
        speed: 60
    }),
    cykiSpells = [
        battlemanager.getSpell('Confusion', 10, function (target) {
            target.alignment = 'neutral';
            target.speed -= 5;
        }),
        battlemanager.getSpell('Open vim', 20, function (target) {
            target.damage -= 5;
        })
    ],
    evilStudents = battlemanager.getArmyUnit({
        name: 'Students',
        alignment: 'evil',
        damage: 15,
        health: 15,
        count: 240,
        speed: 30
    }),
    kangaroos = battlemanager.getArmyUnit({
        name: 'Kangaroos',
        alignment: 'neutral',
        damage: 50,
        health: 50,
        count: 15,
        speed: 55
    }),
    koceSpells = [
        battlemanager.getSpell('Magic arrow', 5, function (target) {
            target.count -= Math.ceil(((target.health * target.count) - 200) / target.health);
        }),
        battlemanager.getSpell('JavaScript', 40, function (target) {
            target.count -= Math.ceil(((target.health * target.count) - 1000) / target.health);
            target.damage /= 2;
            target.speed /= 2;
        })
    ];

battlemanager
    .addCommanders(battlemanager.getCommander('Cyki', 'good', 50))
    .addArmyUnitTo('Cyki', horses)
    .addArmyUnitTo('Cyki', programmers)
    .addSpellsTo('Cyki', ...cykiSpells)
    .addCommanders(battlemanager.getCommander('Koce', 'evil', 40))
    .addArmyUnitTo('Koce', evilStudents)
    .addArmyUnitTo('Koce', kangaroos)
    .addSpellsTo('Koce', ...koceSpells)
    .spellcast('Cyki', 'Confusion', battlemanager.findCommanders({ name: 'Koce' })[0].army[0].id)
    .spellcast('Cyki', 'Open vim', battlemanager.findArmyUnits({ name: 'Kangaroos' })[0].id)
    .spellcast('Koce', 'JavaScript', battlemanager.findCommanders({ name: 'Cyki' })[0].army[0].id)
    .battle(battlemanager.findCommanders({ name: 'Koce' })[0].army[1], battlemanager.findCommanders({ name: 'Cyki' })[0].army[1]);

const allCommanders = battlemanager.findCommanders({}); // all commanders: Cyki and Koce

const allTroops = battlemanager.findArmyUnits({}).map(toStringArmyUnit); // all units

const cyki = battlemanager.findCommanders({ name: 'Cyki' })[0]; // Cyki

cyki.spellbook.forEach(spell => console.log(toStringSpell(spell))); // Confusion - cost: 10, Open vim - cost: 20

const neutralTroops = battlemanager.findArmyUnits({ alignment: 'neutral' }); // Horses and Kangaroos