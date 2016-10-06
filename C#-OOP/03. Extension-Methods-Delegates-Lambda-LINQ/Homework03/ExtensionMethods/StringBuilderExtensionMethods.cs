using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03.ExtensionMethods
{
    //Task 1
    static class StringBuilderExtensionMethods
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length) {
            var result = new StringBuilder();
            result.Append(builder.ToString().Substring(index,length));
            return result;
        }
    }
}
