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
        double answer = 0;
        // calcState = dispatch[cmd](p1,p2)
        // stack of answers to pop the previous result
        public double GetCurrentValue()
        {
            return answer;
        }

        #region Addition()
        public void Addition(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = a + b;
        }
        #endregion

        #region Subtraction()
        public void Subtraction(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = a - b;
        }
        #endregion

        #region Multiply()
        public void Multiplication(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = a * b;
        }
        #endregion

        #region Divide()
        public void Division(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = a / b;
        }
        #endregion

        #region Mod()
        public void Modulus(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = a % b;
        }
        #endregion

        #region Square()
        public void Square(string p1)
        {
            double a = double.Parse(p1);
            answer = Math.Pow(a, 2);
        }
        #endregion

        #region Sqrt()
        public void SquareRoot(string p1)
        {
            double a = double.Parse(p1);
            answer = Math.Sqrt(a);
        }
        #endregion

        #region Exponential()
        public void Exponentiate(string p1, string p2)
        {
            double a = double.Parse(p1);
            double b = double.Parse(p2);
            answer = Math.Pow(a, b);
        }
        #endregion

        #region Factorial()
        public void Factorial(string p1)
        {
            double total = 1;
            double a = double.Parse(p1);
            if (a < 0)
            {
                throw new Exception("Can not do the factorial of a negative value.");
            }
            
                for (double i = a; i > 0; i--)
                {
                   total *= i;
                }
            answer = total;
            
        }
        #endregion
    }
}
