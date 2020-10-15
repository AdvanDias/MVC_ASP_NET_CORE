using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Desafio_01.Models
{
    public class ConsultaMarcasController : Controller
    {
        private readonly Context _context;

        public ConsultaMarcasController(Context context)
        {
            _context = context;
        }

        // GET: ConsultaMarcas
        public async Task<IActionResult> Index(string cpfGenre, string p)
        {

            IQueryable<string> cpfQuery = from c in _context.ConsultaMarcas orderby c.Paciente.Data select c.Paciente.Cpf;
            


            var movies = from m in _context.ConsultaMarcas.Include(c => c.Paciente)
            select m;

            //var test = "Nenhum regsitro foi encontrado com esse nome";
            

            if (cpfGenre == null && p == null)
            {
                cpfGenre = "0";
                p = "!";
                
            }
            
            if (!String.IsNullOrEmpty(p))
            {
                movies = movies.Where(s => s.Paciente.Nomepaciente.Contains(p));
                   return View(await movies.ToListAsync());

            }
          

            if (!string.IsNullOrEmpty(cpfGenre))
            {
                movies = movies.Where(x => x.Paciente.Cpf.Contains(cpfGenre));
                return View(await movies.ToListAsync());
            }


            // else
            // {
            //     var test = "Nenhum regsitro foi encontrado com esse nome";
            //     return NotFound(test);
            // }
           
            var context = _context.ConsultaMarcas.Include(c => c.Paciente);
            return View(await context.ToListAsync());
            //return View(test);
        }

        // GET: ConsultaMarcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMarca = await _context.ConsultaMarcas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaMarca == null)
            {
                return NotFound();
            }

            return View(consultaMarca);
        }

        // GET: ConsultaMarcas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nomepaciente");
            return View();
        }

        // POST: ConsultaMarcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filtranome,Filtracpf,PacienteId,Data,NumeroProtocolo")] ConsultaMarca consultaMarca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaMarca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nomepaciente", consultaMarca.PacienteId);
            return View(consultaMarca);
        }

        // GET: ConsultaMarcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMarca = await _context.ConsultaMarcas.FindAsync(id);
            if (consultaMarca == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nomepaciente", consultaMarca.PacienteId);
            return View(consultaMarca);
        }

        // POST: ConsultaMarcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Filtranome,Filtracpf,PacienteId,Data,NumeroProtocolo")] ConsultaMarca consultaMarca)
        {
            if (id != consultaMarca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaMarca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaMarcaExists(consultaMarca.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nomepaciente", consultaMarca.PacienteId);
            return View(consultaMarca);
        }

        // GET: ConsultaMarcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMarca = await _context.ConsultaMarcas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaMarca == null)
            {
                return NotFound();
            }

            return View(consultaMarca);
        }

        // POST: ConsultaMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaMarca = await _context.ConsultaMarcas.FindAsync(id);
            _context.ConsultaMarcas.Remove(consultaMarca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaMarcaExists(int id)
        {
            return _context.ConsultaMarcas.Any(e => e.Id == id);
        }
    }
}
