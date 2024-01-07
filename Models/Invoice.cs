using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proiect.Models;

namespace Proiect.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int TotalAmount { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentID { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
