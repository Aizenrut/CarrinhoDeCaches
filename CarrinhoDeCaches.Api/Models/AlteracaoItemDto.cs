using CarrinhoDeCaches.Dominio;

namespace CarrinhoDeCaches.Api.Models
{
    public class AlteracaoItemDto
    {
        public string Usuario { get; set; }
        public Item[] Itens { get; set; }
    }
}
