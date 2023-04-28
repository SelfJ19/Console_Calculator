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

        dispatchTable["add1"] = new Action<string>((p1) => calculator.Addition(p1));
        dispatchTable["add"] = new Action<string, string>((p1, p2) => calculator.Addition(p1, p2));
        dispatchTable["subtract1"] = new Action<string>((p1) => calculator.Subtraction(p1));
        dispatchTable["subtract"] = new Action<string, string>((p1, p2) => calculator.Subtraction(p1, p2));
        dispatchTable["multiply1"] = new Action<string>((p1) => calculator.Multiplication(p1));
        dispatchTable["multiply"] = new Action<string, string>((p1, p2) => calculator.Multiplication(p1, p2));
        dispatchTable["divide1"] = new Action<string>((p1) => calculator.Division(p1));
        dispatchTable["divide"] = new Action<string, string>((p1, p2) => calculator.Division(p1, p2));
        dispatchTable["mod1"] = new Action<string>((p1) => calculator.Modulus(p1));
        dispatchTable["mod"] = new Action<string, string>((p1, p2) => calculator.Modulus(p1, p2));
        dispatchTable["sq1"] = new Action(() => calculator.Square());
        dispatchTable["sq"] = new Action<string>((p1) => calculator.Square(p1));
        dispatchTable["sqrt1"] = new Action(() => calculator.SquareRoot());
        dispatchTable["sqrt"] = new Action<string>((p1) => calculator.SquareRoot(p1));
        dispatchTable["exponentiate1"] = new Action<string>((p1) => calculator.Exponentiate(p1));
        dispatchTable["exponentiate"] = new Action<string, string>((p1, p2) => calculator.Exponentiate(p1, p2));
        dispatchTable["factorial1"] = new Action(() => calculator.Factorial());
        dispatchTable["factorial"] = new Action<string>((p1) => calculator.Factorial(p1));
        dispatchTable["store1"] = new Action<string>((p1) => calculator.Store(p1));
        dispatchTable["store"] = new Action<string, string>((p1, p2) => calculator.Store(p1, p2));
        dispatchTable["exit"] = new Action(() => { isRunning = false; });
        
        while(isRunning)
        {
            try
            {
                Console.WriteLine("Please select from the following options.");
                Console.WriteLine("Enter your command as the function first & then the value(s) you want to perform the operation on.");
                Console.WriteLine("PLease be sure to include the spaces.\n");
                Console.WriteLine("// Means this is a comment that is not to be entered as part of the command");
                Console.WriteLine("===================== Calculator Options =========================\n");
                Console.WriteLine("Add1 [value1] \t\t// add this to the current value");
                Console.WriteLine("Subtract1 [value1] \t// subtract this from the current value");
                Console.WriteLine("Multiply1 [value1] \t// multiply the current value by this");
                Console.WriteLine("Divide1 [value1] \t// divide the current value by this");
                Console.WriteLine("Mod1 [value1] \t\t// mod the current value by this");
                Console.WriteLine("Sq1 \t\t\t// square the current value");
                Console.WriteLine("Sqrt1 \t\t\t// take the sqrt of the current value");
                Console.WriteLine("Exponentiate1 [value1] \t// raise the current value by this value");
                Console.WriteLine("Factorial1 \t\t// calculate the factorial of the current value");
                Console.WriteLine("Store [key] \t\t// store the current value to a key\n");
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
                Console.WriteLine("Current value:\t" + calculator.GetCurrentValue().ToString());

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