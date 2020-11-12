using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;
using Sewing.Data;
using Sewing.Models.ViewModel;
using FuelStation.Services;
//•	Классы контроллеров (по одному на каждую таблицу базы данных) для обработки обраще-ний пользователя,
//выборки данных из таблиц и вызова соответствующих представлений для отображения выбранных данных.
namespace Sewing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Material_supplyController : Controller
    {
        private readonly int _size = 20;
        private readonly SewingContext _context;
        private readonly CachedService _cachedService;

        public Material_supplyController(SewingContext context, CachedService cachedService)
        {
            _context = context;
            _cachedService = cachedService;
        }

        // GET: api/Material_supply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material_supply>>> GetMaterial_supply([FromQuery] int page = 1)
        {
            page--;
            var cnt = _context.Material_supply.Count();
            return View("Get", new DataViewModel<Material_supply>()
            {
                Data = _cachedService.GetMaterialSupply(page,_size),
                PageCount = cnt / _size + (cnt % _size > 0 ? 1 : 0),
                CurrentPage = page
            });
        }


        // PUT: api/Material_supply/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial_supply(int id, Material_supply material_supply)
        {
            if (id != material_supply.Id)
            {
                return BadRequest();
            }

            _context.Entry(material_supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Material_supplyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Material_supply
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Material_supply>> PostMaterial_supply(Material_supply material_supply)
        {
            _context.Material_supply.Add(material_supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial_supply", new { id = material_supply.Id }, material_supply);
        }

        // DELETE: api/Material_supply/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material_supply>> DeleteMaterial_supply(int id)
        {
            var material_supply = await _context.Material_supply.FindAsync(id);
            if (material_supply == null)
            {
                return NotFound();
            }

            _context.Material_supply.Remove(material_supply);
            await _context.SaveChangesAsync();

            return material_supply;
        }

        private bool Material_supplyExists(int id)
        {
            return _context.Material_supply.Any(e => e.Id == id);
        }
    }
}
