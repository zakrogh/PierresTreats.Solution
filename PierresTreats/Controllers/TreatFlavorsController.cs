using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresTreats.Controllers
{
  public class TreatFlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;
    public TreatFlavorsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<TreatFlavor> model = _db.TreatFlavor.ToList();
      return View(model);
    }
  }
}
