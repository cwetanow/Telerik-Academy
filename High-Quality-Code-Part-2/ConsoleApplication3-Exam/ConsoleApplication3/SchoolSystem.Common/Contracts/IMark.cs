using SchoolSystem.Common.Enumerations;

namespace SchoolSystem.Common.Contracts
{
    public interface IMark
    {
        Subject Subject { get; }

        float Value { get; }
    }
}
