using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiviClientCovid.ORM
{
    public class Personne
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nom { get; set; }

        [MaxLength(50)]
        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public bool Résident_Ou_Personnel { get; set; }

        public int SexeId { get; set; }

        public Sexe sexe { get; set; }

        public List<Injection> Injections { get; } = new List<Injection>();

    }
}
