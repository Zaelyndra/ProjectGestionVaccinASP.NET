using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiviClientCovid.ORM
{
    public class TypesVaccin
    {
        public int Id { get; set; }

        [Display(Name = "Nom du vaccin")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<Injection> Injections { get; } = new List<Injection>();

    }
}
