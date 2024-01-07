using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proiect.Models;

namespace Proiect.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public Owner Owner { get; set; }
    }
}
