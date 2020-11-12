using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity_of_product { get; set; }
        public decimal Price_of_order { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public string Orders { get; set; }
        public string Employees { get; set; }
        public DateTime Start_data { get; set; }
        public DateTime Date_of_delivery { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }

        public Order(int id, string customer, int quantity_of_product,
            decimal price_of_order, int employeeId, int productId, string orders, string employees, DateTime start_data, DateTime date_of_delivery)
        {
            Id = id;
            Customer = customer;

            Quantity_of_product = quantity_of_product;
            Price_of_order = price_of_order;
            EmployeeId = employeeId;
            ProductId = productId;
            Orders = orders;
            Employees = employees;
            Start_data = start_data;
            Date_of_delivery = date_of_delivery;
        }

        public Order() { }
    }
}
