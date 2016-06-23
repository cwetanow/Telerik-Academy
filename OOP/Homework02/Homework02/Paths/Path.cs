using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Homework02.Point3D;
using System.Threading.Tasks;

namespace Homework02.Paths
{
    class Path
    {

        private List<Point> paths;
        public Path()
        {
            this.paths = new List<Point>();

        }
        public List<Point> Paths
        {
            get
            {
                return this.paths;
            }
        }
        public void Add(Point point)
        {
            this.paths.Add(point);
        }

        public void Remove(Point point)
        {

            this.paths.Remove(point);

        }
        public override string ToString()
        {
            var stringer = new StringBuilder();
            foreach (var item in this.paths)
            {
                stringer.Append(item);
                stringer.Append(" ");
            }
            return stringer.ToString();
        }
    }

}
