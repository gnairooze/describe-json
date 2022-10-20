using Json.Describe.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Interfaces
{
    public interface IMappingElementRepository
    {
        List<MappingElement> LoadMappings();
    }
}
