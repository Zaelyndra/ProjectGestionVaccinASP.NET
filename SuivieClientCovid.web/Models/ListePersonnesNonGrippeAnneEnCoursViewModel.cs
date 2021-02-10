using SuiviClientCovid.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuivieClientCovid.web.Models
{
    public class ListePersonnesNonGrippeAnneEnCoursViewModel
    {
        public String nom { get; set; }

        public String prenom { get; set; }

        public Injection injection { get; set; }

        public TypesVaccin typesVaccin { get; set; }

        public ListePersonnesNonGrippeAnneEnCoursViewModel(string nom, string prenom,  Injection injection, TypesVaccin typesVaccin)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.injection = injection;
            this.typesVaccin = typesVaccin;
        }
    }
}
