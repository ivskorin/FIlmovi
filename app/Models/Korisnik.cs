using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace app.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Ime { get; set; }

        [Required]
        [StringLength(100)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("User name")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}