using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Desafio_01.Models;

namespace Desafio_01.Controllers
{
    public class TipoExamesController : Controller
    {
        private readonly Context _context;

        public TipoExamesController(Context context)
        {
            _context = context;
        }

        // GET: TipoExames
        public async Task<IActionResult> Index()
        {
            return View(await _context.tipoExames.ToListAsync());
        }

        // GET: TipoExames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoExame = await _context.tipoExames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoExame == null)
            {
                return NotFound();
            }

            return View(tipoExame);
        }

        // GET: TipoExames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoExames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nometipo,Descricao")] TipoExame tipoExame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoExame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoExame);
        }

        // GET: TipoExames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoExame = await _context.tipoExames.FindAsync(id);
            if (tipoExame == null)
            {
                return NotFound();
            }
            return View(tipoExame);
        }

        // POST: TipoExames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nometipo,Descricao")] TipoExame tipoExame)
        {
            if (id != tipoExame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoExame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExameExists(tipoExame.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoExame);
        }

        // GET: TipoExames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoExame = await _context.tipoExames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoExame == null)
            {
                return NotFound();
            }

            return View(tipoExame);
        }

        // POST: TipoExames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoExame = await _context.tipoExames.FindAsync(id);
            _context.tipoExames.Remove(tipoExame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExameExists(int id)
        {
            return _context.tipoExames.Any(e => e.Id == id);
        }
    }
}
