using ConsoleApp.Models;
using Sewing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Инициализатор бд
namespace FuelStation.Data
{
    public static class DbInitializer
    {
        private static Random rnd = new Random();
        private static int lenght = 20;
        public static string RandomString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(rnd.Next('a', 'z'));
            }
            return sb.ToString();
        }

        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
        public static void Initialize(SewingContext db)
        {
            db.Database.EnsureCreated();

            if (db.Atelier_Departments.Any())
            {
                return;   
            }

            for (int i = 0; i < 20; i++)
            {
                db.Atelier_Departments.Add(new Atelier_department { Departments_name = RandomString(), Number_quantity = rnd.Next(), Types_of_jobs = RandomString() });
            }

            db.SaveChanges();
            List<Atelier_department> ats = db.Atelier_Departments.ToList();
            foreach (var atditem in ats)
            {
                for (int i = 0; i < 3; i++)
                {
                    db.Employees.Add(new Employee { Atelier_departmentId = atditem.Id, Departments_name = RandomString(), Full_name = RandomString(), Position = RandomString(), Telephone = rnd.Next() });
                }
            }
            db.SaveChanges();

            for (int i = 0; i < 20; i++)
            {
                db.Materials.Add(new Material { Materials_name = RandomString(), Number_of_stock = rnd.Next(), Types_of_materials = RandomString() });
            }

            db.SaveChanges();
            List<Material> mats = db.Materials.ToList();
            foreach (var matitem in mats)
            {
                for (int i = 0; i < 3; i++)
                {
                    db.Material_supply.Add(new Material_supply { Amount_of_material = rnd.Next(), Delivery_data = RandomDay(), MaterialSupply_name = RandomString(), Price_of_materials = rnd.Next(), Provider = RandomString(), MaterialSupplyId = matitem.Id });
                    db.Products.Add(new Product { Amount_of_material = rnd.Next(1, 20), MaterialId = matitem.Id, Materials_name = RandomString(), Product_name = RandomString(), Price_of_product = rnd.Next(1, 100) });
                }
            }
            db.SaveChanges();

            List<Product> prods = db.Products.ToList();
            var empid = db.Employees.Select(a => a.Id).ToList();
            foreach (var proditm in prods)
            {
                for (int i = 0; i < 3; i++)
                {
                    db.Orders.Add(new Order { EmployeeId = empid[rnd.Next(0, empid.Count)], Employees = RandomString(), Customer = RandomString(), Date_of_delivery = RandomDay(), Orders = RandomString(), Price_of_order = rnd.Next(1, 100), ProductId = proditm.Id, Quantity_of_product = rnd.Next(1, 1000), Start_data = RandomDay() });
                }
            }

            db.SaveChanges();
            Random randObj = new Random(1);

        }

    }

}


