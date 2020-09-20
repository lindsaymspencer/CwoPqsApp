using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CwoPqsApp.Models
{
    public class Section
    {
        public string Name { get; set; }
        public string Number { get; set; }

        [NotMapped]
        public Dictionary<string, bool> Signatures { get; set; }
    }
}
