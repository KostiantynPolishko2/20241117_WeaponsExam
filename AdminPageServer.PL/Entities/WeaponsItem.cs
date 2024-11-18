using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AdminPageServer.PL.Entities
{
    public class WeaponsItem
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }

        public string model = null!;
        public string Model
        {
            get => model;
            set => model = value.ToLower();
        }

        public string name = null!;
        public string Name
        {
            get => name;
            set => name = value.ToLower();
        }

        public string type = null!;
        public string Type
        {
            get => type;
            set => type = value.ToLower();
        }

        public bool isVisible { get; set; }

        [SwaggerIgnore]
        public WeaponsProperty? weaponsProperty { get; set; }

        [SwaggerIgnore]
        public WeaponsImage? weaponsImage { get; set; }
    }
}
    