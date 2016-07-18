using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class EnhancedHoldingPen : HoldingPen
    {
        private static List<ISupplement> supps =new List<ISupplement>{
            new AggressionCatalyst(),
            new HealthCatalyst(),
            new InfestationSpores(),
            new Weapon()
        };
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unit = this.GetUnit(commandWords[2]);
            unit.AddSupplement(supps.Where(x=>x.GetType().Name==commandWords[1]).FirstOrDefault());
        }
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var paro = new Parasite(commandWords[2]);
                    this.InsertUnit(paro);
                    break;
                default:
                    break;
            }
        }
    }
}

