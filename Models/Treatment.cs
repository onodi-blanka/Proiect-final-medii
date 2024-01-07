using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proiect.Models;

namespace Proiect.Models
{
    public class Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentID { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
