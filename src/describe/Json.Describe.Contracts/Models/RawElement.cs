using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Models
{
    public class RawElement
    {
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get;set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsEndElement { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
