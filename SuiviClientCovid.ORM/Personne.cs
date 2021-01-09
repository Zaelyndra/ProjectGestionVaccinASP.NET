using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiviClientCovid.ORM
{
    public class Personne
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public bool? Sexe { get; set; }

        public DateTime? DateDeNaissance { get; set; }

        public bool? Résident_Ou_Personnel { get; set; }

        public List<Injection> Injections { get; } = new List<Injection>();

    }
}
