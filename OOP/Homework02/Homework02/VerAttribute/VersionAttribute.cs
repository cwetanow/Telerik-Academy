using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.VerAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Enum)]
    class VersionAttribute : Attribute
    {
        private int major;
        private int minor;
        public int Major
        {
            get
            { return this.major; }
            private set
            {
                this.major = value;
            }
        }
        public int Minor
        {
            get
            { return this.minor; }
            private set
            {
                this.minor = value;
            }
        }
        public VersionAttribute(int minor, int major)
        {
            this.Major = major;
            this.Minor = minor;
        }
        public override string ToString()
        {
            return string.Format("Version {0}.{1}", this.Minor, this.Major) ;
        }

    }
}
