using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Enigmanation
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            int result=0;
            int temporaryResult=0;
            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case '(':
                        switch (code[i+2])
	                    {   
                            case '+':
                                temporaryResult = (code[i + 1] - '0') + (code[i + 3] - '0');
                                break;
                            case '-':
                                 temporaryResult = (code[i + 1] - '0') - (code[i + 3] - '0');
                                 break;
                            case '%':
                                 temporaryResult = (code[i + 1] - '0') % (code[i + 3] - '0');
                                 break;
                            default:        
                                temporaryResult = (code[i + 1] - '0') * (code[i + 3] - '0');
                                break;            
	                    }
                        i += 5;
                        result+=temporaryResult;
                            break;
                    case '+':
                            {
                                if (code[i + 1] == '(')
                                {
                                    switch (code[i + 3])
                                    {
                                        case '+':
                                            temporaryResult = (code[i + 1] - '0') + (code[i + 3] - '0');
                                            break;
                                        case '-':
                                            temporaryResult = (code[i + 1] - '0') - (code[i + 3] - '0');
                                            break;
                                        case '%':
                                            temporaryResult = (code[i + 1] - '0') % (code[i + 3] - '0');
                                            break;
                                        default:
                                            temporaryResult = (code[i + 1] - '0') * (code[i + 3] - '0');
                                            break;
                                    }
                                }
                                result += temporaryResult;
                                break;
                            }


                    default:
                        break;
                }
            }
        Console.WriteLine(result);
        }
        
    }
}
