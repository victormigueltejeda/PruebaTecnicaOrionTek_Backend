using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entidades
{
    public class Direcciones
    {

        public int Id { get; set; }

        [Required]
        public string Direccion { get; set; }

        public int ClienteId { get; set; }

    }
}
