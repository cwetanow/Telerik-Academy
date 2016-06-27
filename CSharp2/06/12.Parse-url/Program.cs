using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Parse_url
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder protocol = new StringBuilder();
            StringBuilder server = new StringBuilder();
            StringBuilder resource = new StringBuilder();
            protocol.Append("[protocol] = ");
            server.Append("[server] = ");
            resource.Append("[resource] = ");
          
            for (int i = 0; i < input.IndexOf("://"); i++)
            {
                protocol.Append(input[i]);
            }
            for (int i = input.IndexOf("://")+3; i < input.IndexOf("/", input.IndexOf("://")+5); i++)
            {
                server.Append(input[i]);
            }
            for (int i = input.IndexOf("/", input.IndexOf("://") + 5); i < input.Length; i++)
            {
                resource.Append(input[i]);
            }
            Console.WriteLine(protocol.ToString());
            Console.WriteLine(server.ToString());
            Console.WriteLine(resource.ToString());
        }
    }
}
