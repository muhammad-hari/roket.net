using Newtonsoft.Json;
using Roket.NET.Documents;
using Roket.NET.Watchers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            

                Console.ReadLine();

        }



        public static void Test()
        {
            DocumentConvertion document = new DocumentConvertion();

            var g = new Grid();

            var data = document.ConvertCsvToJsonAsync(@"C:\Users\muhammad.hari\Desktop\data.csv", g);

            Console.WriteLine(data.Result);

        }



       
    }


    public class Grid
    {
        public int No { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

  
}
