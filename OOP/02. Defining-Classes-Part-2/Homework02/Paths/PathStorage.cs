using Homework02.Point3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework02.Paths
{
    static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {

            var writer = new StreamWriter(fileName + ".txt");

            writer.WriteLine(path.ToString());
            writer.Close();
        }
        public static Path LoadPath(string fileName)
        {
            var reader = new StreamReader(fileName + ".txt");
            var temp = reader.ReadToEnd();
            reader.Close();
            var points = temp.Split(new char[] { '[', ']', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var newPath = new Path();
            for (int i = 0; i < points.Length - 1; i += 3)
            {
                var temporary = new Point(double.Parse(points[i]), double.Parse(points[i + 1]), double.Parse(points[i + 2]));
                newPath.Add(temporary);
            }
            
            return newPath;
        }

    }
}
