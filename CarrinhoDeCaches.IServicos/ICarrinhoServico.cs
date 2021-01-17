using CarrinhoDeCaches.Dominio;
using System;
using System.Collections.Generic;

namespace CarrinhoDeCaches.IServicos
{
    public interface ICarrinhoServico
    {
        Item ObterItem(string usuario, Guid itemId);
        IEnumerable<Item> ObterPeloUsuario(string usuario);
        void AdicionarItens(string usuario, params Item[] itens);
        void AlterarItens(string usuario, params Item[] itens);
        void RemoverItens(string usuario, Guid[] itensId);
        void RemoverPeloUsuario(string usuario);
    }
}
