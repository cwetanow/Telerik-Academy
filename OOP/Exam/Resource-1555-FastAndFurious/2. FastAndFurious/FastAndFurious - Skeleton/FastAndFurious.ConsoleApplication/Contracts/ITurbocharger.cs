using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITurbocharger : ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        TurbochargerType TurbochargerType { get; }
    }
}
