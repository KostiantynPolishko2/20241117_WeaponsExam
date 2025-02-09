using ClientPageServer.PL.Entities;
using Newtonsoft.Json;


namespace ClientPageServer.PL.DTO
{
    public class WeaponsCardDto
    {
        [JsonIgnore]
        public string model = null!;
        public string Model
        {
            get
            {
                if (model == null || model == "None")
                    return "None";
                return model.ToUpper();
            }
            set => model = value;
        }
        [JsonIgnore]
        public string name = null!;
        public string Name
        {
            get
            {
                if (name == null || name == "None")
                    return "None";
                return name.Replace(name[0], name.ToUpper()[0]);
            }
            set => name = value;
        }

        public bool isVisible {  get; set; }
        public float price { get; set; }
        public float weight { get; set; }
        public string description { get; set; } = null!;
        public string image_path { get; set; } = null!;

        public WeaponsCardDto() { }

        public WeaponsCardDto(WeaponsProperty? weaponsProperty)
        {
            this.price = weaponsProperty!.price;
            this.weight = weaponsProperty!.weight;
            this.description = weaponsProperty!.description;
        }
    }
}
