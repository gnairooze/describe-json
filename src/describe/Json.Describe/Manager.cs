using Json.Describe.Contracts.Interfaces;
using Json.Describe.Contracts.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Json.Describe
{
    public class Manager
    {
        protected readonly IMappingElementRepository _MappingElementRepository;
        protected readonly Settings _Settings;

        public Manager(IMappingElementRepository mappingElementRepository, Settings settings)
        {
            if (mappingElementRepository == null) throw new ArgumentNullException(nameof(mappingElementRepository));
            _MappingElementRepository = mappingElementRepository;

            if(settings == null) throw new ArgumentNullException(nameof(settings));
            _Settings = settings;
        }

        public List<ProcessedElement> Run(JToken input)
        {
            var rawElements = ExtractElements(input);

            if (rawElements == null || rawElements.Count == 0) return new List<ProcessedElement>();

            List<MappingElement> mappingElements = _MappingElementRepository.LoadMappings();

            return ProcessElements(rawElements, mappingElements);
        }

        public List<RawElement> ExtractElements(JToken input)
        {
            List<RawElement> elements = new();

            int inputChildrenCount = input.Children().Count();

            if (input == null || inputChildrenCount == 0) return elements;

            int counter = 1;

            AddElementsToList(input as JToken, elements, ref counter);

            return elements;
        }

        protected void AddElementsToList(JToken input, List<RawElement> elements, ref int counter)
        {
            foreach (JToken item in input.Children())
            {
                if(item.GetType() == typeof(JProperty))
                {
                    RawElement element = new();

                    element.Name = ((JProperty)item).Name;
                    element.Path = item.Path;
                    element.Value = ((JProperty)item).Value.ToString();
                    element.Order = counter++;
                    element.IsEndElement = Helper.JsonHelper.IsBasicNode(item);

                    elements.Add(element);
                }

                if (item.Children().Any())
                {
                    AddElementsToList(item, elements, ref counter);
                }
            }
        }

        public List<ProcessedElement> ProcessElements(List<RawElement> rawElements, List<MappingElement> mappingElements)
        {
            List <ProcessedElement> processedElements = new();
            if(mappingElements == null) mappingElements = new ();

            foreach (var rawElement in rawElements)
            {
                var mappingElement = mappingElements.SingleOrDefault(e => e.Name == rawElement.Name);

                ProcessedElement processedElement = new()
                {
                    Name = rawElement.Name,
                    IsEndElement = rawElement.IsEndElement,
                    Order = rawElement.Order,
                    Path = rawElement.Path,
                    RawValue = rawElement.Value,
                    MappedName = (mappingElement != null)?mappingElement.Name:string.Empty,
                    DescriptionTemplate = (mappingElement != null) ? mappingElement.DescriptionTemplate : string.Empty,
                    ShowInDescription = (mappingElement != null) ? mappingElement.ShowInDescription : true
                };

                ProcessElement(processedElement);

                processedElements.Add(processedElement);
            }

            return processedElements;
        }

        /// <summary>
        /// set the properties of Description, FirstValue, SecondValue
        /// </summary>
        /// <param name="processedElement"></param>
        private void ProcessElement(ProcessedElement processedElement)
        {
            processedElement.Description = String.Empty;
            processedElement.FirstValue = String.Empty;
            processedElement.SecondValue = String.Empty;
        }
    }
}