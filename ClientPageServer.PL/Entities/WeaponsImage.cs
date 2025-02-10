using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ClientPageServer.PL.Entities
{
    public class WeaponsImage
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string path { get; set; } = null!;

        [SwaggerIgnore]
        public int idWeaponsItem { get; set; }
        [SwaggerIgnore]
        public WeaponsItem? weaponsItem { get; set; }
    }
}
