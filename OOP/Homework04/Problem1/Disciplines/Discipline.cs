using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Disciplines
{
    public class Discipline
    {
        private string name;
        private int lectures;
        private int exercises;

        public int Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }
        
        public int Lectures
        {
            get { return this.lectures; }
            set { this.lectures = value; }
        }
        
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = value;
            }
        }
        public Discipline(string name, int numOfLectures, int numOfExercises)
        {
            this.Name = name;
            this.Lectures = numOfLectures;
            this.Exercises = numOfExercises;
        }
        public override string ToString()
        {
            return string.Format("{0} Lectures: {1}, Exercises: {2}",this.Name,this.Lectures,this.Exercises);
        }

    }
}
