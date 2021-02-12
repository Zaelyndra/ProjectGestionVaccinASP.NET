using SuiviClientCovid.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuivieClientCovid.web.Models
{
    public class ListePersonnesNonCovidViewModel
    {
        public String nom { get; set; }

        public String prenom { get; set; }

        public Injection injection { get; set; }

        public DateTime datedenaissance { get; set; }

        public Sexe sexe { get; set; }

        public TypesVaccin typesVaccin { get; set; }

        public ListePersonnesNonCovidViewModel(string nom, string prenom, DateTime datedenaissance, Sexe sexe, Injection injection, TypesVaccin typesVaccin)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.datedenaissance = datedenaissance;
            this.sexe = sexe;
            this.injection = injection;
            this.typesVaccin = typesVaccin;
        }
    }
}
