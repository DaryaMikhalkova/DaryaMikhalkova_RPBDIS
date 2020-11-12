using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Product_name { get; set; }
        public string Materials_name { get; set; }
        public int Amount_of_material { get; set; }
        public decimal Price_of_product { get; set; }
        public Material Material { get; set; }

        public List<Order> Orders { get; set; }

        public Product(int id, int materialId, string product_name,
            string materials_name, int amount_of_material, decimal price_of_product)
        {
            Id = Id;
            MaterialId = materialId;
            Product_name = product_name;
            Materials_name = materials_name;
            Amount_of_material = amount_of_material;
            Price_of_product = price_of_product;

        }

        public Product() { }
    }
}
