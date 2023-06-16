using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [StringLength(100)]
        public int Ime { get; set; }

        [Required]
        [StringLength(100)]
        public int Prezime { get; set; }

        [Required]
        [StringLength(100)]
        public int Username { get; set; }

        [Required]
        [StringLength(100)]
        public int Password { get; set; }


    }
}