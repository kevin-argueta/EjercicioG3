
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioG3.Models;
using EjercicioG3.Data;

public class EmpleadosController : Controller
{
    private readonly EmpleadoDbContext _context;

    public EmpleadosController(EmpleadoDbContext context)
    {
        _context = context;
    }

    // GET: EMPLEADOSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Empleados.ToListAsync());
    }

    // GET: EMPLEADOSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleados = await _context.Empleados
            .FirstOrDefaultAsync(m => m.Id == id);
        if (empleados == null)
        {
            return NotFound();
        }

        return View(empleados);
    }

    // GET: EMPLEADOSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPLEADOSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaContratacion,Puesto")] Empleados empleados)
    {
        if (ModelState.IsValid)
        {
            _context.Add(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(empleados);
    }

    // GET: EMPLEADOSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleados = await _context.Empleados.FindAsync(id);
        if (empleados == null)
        {
            return NotFound();
        }
        return View(empleados);
    }

    // POST: EMPLEADOSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,FechaContratacion,Puesto")] Empleados empleados)
    {
        if (id != empleados.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(empleados);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(empleados.Id))
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
        return View(empleados);
    }

    // GET: EMPLEADOSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var empleados = await _context.Empleados
            .FirstOrDefaultAsync(m => m.Id == id);
        if (empleados == null)
        {
            return NotFound();
        }

        return View(empleados);
    }

    // POST: EMPLEADOSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var empleados = await _context.Empleados.FindAsync(id);
        if (empleados != null)
        {
            _context.Empleados.Remove(empleados);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpleadosExists(int? id)
    {
        return _context.Empleados.Any(e => e.Id == id);
    }
}
