using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiviClientCovid.ORM
{
    public class Injection
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Marque { get; set; }

        public int NuméroDuLot { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateRappel { get; set; }

        public int TypesVaccinId { get; set; }

        public TypesVaccin TypesVaccins { get; set; }

        public int PersonneId { get; set; }

        public Personne personne { get; set; }


    }
}
