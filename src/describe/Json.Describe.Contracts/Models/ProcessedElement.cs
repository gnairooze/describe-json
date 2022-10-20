using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Models
{
    public class ProcessedElement
    {
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string RawValue { get; set; } = string.Empty;
        /// <summary>
        /// used as the main container for a value. or if the name is an array containing only two values. Add the first value in this field.
        /// </summary>
        public string FirstValue { get; set; } = string.Empty;
        public string SecondValue { get; set; } = string.Empty;
        public bool IsEndElement { get; set; }

        public string MappedName { get; set; } = string.Empty;
        public string DescriptionTemplate { get; set; } = string.Empty;
        public bool ShowInDescription { get; set; }
        
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
