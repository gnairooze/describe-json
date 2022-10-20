using JsonDiffer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Json.Describe.TestApp.Test
{
    public class Test2
    {
        public void Test21()
        {
            Console.WriteLine("Test21");

            var j1 = JToken.Parse(SampleJsonData.Sample01);
            var j2 = JToken.Parse(SampleJsonData.Sample02);

            var diff = JsonDiffer.JsonDifferentiator.Differentiate(j1, j2, OutputMode.Detailed, ShowValuesOptions.OriginalAndNew);

            Console.WriteLine(diff);

            File.WriteAllText("diff0102-detailed-originalAndNew.json", diff.ToString());
        }

        public void Test22()
        {
            Console.WriteLine("Test22");

            var j1 = JToken.Parse(SampleJsonData.Sample01);
            var j2 = JToken.Parse(SampleJsonData.Sample02);

            var diff = JsonDiffer.JsonDifferentiator.Differentiate(j1, j2, OutputMode.Symbol, ShowValuesOptions.OriginalAndNew);

            Console.WriteLine(diff);

            File.WriteAllText("diff0102-symbol-originalAndNew.json", diff.ToString());
        }
    }
}
