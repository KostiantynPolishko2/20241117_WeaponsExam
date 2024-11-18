namespace AdminPageServer.PL.DTO
{
    public class WeaponsItemDto
    {
        public string model = null!;
        public string Model
        {
            get
            {
                if (model == null || model == "None")
                    return "None";
                return model.ToUpper();
            }
        }

        public string name = null!;
        public string Name
        {
            get
            {
                if (name == null || name == "None")
                    return "None";
                return name.Replace(name[0], name.ToUpper()[0]);
            }
        }

        public string type = null!;
        public string Type
        {
            get
            {
                if (type == null || type == "None")
                    return "None";
                return type.Replace(type[0], type.ToUpper()[0]);
            }
        }
    }
}
