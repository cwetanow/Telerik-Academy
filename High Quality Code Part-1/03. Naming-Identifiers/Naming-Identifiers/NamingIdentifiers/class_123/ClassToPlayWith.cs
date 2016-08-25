using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingIdentifiers.class_123
{
    class ClassToPlayWith
    {
        private const int MaxCount = 6;

        class InnerClassToHaveMoreFun
        {
            public void WriteVariableAsString(bool variable)
            {
                var variableAsString = variable.ToString();
                Console.WriteLine(variableAsString);
            }
        }

        public static void EntryMethod()
        {
            var innerClassInstance = new InnerClassToHaveMoreFun();
            innerClassInstance.WriteVariableAsString(true);
        }
    }
}
