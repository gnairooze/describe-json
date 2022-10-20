using Json.Describe.Contracts.Interfaces;
using Json.Describe.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Describe.Contracts.Repository
{
    public class MemoryMappingElementRepository : IMappingElementRepository
    {
        private List<MappingElement> _Mappings;

        public MemoryMappingElementRepository(List<MappingElement> mappings)
        {
            _Mappings = mappings;
        }
        public List<MappingElement> LoadMappings()
        {
            return _Mappings;
        }
    }
}
