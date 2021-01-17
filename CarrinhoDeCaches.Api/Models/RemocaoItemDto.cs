using System;

namespace CarrinhoDeCaches.Api.Models
{
    public class RemocaoItemDto
    {
        public string Usuario { get; set; }
        public Guid[] ItensId { get; set; }
    }
}
