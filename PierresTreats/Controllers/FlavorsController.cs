using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
        List<Flavor> model = _db.Flavors.ToList();
        return View(model);
    }

    public ActionResult AddTreat(int id)
    {
        var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
        ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
        return View(thisFlavor);
    }

    [HttpPost][Authorize]
    public async Task<ActionResult> AddTreat(Flavor flavor, int TreatId)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        flavor.User = currentUser;
        var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == TreatId);
        if (TreatId != 0)
        {
          _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId, FlavorName = flavor.Name, TreatName = thisTreat.Name });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
        ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
        return View();
    }

    [HttpPost][Authorize]
    public async Task<ActionResult> Create(Flavor flavor, int TreatId)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        flavor.User = currentUser;
        var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == TreatId);
        _db.Flavors.Add(flavor);
        if (TreatId != 0)
        {
            _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId, FlavorName = flavor.Name, TreatName = thisTreat.Name });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisFlavor = _db.Flavors
            .Include(flavor => flavor.Treats)
            .ThenInclude(join => join.Treat)
            .FirstOrDefault(flavor => flavor.FlavorId == id);
        return View(thisFlavor);
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")][Authorize]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost][Authorize]
    public ActionResult DeleteTreat(int joinId)
    {
        var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
        _db.TreatFlavor.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}
