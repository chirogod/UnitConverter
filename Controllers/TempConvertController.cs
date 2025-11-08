using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using UnitConverter.Models;

namespace UnitConverter.Controllers
{
    public class TempConvertController : Controller
    {
        public  IActionResult Index([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
        {
            double result = 0;
            if (unidad.UnitFrom == "Celsius" && unidad.UnitTo == "Fahrenheit")
            {
                result = (unidad.Input * 9 / 5) + 32;
            }
            else if (unidad.UnitFrom == "Fahrenheit" && unidad.UnitTo == "Celsius")
            {
                result = (unidad.Input - 32) * 5 / 9;
            }
            else if (unidad.UnitFrom == "Celsius" && unidad.UnitTo == "Kelvin")
            {
                result = unidad.Input + 273.15;
            }
            else if (unidad.UnitFrom == "Kelvin" && unidad.UnitTo == "Celsius")
            {
                result = unidad.Input - 273.15;
            }
            else if (unidad.UnitFrom == "Fahrenheit" && unidad.UnitTo == "Kelvin")
            {
                result = (unidad.Input - 32) * 5 / 9 + 273.15;
            }
            else if (unidad.UnitFrom == "Kelvin" && unidad.UnitTo == "Fahrenheit")
            {
                result = (unidad.Input - 273.15) * 9 / 5 + 32;
            }
            ViewData["Resultado"] = $"Resultado de {unidad.Input}{unidad.UnitFrom} a {unidad.UnitTo}: {result} ";
            return View();
        }
    }
}
