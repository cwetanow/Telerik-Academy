using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITransmission : ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        TransmissionType TransmissionType { get; }
    }
}
