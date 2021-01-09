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

        public List<TypesVaccin> TypesVaccins { get; } = new List<TypesVaccin>();

        public int PersonneId { get; set; }

        public Personne Personnes { get; set; }

    }
}
