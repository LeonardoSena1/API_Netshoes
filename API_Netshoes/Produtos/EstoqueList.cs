namespace API_Netshoes.Produtos
{
    public class EstoqueList
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
            public int available { get; set; }
            public int reserved { get; set; }
            public Links links { get; set; }
        }
    }
}
