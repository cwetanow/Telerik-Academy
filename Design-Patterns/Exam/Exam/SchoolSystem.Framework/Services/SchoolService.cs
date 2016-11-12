using System;
using SchoolSystem.Framework.Data;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Utils;

namespace SchoolSystem.Framework.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<ITeacher> teachers;
        private readonly IRepository<IStudent> students;

        private readonly IIdProvider idProvider;

        public SchoolService(IIdProvider provider,
            IRepository<IStudent> studentRepository,
            IRepository<ITeacher> teacherRepository)
        {
            this.idProvider = provider;

            this.teachers = teacherRepository;
            this.students = studentRepository;
        }

        public int AddStudent(IStudent student)
        {
            var id = this.idProvider.GenerateStudentId();

            this.students.Entities.Add(id, student);

            return id;
        }

        public int AddTeacher(ITeacher teacher)
        {
            var id = this.idProvider.GenerateTeacherId();

            this.teachers.Entities.Add(id, teacher);

            return id;
        }

        public IStudent GetStudentById(int studentId)
        {
            return students.Entities[studentId];
        }

        public ITeacher GetTeacherById(int teacherId)
        {
            return teachers.Entities[teacherId];

        }

        public void RemoveTeacher(int teacherId)
        {
            if (!this.teachers.Entities.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.teachers.Entities.Remove(teacherId);
        }

        public void RemoveStudent(int studentId)
        {
            this.students.Entities.Remove(studentId);
        }
    }
}
