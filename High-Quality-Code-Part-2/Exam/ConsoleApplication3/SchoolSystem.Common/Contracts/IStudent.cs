using System.Collections.Generic;

namespace SchoolSystem.Common.Contracts
{
    public interface IStudent
    {
        string ListMarks();

        void AddMark(IMark mark);

        ICollection<IMark> Marks { get; }
    }
}
