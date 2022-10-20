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
            {
                #region if node is array with basic values
                var firstChild = node.Children().First();

                if (firstChild.GetType() == typeof(JArray))
                {
                    foreach (var grandChild in firstChild.Children())
                    {
                        if (grandChild.GetType() != typeof(JValue))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                #endregion

                return false;
            }
            return true;
        }
    }
}
