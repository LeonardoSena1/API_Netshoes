using System.Collections.Generic;

namespace API_Netshoes.Produtos
{
    public class ListProdutos
    {
        public class Self
        {
            public string href { get; set; }
        }

        public class Price
        {
            public string href { get; set; }
        }

        public class Stock
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Price price { get; set; }
            public Stock stock { get; set; }
        }

        public class Item
        {
            public IList<string> expands { get; set; }
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
            public int height { get; set; }
            public int width { get; set; }
            public int depth { get; set; }
            public int weight { get; set; }
            public Links links { get; set; }
        }

        public class Root
        {
            public IList<Item> items { get; set; }
            public int page { get; set; }
            public int totalPages { get; set; }
            public int size { get; set; }
            public int total { get; set; }
            public Links links { get; set; }
        }
    }
}

