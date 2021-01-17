using CarrinhoDeCaches.Dominio;
using CarrinhoDeCaches.IDados;
using CarrinhoDeCaches.IServicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarrinhoDeCaches.Servicos
{
    public class CarrinhoServico : ICarrinhoServico
    {
        private const string FORMATO_CARRINHO = "carrinho:{0}";

        private readonly IRedisRepositorio redisRepositorio;

        public CarrinhoServico(IRedisRepositorio redisRepositorio)
        {
            this.redisRepositorio = redisRepositorio;
        }

        public Item ObterItem(string usuario, Guid itemId)
        {
            var descricao = redisRepositorio.HGet(ObterCarrinho(usuario), itemId.ToString());

            return descricao == null ? null : new Item(itemId, descricao);
        }

        public IEnumerable<Item> ObterPeloUsuario(string usuario)
        {
            var itens = redisRepositorio.HGetAll(ObterCarrinho(usuario));

            return itens?.Select(x => new Item(Guid.Parse(x.Key), x.Value));
        }

        public void AdicionarItens(string usuario, params Item[] itens)
        {
            var chaveValores = itens.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Descricao));

            redisRepositorio.HSet(ObterCarrinho(usuario), chaveValores.ToArray());
        }

        public void AlterarItens(string usuario, params Item[] itens)
        {
            var chaveValores = itens.Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Descricao));

            redisRepositorio.HSet(ObterCarrinho(usuario), chaveValores.ToArray());
        }

        public void RemoverItens(string usuario, Guid[] itensId)
        {
            var itens = itensId.Select(x => x.ToString());

            redisRepositorio.HDel(ObterCarrinho(usuario), itens.ToArray());
        }

        public void RemoverPeloUsuario(string usuario)
        {
            redisRepositorio.Del(ObterCarrinho(usuario));
        }

        private string ObterCarrinho(string usuario)
        {
            return string.Format(FORMATO_CARRINHO, usuario);
        }
    }
}
