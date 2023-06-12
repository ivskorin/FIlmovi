using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models
{
    public class Drzava
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}