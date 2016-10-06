using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.EngineControlUnits.Abstract
{
    public abstract class EngineControlUnit : TunningPart,IEngineControlUnit, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        private EngineControlUnitType engineControlUnitType;

        public EngineControlUnit(           
            int weight, 
            decimal price,
            int acceleration,
            int topSpeed,
            TunningGradeType gradeType,
            EngineControlUnitType engineControlUnitType): base(weight,price,topSpeed,acceleration,gradeType)
        {
        }

       

        public EngineControlUnitType EngineControlUnitType
        {
            get
            {
                return this.engineControlUnitType;
            }
        }

        
    }
}
