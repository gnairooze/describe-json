using JsonDiffer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.TestApp.Test
{
    public class Test1
    {
        private const string FILE1 = "Test/json1.json";
        private const string FILE2 = "Test/json2.json";

        private string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void Test11()
        {
            Console.WriteLine("Test11");
            var j1 = JToken.Parse(ReadFile(FILE1));
            var j2 = JToken.Parse(ReadFile(FILE2));

            var diff = JsonDifferentiator.Differentiate(j1, j2);

            Console.WriteLine(diff);
        }

        public void Test12()
        {
            Console.WriteLine("Test12");
            var j1 = JToken.Parse(ReadFile(FILE1));
            var j2 = JToken.Parse(ReadFile(FILE2));

            var diff = JsonDifferentiator.Differentiate(j1, j2, showValues: ShowValuesOptions.New);

            Console.WriteLine(diff);
        }

        public void Test13()
        {
            Console.WriteLine("Test13");
            var j1 = JToken.Parse(ReadFile(FILE1));
            var j2 = JToken.Parse(ReadFile(FILE2));

            var diff = JsonDifferentiator.Differentiate(j1, j2, OutputMode.Detailed);

            Console.WriteLine(diff);
        }

        public void Test14()
        {
            Console.WriteLine("Test14");
            var j1 = JToken.Parse(ReadFile(FILE1));
            var j2 = JToken.Parse(ReadFile(FILE2));

            var diff = JsonDifferentiator.Differentiate(j1, j2, OutputMode.Detailed, showValues: ShowValuesOptions.OriginalAndNew);

            Console.WriteLine(diff);
        }
    }
}
