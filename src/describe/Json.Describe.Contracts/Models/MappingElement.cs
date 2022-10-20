using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Models
{
    public class MappingElement
    {
        public string Name { get; set; } = string.Empty;
        public string MappedName { get;set; } = string.Empty;
        public string DescriptionTemplate { get; set; } = string.Empty;
        public bool ShowInDescription { get; set; }
    }
}
