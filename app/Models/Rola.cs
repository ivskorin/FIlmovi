using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;
using System.ComponentModel;

namespace app.Models
{
    public class Rola
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Naziv { get; set; }

    }
}