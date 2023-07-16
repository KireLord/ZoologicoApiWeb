using System.ComponentModel.DataAnnotations;

namespace AplicacionWeb_1_GG_ER.Models
{
    public class Promocion
    {
        [Key]
        public int PromoId { get; set; }
        public string? Description { get; set; }
        public DateTime FechaPromo { get; set; }

        public int TicketId { get; set; }
        public AddTickets? AddTickets { get; set; }
    }
}
