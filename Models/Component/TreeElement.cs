using System.Collections.Generic;

namespace ProjectGeneratorApi.Models.Component
{
    public class TreeElement
    {
        public string index { get; set; }

        public TreeElement[] children { get; set; }

        public Dictionary<string, string> style { get; set; }

        public string id { get; set; }
    }
}