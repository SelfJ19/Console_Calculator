using Microsoft.CSharp.RuntimeBinder;
using Project5;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static Dictionary<string, dynamic> dispatchTable = new();

    public static void Main(string[] args)
    {
        bool isRunning = true;
        Calculator calculator = new Calculator();

        dispatchTable["add"] = new Action<string, string>((p1, p2) => calculator.Addition(p1, p2));
        dispatchTable["subtract"] = new Action<string, string>((p1, p2) => calculator.Subtraction(p1, p2));
        dispatchTable["multiply"] = new Action<string, string>((p1, p2) => calculator.Multiplication(p1, p2));
        dispatchTable["divide"] = new Action<string, string>((p1, p2) => calculator.Division(p1, p2));
        dispatchTable["mod"] = new Action<string, string>((p1, p2) => calculator.Modulus(p1, p2));
        dispatchTable["sq"] = new Action<string>((p1) => calculator.Square(p1));
        dispatchTable["sqrt"] = new Action<string>((p1) => calculator.SquareRoot(p1));
        dispatchTable["exponentiate"] = new Action<string, string>((p1, p2) => calculator.Exponentiate(p1, p2));
        dispatchTable["factorial"] = new Action<string>((p1) => calculator.Factorial(p1));
        dispatchTable["store"] = new Action<string, string>((p1, p2) => calculator.Store(p1, p2));
        dispatchTable["exit"] = new Action(() => { isRunning = false; });
        
        while(isRunning)
        {
            try
            {
                Console.WriteLine("Please select from the following options.");
                Console.WriteLine("Enter your command as the function first & then the value(s) you want to perform the operation on.");
                Console.WriteLine("PLease be sure to include the spaces.\n");
                Console.WriteLine("===================== Calculator Options =========================\n");
                Console.WriteLine("Add [value1] [value2]");
                Console.WriteLine("Subtract [value1] [value2]");
                Console.WriteLine("Multiply [value1] [value2]");
                Console.WriteLine("Divide [value1] [value2]");
                Console.WriteLine("Mod [value1] [value2]");
                Console.WriteLine("Sq [value]");
                Console.WriteLine("Sqrt [value]");
                Console.WriteLine("Exponentiate [value1] [value2]");
                Console.WriteLine("Factorial [value]");
                Console.WriteLine("Store [key] [value]");
                Console.WriteLine("Exit");
                Console.WriteLine("==================================================================\n");

                string[] input = Console.ReadLine().ToLower().Split(" ");
                if (input.Length == 3)
                {
                    dispatchTable[input[0]](input[1], input[2]);
                    Console.WriteLine(calculator.GetCurrentValue()+"\n");
                }
                else if (input.Length == 2)
                {
                    dispatchTable[input[0]](input[1]);
                    Console.WriteLine(calculator.GetCurrentValue()+"\n");
                }
                else if (input.Length == 1)
                {
                    dispatchTable[input[0]]();
                }
            } catch (RuntimeBinderException e) { Console.WriteLine("You need to enter a value or values based on which option you choose.\n"); }
            catch (KeyNotFoundException e) { Console.WriteLine("That is not a valid operation.\n"); }
            catch (Exception e){ Console.WriteLine(e.Message); }
        }
    }
}