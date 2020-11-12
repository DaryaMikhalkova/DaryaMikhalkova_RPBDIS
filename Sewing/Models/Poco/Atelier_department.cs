using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Atelier_department
    {
        [Key]
        public int Id { get; set; }
        public string Departments_name { get; set; }
        public string Types_of_jobs { get; set; }
        public int Number_quantity { get; set; }

        public List<Employee> Employees { get; set; }

        public Atelier_department(int id, string departments_name, string types_of_jods, int number_quantity)
        {
            Id = id;
            Departments_name = departments_name;
            Types_of_jobs = types_of_jods;
            Number_quantity = number_quantity;
        }

        public Atelier_department() { }
    }
}
