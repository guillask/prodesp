using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prodesp.Models;

namespace Prodesp.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public FabricantesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Fabricantes.ToListAsync());
        }        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataCadastro")] Fabricantes fabricantes)
        {
            if (ModelState.IsValid)
            {
                if (!FabricantesValid(fabricantes))
                    return View();

                _context.Add(fabricantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabricantes);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes.FindAsync(id);
            if (fabricantes == null)
            {
                return NotFound();
            }
            return View(fabricantes);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataCadastro")] Fabricantes fabricantes)
        {
            if (id != fabricantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fabricantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricantesExists(fabricantes.Id))
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
            return View(fabricantes);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricantes = await _context.Fabricantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            return View(fabricantes);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fabricantes = await _context.Fabricantes.FindAsync(id);
            _context.Fabricantes.Remove(fabricantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricantesExists(int id)
        {
            return _context.Fabricantes.Any(e => e.Id == id);
        }

        private bool FabricantesValid(Fabricantes fabricantes)
        {
            if (!fabricantes.Descricao.Trim().Equals("PFIZER") && !fabricantes.Descricao.Trim().Equals("SINOVAC"))
            {
                ViewData["mensagem"] = "Fabricantes aceitos com o nome PFIZER ou SINOVAC para conclusão do cadastro!";
                return false;
            }

            if (fabricantes.DataCadastro.Year < int.Parse(_configuration.GetSection("AnoLote").Value))
            {
                ViewData["mensagem"] = "Data do lote deverá ser igual ou maior que o ano anterior!";
                return false;
            }

            return true;
        }
    }
}
