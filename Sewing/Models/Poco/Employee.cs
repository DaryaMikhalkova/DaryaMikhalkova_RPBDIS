using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int Atelier_departmentId { get; set; }
        public string Full_name { get; set; }
        public string Departments_name { get; set; }
        public string Position { get; set; }
        public int Telephone { get; set; }
        public Atelier_department Atelier_department { get; set; }

        public List<Order> Orders { get; set; }

        public Employee(int id, int atelier_departmentId, string full_name, string departments_name, string position, int telephone)
        {
            Id = id;
            Atelier_departmentId = atelier_departmentId;
            Full_name = full_name;
            Departments_name = departments_name;
            Position = position;
            Telephone = telephone;
        }

        public Employee() { }
    }
}
