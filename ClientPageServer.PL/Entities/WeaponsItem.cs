using Newtonsoft.Json;
//using NSwag.Annotations;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ClientPageServer.PL.Entities
{
    public class WeaponsItem
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        [JsonIgnore]
        public string model = null!;
        public string Model
        {
            get => model;
            set => model = value.ToLower();
        }
        [JsonIgnore]
        public string name = null!;
        public string Name
        {
            get => name;
            set => name = value.ToLower();
        }
        [JsonIgnore]
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

        public WeaponsItem() { }

        public WeaponsItem(WeaponsItem weaponsItem)
        {
            this.Model = weaponsItem.Model;
            this.Name = weaponsItem.Name;
            this.Type = weaponsItem.Type;
            this.isVisible = weaponsItem.isVisible;
        }
    }
}
    