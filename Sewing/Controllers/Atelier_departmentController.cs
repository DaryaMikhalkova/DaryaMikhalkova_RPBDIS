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
//Классы контроллеров (по одному на каждую таблицу базы данных) для обработки обраще-ний пользователя,
//выборки данных из таблиц и вызова соответствующих представлений для отображения выбранных данных.
namespace Sewing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Atelier_departmentController : Controller
    {
        private readonly int _size = 20;
        private readonly SewingContext _context;
        private readonly CachedService _cachedService;

        public Atelier_departmentController(SewingContext context, CachedService cachedService)
        {
            _context = context;
            _cachedService = cachedService;
        }

        // GET: api/Atelier_department
        [HttpGet]
        public async Task<ActionResult<DataViewModel<Atelier_department>>> GetAtelier_department([FromQuery] int page = 1)
        {
            page--;
            var cnt = _context.Atelier_Departments.Count();
            return View("Get",new DataViewModel<Atelier_department>()
            {
                Data = _cachedService.GetAtelier_department(page,_size),
                PageCount = cnt / _size + (cnt%_size > 0? 1:0),
                CurrentPage = page
            });
        }


        // PUT: api/Atelier_department/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtelier_department(int id, Atelier_department atelier_department)
        {
            if (id != atelier_department.Id)
            {
                return BadRequest();
            }

            _context.Entry(atelier_department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Atelier_departmentExists(id))
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

        // POST: api/Atelier_department
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Atelier_department>> PostAtelier_department(Atelier_department atelier_department)
        {
            _context.Atelier_Departments.Add(atelier_department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtelier_department", new { id = atelier_department.Id }, atelier_department);
        }

        // DELETE: api/Atelier_department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Atelier_department>> DeleteAtelier_department(int id)
        {
            var atelier_department = await _context.Atelier_Departments.FindAsync(id);
            if (atelier_department == null)
            {
                return NotFound();
            }

            _context.Atelier_Departments.Remove(atelier_department);
            await _context.SaveChangesAsync();

            return atelier_department;
        }

        private bool Atelier_departmentExists(int id)
        {
            return _context.Atelier_Departments.Any(e => e.Id == id);
        }
    }
}
