using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public List<Direcciones> Direcciones { get; set; }

    }
}
