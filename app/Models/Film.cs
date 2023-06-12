using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace app.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public int Trajanje { get; set; }
        public double Cijena { get; set; }

        [Required]

        [ForeignKey("Zanr")]
        public int ZanrId { get; set; }

        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }

        public virtual Zanr Zanr { get; set; }
        public virtual Drzava Drzava { get; set; }

    }
}