using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Helper
{
    internal class JsonHelper
    {
        public static bool IsBasicNode(JToken node)
        {
            if (node.Children().Count() != 1)
                return false;
            if (node.Children().First().Children().Count() != 0)
                return false;
            return true;
        }
    }
}
