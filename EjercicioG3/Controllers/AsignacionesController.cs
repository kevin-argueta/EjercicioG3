
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioG3.Models;
using EjercicioG3.Data;

public class AsignacionesController : Controller
{
    private readonly EmpleadoDbContext _context;

    public AsignacionesController(EmpleadoDbContext context)
    {
        _context = context;
    }

    // GET: ASIGNACIONESS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Asignaciones.ToListAsync());
    }

    // GET: ASIGNACIONESS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignaciones = await _context.Asignaciones
            .FirstOrDefaultAsync(m => m.id == id);
        if (asignaciones == null)
        {
            return NotFound();
        }

        return View(asignaciones);
    }

    // GET: ASIGNACIONESS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ASIGNACIONESS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,FechaAsignacion,Rol,EmpleadoId,Empleado,ProyectoId,Proyecto")] Asignaciones asignaciones)
    {
        if (ModelState.IsValid)
        {
            _context.Add(asignaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(asignaciones);
    }

    // GET: ASIGNACIONESS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignaciones = await _context.Asignaciones.FindAsync(id);
        if (asignaciones == null)
        {
            return NotFound();
        }
        return View(asignaciones);
    }

    // POST: ASIGNACIONESS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("id,FechaAsignacion,Rol,EmpleadoId,Empleado,ProyectoId,Proyecto")] Asignaciones asignaciones)
    {
        if (id != asignaciones.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(asignaciones);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionesExists(asignaciones.id))
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
        return View(asignaciones);
    }

    // GET: ASIGNACIONESS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var asignaciones = await _context.Asignaciones
            .FirstOrDefaultAsync(m => m.id == id);
        if (asignaciones == null)
        {
            return NotFound();
        }

        return View(asignaciones);
    }

    // POST: ASIGNACIONESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var asignaciones = await _context.Asignaciones.FindAsync(id);
        if (asignaciones != null)
        {
            _context.Asignaciones.Remove(asignaciones);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AsignacionesExists(int? id)
    {
        return _context.Asignaciones.Any(e => e.id == id);
    }
}
