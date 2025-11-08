using Microsoft.AspNetCore.Mvc;
using System.Data;
using UnitConverter.Models;

namespace UnitConverter.Controllers
{
    public class LengthConvertController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
        {
            double resultado = HomeController.ConvertirLongitud(unidad.Input, unidad.UnitFrom, unidad.UnitTo);
            ViewData["Resultado"] = resultado;
            return View();
        }
    }
}
