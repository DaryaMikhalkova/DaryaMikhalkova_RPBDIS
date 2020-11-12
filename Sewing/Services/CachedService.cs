using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;
using Microsoft.Extensions.Caching.Memory;
using Sewing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
//ResponseCache для соответствующих методов контроллера. Данные в кэше хранить неизменными в течение 2*N+240 секунд
namespace FuelStation.Services
{
    public class CachedService
    {
        private SewingContext _db;
        private IMemoryCache _cache;
        private int _rowsNumber;
        private TimeSpan _delay = TimeSpan.FromSeconds(264);

        public CachedService(SewingContext context, IMemoryCache memoryCache)
        {
            _db = context;
            _cache = memoryCache;
            _rowsNumber = 20;
        }

        public IEnumerable<Employee> GetEmployee(int page,int size)
        {
            IEnumerable<Employee> emp = null;
            string name = "emp" + page.ToString() + "_" + size.ToString();
            if (!_cache.TryGetValue(name, out emp))
            {
                emp = _db.Employees.Include(a => a.Atelier_department).Skip(page * size).Take(size).ToList();
                if (emp != null)
                {
                    _cache.Set(name, emp,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return emp;
        }

        public IEnumerable<Atelier_department> GetAtelier_department(int page, int size)
        {
            IEnumerable<Atelier_department> ad = null;
            string name = "ad" + page.ToString() + "_" + size.ToString();
            if (!_cache.TryGetValue(name, out ad))
            {
                ad = _db.Atelier_Departments.Skip(page * size).Take(size).ToList();
                if (ad != null)
                {
                    _cache.Set(name, ad,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return ad;
        }

        public IEnumerable<Material> GetMaterial(int page, int size)
        {
            IEnumerable<Material> mat = null;
            string name = "mat" + page.ToString() + "_" + size.ToString();
            if (!_cache.TryGetValue(name, out mat))
            {
                mat = _db.Materials.Skip(page * size).Take(size).ToList();
                if (mat != null)
                {
                    _cache.Set(name, mat,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return mat;
        }

        public IEnumerable<Material_supply> GetMaterialSupply(int page, int size)
        {
            IEnumerable<Material_supply> msup = null;
            string name = "msup" + page.ToString() + "_" + size.ToString();
            if (!_cache.TryGetValue("msup", out msup))
            {
                msup = _db.Material_supply./*Include(a=>a.Material).*/Skip(page * size).Take(size).ToList();
                if (msup != null)
                {
                    _cache.Set("msup", msup,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return msup;
        }

        public IEnumerable<Order> GetOrder(int page, int _size)
        {
            IEnumerable<Order> ord = null;
            if (!_cache.TryGetValue("ord", out ord))
            {
                ord = _db.Orders.Include(a => a.Employee).Skip(page * _size).Take(_size).ToList();
                ord = _db.Orders.Include(a => a.Product).Skip(page * _size).Take(_size).ToList();
                if (ord != null)
                {
                    _cache.Set("ord", ord,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return ord;
        }

        public IEnumerable<Product> GetProduct()
        {
            IEnumerable<Product> prod = null;
            if (!_cache.TryGetValue("prod", out prod))
            {
                prod = _db.Products.Take(_rowsNumber).ToList();
                if (prod != null)
                {
                    _cache.Set("prod", prod,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(_delay));
                }
            }
            return prod;
        }

    }
}

