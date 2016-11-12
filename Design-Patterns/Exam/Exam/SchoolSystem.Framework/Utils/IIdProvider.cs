namespace SchoolSystem.Framework.Utils
{
    public interface IIdProvider
    {
        int GenerateTeacherId();

        int GenerateStudentId();
    }
}
