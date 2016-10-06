using FastAndFurious.ConsoleApplication.Common.Enums;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITunningPart : IAccelerateable, ITopSpeed, IWeightable, IValuable, IIdentifiable<int>
    {
        int Id { get; }
        TunningGradeType GradeType { get; }
    }
}
