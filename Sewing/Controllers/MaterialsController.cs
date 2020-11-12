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
    public class MaterialsController : Controller
    {
        private readonly int _size = 20;
        private readonly SewingContext _context;
        private readonly CachedService _cachedService;

        public MaterialsController(SewingContext context, CachedService cachedService)
        {
            _context = context;
            _cachedService = cachedService;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials([FromQuery] int page = 1)
        {
            page--;
            var cnt = _context.Materials.Count();
            return View("Get", new DataViewModel<Material>()
            {
                Data = _cachedService.GetMaterial(page,_size),
                PageCount = cnt / _size + (cnt % _size > 0 ? 1 : 0),
                CurrentPage = page
            }); ;
        }


        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> DeleteMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return material;
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
    }
}
