using Microsoft.AspNetCore.Mvc;
using UnitConverter.Models;

namespace UnitConverter.Controllers
{
    public class WeightConvertController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
        {
            double resultado = HomeController.ConvertirPeso(unidad.Input, unidad.UnitFrom, unidad.UnitTo);
            ViewData["Resultado"] = resultado;
            return View();
        }
    }
}
