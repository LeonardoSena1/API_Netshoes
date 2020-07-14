using System.Collections.Generic;

namespace API_Netshoes.Produtos
{
    public class Produto
    {
        public class Image
        {
            public string url { get; set; }
        }

        public class Attribute
        {
            public string name { get; set; }
            public IList<string> values { get; set; }
        }

        public class Root
        {
            public string sku { get; set; }
            public string productGroup { get; set; }
            public string department { get; set; }
            public string productType { get; set; }
            public string brand { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public string gender { get; set; }
            public string manufacturerCode { get; set; }
            public string size { get; set; }
            public string eanIsbn { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public int depth { get; set; }
            public int weight { get; set; }
            public string video { get; set; }
            public IList<Image> images { get; set; }
            public IList<Attribute> attributes { get; set; }
        }
    }
}
