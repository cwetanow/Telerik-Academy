using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingIdentifiers.class_123
{
    public class Writer
    {
        public void WriteVariableAsString(bool variable)
        {
            var variableAsString = variable.ToString();
            Console.WriteLine(variableAsString);
        }
    }
}
