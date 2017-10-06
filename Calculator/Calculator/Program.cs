using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        static Mediator med = new Mediator();
        #region Storing
        public static string StoringId()
        {
            string idOperation = "";
            Console.WriteLine("Do you want to make a saving of the operation you are going to carry out?(Yes(Y)/No(N))");
            string command = Console.ReadLine();
            switch (command.ToLowerInvariant().Trim())
            {
                case "yes":
                case "y":
                    do
                    {
                        Console.WriteLine("Type the id you want to use to make the saving: ");
                        idOperation = Console.ReadLine();
                    } while (String.IsNullOrEmpty(idOperation) && String.IsNullOrWhiteSpace(idOperation));
                    break;
                case "no":
                case "n":
                    Console.WriteLine("The operation won't be stored");
                    break;
                default:
                    Console.WriteLine("Command introduced isn't listed. Default response: \"no\".");
                    break;
            }
            return idOperation;
        }
        #endregion
        #region Menu
        public static void CalcMenu(string trackingId)
        {
            Console.WriteLine("Welcome to our Calculator's Menu. Type an option to start working or \"Exit\" to finish and go out.");
            Console.WriteLine(" 1. Addition");
            Console.WriteLine(" 2. Subtraction");
            Console.WriteLine(" 3. Multiply");
            Console.WriteLine(" 4. Division");
            Console.WriteLine(" Exit ");

            string opt = Console.ReadLine();
            switch (opt.ToLowerInvariant().Trim())
            {
                case "1":
                case "addition":
                    med.Add(trackingId);
                    break;
                case "2":
                case "subtraction":
                    med.Subt(trackingId);
                    break;
                case "3":
                case "multiply":
                    med.Mult(trackingId);
                    break;
                case "4":
                case "division":
                    med.Div(trackingId);
                    break;
                case "exit":
                    Environment.Exit(255);
                    break;
                default:
                    Console.WriteLine("The command introduced is invalid. The options you can type are: addition, subtraction, multiply, division or exit");
                    break;
            }
        }
        #endregion
        #region ProgramCalls
        static void Main(string[] args)
        {
            string id = StoringId();
            CalcMenu(id);
            Thread.Sleep(5000);
        }
        #endregion
    }
}
