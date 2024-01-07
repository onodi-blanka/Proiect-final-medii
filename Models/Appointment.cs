using Proiect;
using Proiect.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime DateTime { get; set; }
        public string ReasonOfVisit { get; set; }

        [ForeignKey("Pet")]
        public int PetID { get; set; }
        public Pet Pet { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorID { get; set; }
        public Doctor? Doctor { get; set; }
    }
}