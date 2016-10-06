using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IEngineControlUnit : ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        EngineControlUnitType EngineControlUnitType { get; }
    }
}
