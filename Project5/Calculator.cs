using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    internal class Calculator
    {
        Dictionary<string, double> variables = new();
        // stack of answers to pop the previous result
        #region GetCurrentValue()
        public double GetCurrentValue()
        {
            return variables.ContainsKey("currentValue") ? variables["currentValue"] : 0;
        }
        #endregion

        #region Store()
        public void Store(string key, string value)
        {
            double x;
            double.TryParse(value, out x);
            variables[key] = x;
        }
        #endregion

        #region Parse()
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
        public void Addition(string p1)
        {
            double b = Parse(p1);
            variables["currentValue"] = this.GetCurrentValue() + b;
        }
        #endregion

        #region Add(p1,p2)
        public void Addition(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = a + b;
        }
        #endregion

        #region Subtraction(p1)
        public void Subtraction(string p1)
        {
            double b = Parse(p1);
            variables["currentValue"] = this.GetCurrentValue() - b;
        }
        #endregion

        #region Subtraction(p1,p2)
        public void Subtraction(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = a - b;
        }
        #endregion

        #region Multiplication(p1)
        public void Multiplication(string p1)
        {
            double b = Parse(p1);
            variables["currentValue"] = this.GetCurrentValue() * b;
        }
        #endregion

        #region Multiply(p1,p2)
        public void Multiplication(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = a * b;
        }
        #endregion

        #region Divide(p1)
        public void Division(string p1)
        {
            double b = Parse(p1);
            variables["currentValue"] = this.GetCurrentValue() / b;
        }
        #endregion

        #region Divide(p1,p2)
        public void Division(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = a / b;
        }
        #endregion

        #region Mod(p1)
        public void Modulus(string p1)
        {
            double b = Parse(p1);
            variables["currentValue"] = this.GetCurrentValue() % b;
        }
        #endregion

        #region Mod(p1,p2)
        public void Modulus(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = a % b;
        }
        #endregion

        #region Square()
        public void Square(string p1)
        {
            double a = Parse(p1);
            variables["currentValue"] = Math.Pow(a, 2);
        }
        #endregion

        #region Sqrt()
        public void SquareRoot(string p1)
        {
            double a = Parse(p1);
            variables["currentValue"] = Math.Sqrt(a);
        }
        #endregion

        #region Exponential()
        public void Exponentiate(string p1, string p2)
        {
            double a = Parse(p1);
            double b = Parse(p2);
            variables["currentValue"] = Math.Pow(a, b);
        }
        #endregion

        #region Factorial()
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
            variables["currentValue"] = total;
            
        }
        #endregion
    }
}
