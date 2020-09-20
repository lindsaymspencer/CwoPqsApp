using CwoPqsApp.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace CwoPqsApp.Models
{
    public class Officer
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "Lindsay";

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "Spencer";

        public string Rank { get; set; } = "LTJG";

        [NotMapped]
        public CwoPqs TwoBravo { get; set; } = CwoPqs.NewTwoBravo();

        [JsonIgnore]
        [NotMapped]
        public CwoPqs TwoAlpha { get; set; } = CwoPqs.NewTwoAlpha();

        public string ToJson() => JsonSerializer.Serialize(this);

        public bool Export(string path)
        {
            FileHelper.WriteOver(Path.Combine(path, LastName + FirstName + ".cw2bpqs"),
                ToJson());
            return true;
        }

    }
}
