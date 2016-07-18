using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IIntercooler : ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        IntercoolerType IntercoolerType { get; }
    }
}
