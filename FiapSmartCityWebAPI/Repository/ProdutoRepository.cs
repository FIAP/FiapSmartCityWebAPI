using FiapSmartCityWebAPI.Models;
using System.Collections.Generic;

namespace FiapSmartCityWebAPI.Repository
{
    public class ProdutoRepository
    {

        // Lista criada para armezenar uma lista de Tipo de produto simulando o banco de dados
        private static Dictionary<long, Produto> bancoProduto = new Dictionary<long, Produto>();

        private static int contadorBanco = 2;

        static ProdutoRepository()
        {

            Produto FotoVoltatica = new Produto();
            FotoVoltatica.IdProduto = 800;
            FotoVoltatica.NomeProduto = "Energia Solar Fotovoltatica";
            FotoVoltatica.Caracteristicas = @"A tecnologia fotovoltaica (FV)  
                                            converte diretamente os raios  
                                            solares em eletricidade";
            FotoVoltatica.PrecoMedio = 4000.00;
            FotoVoltatica.Logotipo = @"data:image/jpeg;base64";
            FotoVoltatica.Ativo = true;


            bancoProduto.Add(1, FotoVoltatica);
            bancoProduto.Add(2, FotoVoltatica);
            bancoProduto.Add(3, FotoVoltatica);


        }



        public void Inserir(Produto produto)
        {
            contadorBanco++;
            produto.IdProduto = contadorBanco;
            bancoProduto.Add(contadorBanco, produto);
        }



        public Produto Consultar(int id)
        {
            return bancoProduto[id];
        }



        public IList<Produto> Listar()
        {
            return new List<Produto>(bancoProduto.Values);
        }


        public void Excluir(int IdTipo)
        {
            bancoProduto.Remove(IdTipo);
        }


        public void Alterar(Produto Produto)
        {
            bancoProduto[Produto.IdProduto] = Produto;
        }

    }
}
