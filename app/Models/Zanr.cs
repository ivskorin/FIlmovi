using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Zanr
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}