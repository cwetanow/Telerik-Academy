using System.Threading;

namespace SchoolSystem.Framework.Utils
{
    public class ThreadIdProvider : IIdProvider
    {
        private int teacherId;
        private int studentId;

        public ThreadIdProvider()
        {
            this.teacherId = -1;
            this.studentId = -1;
        }

        public int GenerateTeacherId()
        {
            return Interlocked.Increment(ref teacherId);
        }

        public int GenerateStudentId()
        {
            return Interlocked.Increment(ref studentId);
        }
    }
}
