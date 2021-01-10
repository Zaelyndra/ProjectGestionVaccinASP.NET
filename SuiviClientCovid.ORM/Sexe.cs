using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuiviClientCovid.ORM
{
    public class Sexe
    {
        public int Id { get; set; }

        [Display(Name = "Nom du sexe")]
        [Required]
        [MaxLength(50)]
        public String name { get; set; }

        public List<Personne> personnes { get; } = new List<Personne>();
    }
}