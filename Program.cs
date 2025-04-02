using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prKol_ind1_KM
{
    class Program
    {
        static void Main(string[] args)
        {
            string express = "(A + B) * (C + D)";
            Console.WriteLine(express);

            char[] infArr = express.ToCharArray();
            Array.Reverse(infArr);
            string reversInf = new string(infArr);

            Stack<char> oper = new Stack<char>();
            Stack<string> oprn = new Stack<string>();

            foreach (char item in reversInf)
            {
                if (char.IsLetterOrDigit(item))
                {
                    oprn.Push(item.ToString());
                }
                else if (item == ')')
                {
                    oper.Push(item);
                }
                else if (item == '(')
                {
                    while (oper.Count > 0 && oper.Peek() != ')')
                    {
                        string op1 = oprn.Pop();
                        string op2 = oprn.Pop();
                        char op = oper.Pop();
                        string temp = op + op1 + op2;

                        oprn.Push(temp);
                    }
                    oper.Pop();
                }
                else if (IsOperator(item))
                {
                    while (oper.Count > 0 && Preced(oper.Peek()) > Preced(item))
                    {
                        string op1 = oprn.Pop();
                        string op2 = oprn.Pop();
                        char op = oper.Pop();
                        string temp = op + op1 + op2;

                        oprn.Push(temp);
                    }
                    oper.Push(item);
                }
            }
            while (oper.Count > 0)
            {
                string op1 = oprn.Pop();
                string op2 = oprn.Pop();
                char op = oper.Pop();
                string temp = op + op1 + op2;
                oprn.Push(temp);
            }

            Console.WriteLine(oprn.Pop());

            Console.ReadLine();
        }

        static bool IsOperator(char c) => "+-*/^".Contains(c);

        static int Preced(char op)
        {
            switch (op)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }   
        }
    }
}
