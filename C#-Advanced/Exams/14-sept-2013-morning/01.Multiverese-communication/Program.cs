using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Multiverese_communication
{
    class Program
    {
        static ulong GetNum(string code) {
            
            switch (code)
            {
                case "CHU":
                    return 0;
                case "TEL":
                    return 1;
                case "OFT":
                    return 2;
                case "IVA":
                    return 3;
                case "EMY":
                    return 4;
                case "VNB":
                    return 5;
                case "POQ":
                    return 6;
                case "ERI":
                    return 7;
                case "CAD":
                    return 8;
                case "K-A":
                    return 9;
                case "IIA":
                    return 10;
                case "YLO":
                    return 11;
                default:
                    return 12;
                    
            }
            
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            ulong result = 0;
            var temp=new StringBuilder();
            for (int i = 0; i < input.Length; i+=3)
            {
                temp.Clear();
                temp.Append(input[i]);
                temp.Append(input[i+1]);
                temp.Append(input[i+2]);
                result += GetNum(temp.ToString())*(ulong)Math.Pow(13,Double.Parse(((input.Length/3)-1-i/3).ToString()));
            }
            Console.WriteLine(result);
        }
    }
}
