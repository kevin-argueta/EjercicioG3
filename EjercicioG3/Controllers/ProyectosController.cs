
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioG3.Models;
using EjercicioG3.Data;

public class ProyectosController : Controller
{
    private readonly EmpleadoDbContext _context;

    public ProyectosController(EmpleadoDbContext context)
    {
        _context = context;
    }

    // GET: PROYECTOSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Proyectos.ToListAsync());
    }

    // GET: PROYECTOSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectos = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (proyectos == null)
        {
            return NotFound();
        }

        return View(proyectos);
    }

    // GET: PROYECTOSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROYECTOSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaInicio")] Proyectos proyectos)
    {
        if (ModelState.IsValid)
        {
            _context.Add(proyectos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(proyectos);
    }

    // GET: PROYECTOSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectos = await _context.Proyectos.FindAsync(id);
        if (proyectos == null)
        {
            return NotFound();
        }
        return View(proyectos);
    }

    // POST: PROYECTOSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Descripcion,FechaInicio")] Proyectos proyectos)
    {
        if (id != proyectos.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(proyectos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(proyectos.Id))
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
        return View(proyectos);
    }

    // GET: PROYECTOSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var proyectos = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (proyectos == null)
        {
            return NotFound();
        }

        return View(proyectos);
    }

    // POST: PROYECTOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var proyectos = await _context.Proyectos.FindAsync(id);
        if (proyectos != null)
        {
            _context.Proyectos.Remove(proyectos);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProyectosExists(int? id)
    {
        return _context.Proyectos.Any(e => e.Id == id);
    }
}
