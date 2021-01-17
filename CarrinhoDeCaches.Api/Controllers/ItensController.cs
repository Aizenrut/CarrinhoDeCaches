using CarrinhoDeCaches.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarrinhoDeCaches.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensController : ControllerBase
    {
        [HttpGet("{chave}")]
        public IActionResult Obter(string chave)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroItemDto cadastro)
        {
            return Created(string.Empty, null);
        }

        [HttpPut]
        public IActionResult Alterar(AlteracaoItemDto alteracao)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remover(RemocaoItemDto remocao)
        {
            return NoContent();
        }
    }
}
