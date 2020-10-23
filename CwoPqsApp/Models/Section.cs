using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CwoPqsApp.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CwoPqsApp.Models
{
    public class Section
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }

        [NotMapped]
        public Dictionary<string, bool> Signatures { get; set; }
    }
}
