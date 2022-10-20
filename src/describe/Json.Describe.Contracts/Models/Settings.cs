using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Models
{
    public class Settings
    {
        /// <summary>
        /// changes prefix is one of (+ - *) before the property name to indicate (add remove change)
        /// </summary>
        public bool UseChangesPrefix { get; set; }
    }
}
