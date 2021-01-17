using System.Collections.Generic;

namespace CarrinhoDeCaches.Api.Models
{
    public class AlteracaoItemDto
    {
        public string Usuario { get; set; }
        public KeyValuePair<string, string>[] Itens { get; set; }
    }
}
