///////////////////////////////////////////////////////////////////////////////
//
// Author: Jason Self, selfj1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 5 - Calculator
// Description: Creates a calculator and all of its functions
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project5
{
    /// <summary>
    /// Creates the calculator class with all of its methods
    /// </summary>
    public class Calculator
    {
        #region Attributes
        /// <summary>
        /// Attribute that stores variables and their values in a dictionary
        /// </summary>
        public Dictionary<string, dynamic> variables = new();
        #endregion

        #region Calculator()
        /// <summary>
        /// Makes variables into a stck so undo is an option by using Pop
        /// </summary>
        public Calculator()
        {
            variables["currentValue"] = new Stack<double>();
        }
        #endregion

        #region GetCurrentValue()
        /// <summary>
        /// Gets the current value as long as variables contains current value and is a stack else return 0
        /// </summary>
        /// <returns>answer variables else its 0</returns>
        public double GetCurrentValue()
        {
            if (variables.ContainsKey("currentValue") && variables["currentValue"] is Stack<double>)
            {
                var answerVars = variables["currentValue"];
                return answerVars.Count == 0 ? 0 : answerVars.Peek();
            }
            return 0;
        }
        #endregion

        #region SetCurrentValue()
        /// <summary>
        /// sets answers to the value that is passed in by using Push since it is a stack
        /// </summary>
        /// <param name="value">value to be pushed to be the current value</param>
        public void SetCurrentValue(double value)
        {
            var answerVars = variables["currentValue"];
            answerVars.Push(value);
        }
        #endregion

        #region Store(prevVal)
        /// <summary>
        /// Stores the previous value into a variable
        /// </summary>
        /// <param name="key">the variable to store the previous value</param>
        public void Store(string key)
        {
            variables[key] = GetCurrentValue();
        }
        #endregion

        #region Store()
        /// <summary>
        /// stores a value into a string variable and uses regex to check if it is lowercase letters only, if not says it is unknown
        /// this is where I found how to do this https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp#:~:text=public%20static%20bool%20ContainsOnlyLetters%20%28this%20string%20input%29%20%7B,%27a%27%20and%20%3C%3D%20%27z%27%29%3B%20i%2B%2B%29%3B%20return%20isValid%3B%20%7D
        /// </summary>
        /// <param name="key">the variable that holds the value</param>
        /// <param name="value">what is getting stored as a variable</param>
        public void Store(string key, string value)
        {
            if (Regex.IsMatch(key, "^[a-z]+$"))
            {
                variables[key] = double.Parse(value);
            }
            else
            {
                Console.WriteLine("Unknown variable");
            }
        }
        #endregion

        #region Parse()
        /// <summary>
        /// Parses the value that is inputed into a double and checks to make sure it can and returns it
        /// </summary>
        /// <param name="value">what gets parsed</param>
        /// <returns>value after it is parsed into a double</returns>
        public double Parse(string value)
        {
            double x;
            if (variables.ContainsKey(value))
            {
                x = variables[value];
            }
            else
            {
                double.TryParse(value, out x);
            }
            return x;
        }
        #endregion

        #region Addition(p1)
        /// <summary>
        /// adds a value to the current value and sets the current value to that value
        /// </summary>
        /// <param name="p1">what is getting added to the current value</param>
        public void Addition(string p1)
        {
            double b = Parse(p1);
            SetCurrentValue(this.GetCurrentValue() + b);
        }
        #endregion

        #region Add(p1,p2)
        /// <summary>
        /// adds 2 values together and makes them the current value
        /// </summary>
        /// <param name="p1">the first value that is added to the second</param>
        /// <param name="p2">the second value that gets added to the first</param>
        public void Addition(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(a + b);
        }
        #endregion

        #region Subtraction(p1)
        /// <summary>
        /// subtracts a single value from the current value and updates the current value to the answer
        /// </summary>
        /// <param name="p1">the value to be subtracted</param>
        public void Subtraction(string p1)
        {
            double b = Parse(p1);
            SetCurrentValue(this.GetCurrentValue() - b);
        }
        #endregion

        #region Subtraction(p1,p2)
        /// <summary>
        /// subtracts 2 values and sets that to be the current value
        /// </summary>
        /// <param name="p1">the first value that is subtracted from</param>
        /// <param name="p2">the value that is subtracted from the first value</param>
        public void Subtraction(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(a - b);
        }
        #endregion

        #region Multiplication(p1)
        /// <summary>
        /// multiplies the current value by a single value and updates the current value to the answer
        /// </summary>
        /// <param name="p1">the value that the current value is multiplied by</param>
        public void Multiplication(string p1)
        {
            double b = Parse(p1);
            SetCurrentValue(this.GetCurrentValue() * b);
        }
        #endregion

        #region Multiply(p1,p2)
        /// <summary>
        /// multiplies 2 values together and sets the current value to it
        /// </summary>
        /// <param name="p1">the first value that is multiplied</param>
        /// <param name="p2">the second value that is multiplied</param>
        public void Multiplication(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(a * b);
        }
        #endregion

        #region Divide(p1)
        /// <summary>
        /// divides the current value by a single value and updates current value to the answer
        /// </summary>
        /// <param name="p1">the value that the current value is divided by</param>
        public void Division(string p1)
        {
            double b = Parse(p1);
            SetCurrentValue(this.GetCurrentValue() / b);
        }
        #endregion

        #region Divide(p1,p2)
        /// <summary>
        /// divides two numbers and sets the current value equal to the result
        /// </summary>
        /// <param name="p1">the value that is being divided</param>
        /// <param name="p2">the value that is dividing into the first value</param>
        public void Division(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(a / b);
        }
        #endregion

        #region Mod(p1)
        /// <summary>
        /// takes the modulus of the current value by a value that is passed into the method and updates current value to the answer
        /// </summary>
        /// <param name="p1">that value that is used to take the modulus of the current value by</param>
        public void Modulus(string p1)
        {
            double b = Parse(p1);
            SetCurrentValue(this.GetCurrentValue() % b);
        }
        #endregion

        #region Mod(p1,p2)
        /// <summary>
        /// takes one value and gets the mod based on the second value updates current value to the answer
        /// </summary>
        /// <param name="p1">value that is getting the modulus done to it</param>
        /// <param name="p2">value that is used for taking the modulus of the first value</param>
        public void Modulus(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(a % b);
        }
        #endregion

        #region Square(prevVal)
        /// <summary>
        /// squares the current value updates current value to the answer
        /// </summary>
        public void Square()
        {
            SetCurrentValue(Math.Pow(this.GetCurrentValue(), 2));
        }
        #endregion

        #region Square(p1)
        /// <summary>
        /// squares a value that is passed in and updates current value to the answer
        /// </summary>
        /// <param name="p1">the value to be squared</param>
        public void Square(string p1)
        {
            double a = Parse(p1);
            SetCurrentValue(Math.Pow(a, 2));
        }
        #endregion

        #region Sqrt(prevVal)
        /// <summary>
        /// gets the square root of the current value and updates current value to the answer
        /// </summary>
        public void SquareRoot()
        {
            SetCurrentValue(Math.Sqrt(this.GetCurrentValue()));
        }
        #endregion

        #region Sqrt(p1)
        /// <summary>
        /// gets the square root of the value that is passed in and updates current value to the answer
        /// </summary>
        /// <param name="p1">the value that the square root is calculated for</param>
        public void SquareRoot(string p1)
        {
            double a = Parse(p1);
            SetCurrentValue(Math.Sqrt(a));
        }
        #endregion

        #region Exponential(prevVal)
        /// <summary>
        /// raises the current value to the power of whatever value is passed in and sets the current value to it
        /// </summary>
        /// <param name="p1">the value that is used to raise the current value to the power of</param>
        public void Exponentiate(string p1)
        {
            double a = Parse(p1);
            SetCurrentValue(Math.Pow(this.GetCurrentValue(), a));
        }
        #endregion

        #region Exponential(p1,p2)
        /// <summary>
        /// raises a value to the second value that is passed in and sets the current value to it
        /// </summary>
        /// <param name="p1">the value that is going to be raised to a power</param>
        /// <param name="p2">the value that the first value is raised to</param>
        public void Exponentiate(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            SetCurrentValue(Math.Pow(a, b));
        }
        #endregion

        #region Factorial(prevVal)
        /// <summary>
        /// takes the current value and gets its factorial and updates current value to the answer
        /// </summary>
        /// <exception cref="Exception">exception that is thrown if the user is trying to get a factorial of a negative number</exception>
        public void Factorial()
        {
            double total = 1;
            if (variables["currentValue"] < 0)
            {
                throw new Exception("Can not do the factorial of a negative value.");
            }

            for (double i = GetCurrentValue(); i > 0; i--)
            {
                total *= i;
            }
            SetCurrentValue(total);
        }
        #endregion

        #region Factorial()
        /// <summary>
        /// gets the factorial of a value that is passed in and updates current value to the answer
        /// </summary>
        /// <param name="p1">the value that has its factorial solved</param>
        /// <exception cref="Exception">exception that is thrown in case a negative value is passed in</exception>
        public void Factorial(string p1)
        {
            double total = 1;
            double a = Parse(p1);
            if (a < 0)
            {
                throw new Exception("Can not do the factorial of a negative value.");
            }
            
                for (double i = a; i > 0; i--)
                {
                   total *= i;
                }
            SetCurrentValue(total);
        }
        #endregion

        #region Undo()
        /// <summary>
        /// Pops the last operation and prints the current value after doing so
        /// </summary>
        public void Undo()
        {
            variables["currentValue"].Pop();
            Console.WriteLine("\n==================================================================\n");
            Console.WriteLine("Current value:\t" + GetCurrentValue().ToString() + "\n");
        }
        #endregion

        #region Clear()
        /// <summary>
        /// resets the current value back to 0
        /// </summary>
        public void Clear()
        {
            SetCurrentValue(0);
        }
        #endregion

        #region Set()
        /// <summary>
        /// sets the current value to a string variable
        /// </summary>
        /// <param name="key">variable that is going to store the current value</param>
        public void Set(string key)
        {
            SetCurrentValue(variables[key]);
        }
        #endregion

        #region PrintKeys()
        /// <summary>
        /// prints each variable and its value using KeyValuePair
        /// </summary>
        public void PrintKeys()
        {
            foreach (KeyValuePair<string, dynamic> kvp in variables)
            {
                Console.WriteLine($"{kvp}");
            }
        }
        #endregion
    }
}