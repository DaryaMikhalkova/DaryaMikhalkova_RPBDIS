using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Material_supply
    {
        [Key]
        public int Id { get; set; }
        public int MaterialSupplyId { get; set; }
        public string Provider { get; set; }
        public string MaterialSupply_name { get; set; }
        public decimal Price_of_materials { get; set; }
        public int Amount_of_material { get; set; }
        public DateTime Delivery_data { get; set; }
        //public Material Material { get; set; }

        public Material_supply(int id, int materialId, string provider, string materials_name,
            decimal price_of_materials, int amount_of_materials, DateTime delivery_data)
        {
            Id = id;
            //MaterialSupplyId = materialId;
            Provider = provider;
            MaterialSupply_name = materials_name;
            Price_of_materials = price_of_materials;
            Amount_of_material = amount_of_materials;
            Delivery_data = delivery_data;
        }

        public Material_supply() { }
    }
}
