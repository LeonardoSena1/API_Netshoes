namespace API_Netshoes.Produtos
{
    public class PrecoList
    {
        public class Self
        {
            public string href { get; set; }
        }

        public class Product
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Product product { get; set; }
        }

        public class Root
        {
            public int listPrice { get; set; }
            public int salePrice { get; set; }
            public Links links { get; set; }
        }
    }
}
