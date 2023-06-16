using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace app.Models
{
    public class Drzava
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Država")]
        public string Naziv { get; set; }
    }
}