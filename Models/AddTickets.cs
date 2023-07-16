using System.ComponentModel.DataAnnotations;

namespace AplicacionWeb_1_GG_ER.Models
{
    public class AddTickets
    {
        [Key]
        public int TicketId { get; set; }
        public int Precio { get; set; }
        public string? Description { get; set; }
        public DateTime Fecha { get; set; }

        public List<Promocion>? Promociones { get; set; }
    }
}
