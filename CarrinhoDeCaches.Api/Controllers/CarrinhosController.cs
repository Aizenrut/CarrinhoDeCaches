using CarrinhoDeCaches.Api.Models;
using CarrinhoDeCaches.Dominio;
using CarrinhoDeCaches.IServicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarrinhoDeCaches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhosController : ControllerBase
    {
        private readonly ICarrinhoServico carrinhoServico;

        public CarrinhosController(ICarrinhoServico carrinhoServico)
        {
            this.carrinhoServico = carrinhoServico;
        }

        [HttpGet("{usuario}")]
        public IActionResult ObterPeloUsuario(string usuario)
        {
            var itens = carrinhoServico.ObterPeloUsuario(usuario);

            if (!itens.Any())
                return NotFound();

            return Ok(itens);
        }

        [HttpGet("{usuario}/{itemId}")]
        public IActionResult ObterItem(string usuario, Guid itemId)
        {
            var item = carrinhoServico.ObterItem(usuario, itemId);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult AdicionarItens(AdicaoItemDto cadastro)
        {
            var itens = cadastro.ItensDescricao.Select(x => new Item(x));

            carrinhoServico.AdicionarItens(cadastro.Usuario, itens.ToArray());

            return Created("abacate", itens);
        }

        [HttpPut]
        public IActionResult AlterarItens(AlteracaoItemDto alteracao)
        {
            carrinhoServico.AlterarItens(alteracao.Usuario, alteracao.Itens);

            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoverItens(RemocaoItemDto remocao)
        {
            carrinhoServico.RemoverItens(remocao.Usuario, remocao.ItensId);

            return NoContent();
        }

        [HttpDelete("{usuario}")]
        public IActionResult RemoverPeloUsuario(string usuario)
        {
            carrinhoServico.RemoverPeloUsuario(usuario);

            return NoContent();
        }
    }
}
