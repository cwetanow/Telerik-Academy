using System.Threading;

namespace SchoolSystem.UI.Utils
{
    public static class IdGenerator
    {
        private static int studentIdCounter;
        private static int teacherIdCounter;

        static IdGenerator()
        {
            studentIdCounter = -1;
            teacherIdCounter = -1;
        }

        public static int GenerateStudentId()
        {
            return Interlocked.Increment(ref studentIdCounter);
        }

        public static int GenerateTeacherId()
        {
            return Interlocked.Increment(ref teacherIdCounter);
        }
    }
}
