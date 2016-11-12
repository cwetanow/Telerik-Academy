using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Services
{
    public interface ISchoolService
    {
        int AddStudent(IStudent student);

        int AddTeacher(ITeacher teacher);

        IStudent GetStudentById(int studentId);

        ITeacher GetTeacherById(int teacherId);

        void RemoveTeacher(int teacherId);

        void RemoveStudent(int studentId);
    }
}
