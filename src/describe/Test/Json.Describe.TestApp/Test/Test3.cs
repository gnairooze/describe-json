using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Describe.Contracts.Repository;
using Json.Describe.Contracts.Models;

namespace Json.Describe.TestApp.Test
{
    public class Test3
    {
        private const string FILE1 = "Test/json1.json";
        private const string FILE2 = "Test/json2.json";
        private const string FILE5 = "Test/json5.json";
        private const string FILE3 = "Test/diff0102-detailed-originalAndNew.json";
        private const string FILE4 = "Test/diff0102-symbol-originalAndNew.json";

        private string ReadFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void Test31()
        {
            Console.WriteLine("Test31");

            var j = JObject.Parse(ReadFile(FILE5));

            List<MappingElement> mappingElements = new();

            Json.Describe.Manager manager = new(new MemoryMappingElementRepository(mappingElements), new Settings() { UseChangesPrefix = false});

            var elements = manager.Run(j);

            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }

            var result = JsonConvert.SerializeObject(elements);
            File.WriteAllText("processed-elements.json", result);
        }

        public void Test32()
        {
            Console.WriteLine("Test32");

            var j = JObject.Parse(ReadFile(FILE3));

            List<MappingElement> mappingElements = new();

            Json.Describe.Manager manager = new(new MemoryMappingElementRepository(mappingElements), new Settings() { UseChangesPrefix = false });

            var elements = manager.Run(j);

            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }

            var result = JsonConvert.SerializeObject(elements);
            File.WriteAllText("processed-elements.json",result);

        }
    
        public void Test33()
        {
            JObject test = new JObject();
            test.Add("name", "jona");

            Console.WriteLine(test);
        }
    }
}
