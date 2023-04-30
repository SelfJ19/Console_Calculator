///////////////////////////////////////////////////////////////////////////////
//
// Author: Jason Self, selfj1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 5 - Calculator
// Description: Creates a file manager class to save variables to a file & to read variables from a file
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Project5
{
    /// <summary>
    /// Creates the file manager class that allows the program to save variables to a file and read variables from a file
    /// </summary>
    public class FileManager
    {
        #region Attributes
        /// <summary>
        /// path to save the variables too
        /// </summary>
        public string filePath = "../../variables.yaml";
        #endregion

        #region SaveFile()
        /// <summary>
        /// this is the link I used to figure out how to store the variables in a yaml doc https://github.com/aaubry/YamlDotNet
        /// </summary>
        /// <param name="calculator">the instance of the calculator to be saved</param>
        public void SaveToFile(Calculator calculator)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(calculator.variables);
            File.WriteAllText(filePath, yaml);
            Console.WriteLine("Variables saved\n");
        }
        #endregion

        #region LoadFile()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="calculator"></param>
        public void LoadFromFile(Calculator calculator)
        {
            string[] line = File.ReadAllText(filePath).Split("\n");
            Dictionary<string, dynamic> loadedVariables = new();
            for(int i = 0; i < line.Length - 1; i++)
            {
                string[] array = line[i].Split(":");
                loadedVariables[array[0]] = double.Parse(array[1]);
            }
            calculator.variables = loadedVariables;
            Console.WriteLine("Varaibles Loaded");
        }
        #endregion
    }
}
