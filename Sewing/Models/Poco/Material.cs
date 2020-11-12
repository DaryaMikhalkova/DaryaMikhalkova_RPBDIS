using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string Materials_name { get; set; }
        public string Types_of_materials { get; set; }
        public int Number_of_stock { get; set; }

        //public List<Material_supply> MaterialSupply { get; set; }

        public List<Product> Products { get; set; }

        public Material(int id, string materials_name, string types_of_materials, int number_of_stock)
        {
            Id = id;
            Materials_name = materials_name;
            Types_of_materials = types_of_materials;
            Number_of_stock = number_of_stock;
        }

        public Material() { }
    }
}
