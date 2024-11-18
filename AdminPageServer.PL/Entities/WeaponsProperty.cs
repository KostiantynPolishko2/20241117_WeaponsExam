﻿using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AdminPageServer.PL.Entities
{
    public class WeaponsProperty
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        public float price { get; set; }
        public float weight { get; set; }

        public string vendor = null!;
        public string Vendor
        {
            get => vendor;
            set => vendor = value.ToLower();
        }

        [SwaggerIgnore]
        public int idWeaponsItem { get; set; }
        [SwaggerIgnore]
        public WeaponsItem? weaponsItem { get; set; }
    }
}
