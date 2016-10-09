using System;
using System.Collections.Generic;
using SchoolSystem.Common.Models;
using SchoolSystem.UI.Models.Contracts;
using SchoolSystem.UI.Utils;

namespace SchoolSystem.UI.Models
{
    public static class Engine
    {
        private static IReader reader;
        private static IWriter writer;
        private static ICommandParser commandParser;

        private static IDictionary<int, Teacher> Teachers { get; set; }

        private static IDictionary<int, Student> Students { get; set; }

        public static void Start(IReader reader, IWriter writer, ICommandParser parser)
        {
            Setup(reader, writer, parser);

            var command = reader.ReadLine();

            while (command != GlobalConstants.EndExecutionCommand)
            {
                try
                {
                    var result = commandParser.ParseCommand(command);

                    writer.WriteLine(result);
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }

                command = reader.ReadLine();
            }
        }

        public static Student GetStudentById(int id)
        {
            var student = Students[id];

            return student;
        }

        public static Teacher GetTeacherById(int id)
        {
            var teacher = Teachers[id];

            return teacher;
        }

        public static bool RemoveStudent(int id)
        {
            var result = Students.Remove(id);

            return result;
        }

        public static bool RemoveTeacher(int id)
        {
            var result = Teachers.Remove(id);

            return result;
        }

        public static void AddStudent(int id, Student student)
        {
            Students.Add(id, student);
        }

        public static void AddTeacher(int id, Teacher teacher)
        {
            Teachers.Add(id, teacher);
        }

        private static void Setup(IReader newReader, IWriter newWriter, ICommandParser parser)
        {
            reader = newReader;
            writer = newWriter;
            commandParser = parser;

            Teachers = new Dictionary<int, Teacher>();
            Students = new Dictionary<int, Student>();
        }
    }
}
