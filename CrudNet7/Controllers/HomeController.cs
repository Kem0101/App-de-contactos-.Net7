using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudNet7.Models;
using CrudNet7.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace CrudNet7.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _contexto;

    public HomeController(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _contexto.Contacto.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contacto contacto)
    {
        if (ModelState.IsValid)
        {
            _contexto.Contacto.Add(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [HttpGet]
    public IActionResult Edit(int? Id)
    {
        if(Id == null)
        {
            return NotFound();
        }

        var contacto = _contexto.Contacto.Find(Id);
        if(contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Contacto contacto)
    {
        if (ModelState.IsValid)
        {
            _contexto.Contacto.Update(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [HttpGet]
    public IActionResult Detail(int? Id)
    {
        if (Id == null)
        {
            return NotFound();
        }

        var contacto = _contexto.Contacto.Find(Id);
        if (contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    [HttpGet]
    public IActionResult Delete(int? Id)
    {
        if (Id == null)
        {
            return NotFound();
        }

        var contacto = _contexto.Contacto.Find(Id);
        if (contacto == null)
        {
            return NotFound();
        }

        return View(contacto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteContacto(int? Id)
    {
        var contacto = await _contexto.Contacto.FindAsync(Id);
        if (contacto == null)
        {
            return View();
        }

        _contexto.Contacto.Remove(contacto);
        await _contexto.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

