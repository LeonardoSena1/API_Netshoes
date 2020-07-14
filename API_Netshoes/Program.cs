using API_Netshoes.Produtos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Netshoes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Autenticação
            //InserirProduto();
            //Lista_de_produtos();
            //Preco();
            //GET_Preco();
            //AlterarPreco();
            //InserirEstoque();
            //AlterarEstoque();
            //GET_Estoque();
        }

        public static string Cliente_Id()
        {
            string Client_id = "fee7e6a8-0005-35b5-bef9-16ae9eed7414";
            return Client_id;
        }
        public static string Access_Token()
        {
            string AccessToken = "c422b3c8-a090-3d4b-bd3c-2ff27201fc87";
            return AccessToken;
        }



        public static string InserirProduto()
        {
            var produto = new Produto.Root();
            produto.sku = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7);
            produto.productGroup = "Tenis";
            produto.department = "Running";
            produto.productType = "Tenis";
            produto.brand = "Nike";
            produto.name = "Tênis Nike Revolution 5 Masculino ";
            produto.description = "Com ótimo amortecimento em espuma, o Tênis Nike Masculino Revolution 5 é ideal " +
                "para os corredores que buscam leveza e conforto. Confeccionado em material respirável, " +
                "esse tênis para correr possui reforço no calcanhar para proteger contra possíveis torções e fechamento " +
                "dinâmico, garantindo um ajuste personalizado. Aposte na Nike para te acompanhar nos seus desafios dentro do " +
                "esporte!";
            produto.color = "Preto e Branco";
            produto.gender = "Homem";
            produto.manufacturerCode = "codigo do fabricante";
            produto.size = "41";
            produto.eanIsbn = "";
            produto.height = 10;
            produto.width = 10;
            produto.depth = 10;
            produto.weight = 10;
            produto.video = "";
            produto.images = new List<Produto.Image>();
            var image = new Produto.Image();
            image.url = "http://static.netshoes.com.br/produtos/tenis-nike-revolution-5-masculino/26/HZM-1731-026/HZM-1731-026_zoom1.jpg?ts=1571078789";
            produto.images.Add(image);

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products?page=0&size=20");
            var request = new RestRequest(Method.POST);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(produto, Newtonsoft.Json.Formatting.None,
                                                                                            new JsonSerializerSettings
                                                                                            {
                                                                                                NullValueHandling = NullValueHandling.Ignore
                                                                                            }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return string.Empty;
        }

        public static string Lista_de_produtos()
        {
            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products?page=0&size=20");
            var request = new RestRequest(Method.GET);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            IRestResponse response = client.Execute(request);

            var retorno = JsonConvert.DeserializeObject<Produtos.ListProdutos.Root>(response.Content);

            return retorno.ToString();
        }

        public static string Preco()
        {
            var codigoProduto = "6895f59";

            var preco = new Preco.Root();
            preco.listPrice = 250;
            preco.salePrice = 210;

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/prices");
            var request = new RestRequest(Method.POST);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(preco, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return string.Empty;
        }

        public static string GET_Preco()
        {
            var codigoProduto = "012389";

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/prices");
            var request = new RestRequest(Method.GET);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            IRestResponse response = client.Execute(request);

            var retorno = JsonConvert.DeserializeObject<PrecoList.Root>(response.Content);

            return retorno.ToString();
        }

        public static string AlterarPreco()
        {
            var codigoProduto = "6895f59";

            var preco = new Preco.Root();
            preco.listPrice = 250;
            preco.salePrice = 210;


            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/prices");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(preco), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return string.Empty;
        }

        public static string InserirEstoque()
        {
            var codigoProduto = "012389";

            var estoque = new Produtos.Estoque.Root();
            estoque.available = 10;

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/stocks");
            var request = new RestRequest(Method.POST);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(estoque), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return string.Empty;
        }

        public static string AlterarEstoque()
        {
            var codigoProduto = "012389";

            var estoque = new Produtos.Estoque.Root();
            estoque.available = 10;

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/stocks");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(estoque), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return string.Empty;
        }

        public static string GET_Estoque()
        {
            var codigoProduto = "012389";

            var client = new RestClient("http://api-sandbox.netshoes.com.br/api/v2/products/" + $"{codigoProduto}" + "/stocks");
            var request = new RestRequest(Method.GET);
            request.AddHeader("client_id", Cliente_Id());
            request.AddHeader("access_token", Access_Token());
            request.AddHeader("content_type", "application/json");
            IRestResponse response = client.Execute(request);

            var retorno = JsonConvert.DeserializeObject<EstoqueList.Root>(response.Content);

            return retorno.ToString();
        }
    }
}
