using System;

namespace CarrinhoDeCaches.Dominio
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public Item(Guid id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public Item(string descricao)
        {
            this.Id = Guid.NewGuid();
            this.Descricao = descricao;
        }

        public Item()
        {
        }
    }
}
