using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UnitConverter.Models;

namespace UnitConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Length()
        {
            ViewBag.Longitudes = Longitudes.Keys;
            return View();
        }

        [HttpPost]
        public IActionResult Length([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
        {
            double resultado = ConvertirLongitud(unidad.Input, unidad.UnitFrom, unidad.UnitTo);
            ViewData["Resultado"] = $"{unidad.Input} {unidad.UnitFrom} son: {resultado} {unidad.UnitTo}";
            ViewBag.Longitudes = Longitudes.Keys;
            return View();
        }

        [HttpGet]
        public IActionResult Weight()
        {
            ViewBag.Pesos = Pesos.Keys;
            return View();
        }

        [HttpPost]
        public IActionResult Weight([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
        {
            double resultado = ConvertirPeso(unidad.Input, unidad.UnitFrom, unidad.UnitTo);
            ViewData["Resultado"] = $"{unidad.Input} {unidad.UnitFrom} son: {resultado} {unidad.UnitTo}";
            ViewBag.Pesos = Pesos.Keys;
            return View();
        }
        [HttpGet]
        public IActionResult Temperature()
        {
            ViewBag.Pesos = Pesos.Keys;
            return View();
        }

        [HttpPost]
        public IActionResult Temperature([Bind("Input,UnitFrom,UnitTo")] Unidad unidad)
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
            ViewData["Resultado"] = $"{unidad.Input} {unidad.UnitFrom} son: {result} {unidad.UnitTo}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static Dictionary<string, double> Pesos = new Dictionary<string, double>()
        {
            {"Miligramos", 0.000001},
            {"Gramos", 0.001 },
            {"Kilogramos", 1},
            {"Onzas", 0.0283495},
            {"Libra", 0.4535920000001679  }
        };

        public static Dictionary<string, double> Longitudes = new Dictionary<string, double>()
        {
            {"Milimetros", 0.001},
            {"Centimetros", 0.01 },
            {"Metros", 1},
            {"Kilometros", 1000},
            {"Inches", 0.0254 },
            {"Pies", 0.3048},
            {"Yarda", 0.9144},
            {"Milla", 1609.34 }
        };

        public static double ConvertirPeso(double input, string fromUnit, string toUnit)
        {
            if (string.IsNullOrEmpty(fromUnit) || string.IsNullOrEmpty(toUnit))
            {
                throw new ArgumentException("Las unidades de origen y destino deben estar seleccionadas.");
            }
            double inputInKg = input * Pesos[fromUnit];
            double result = inputInKg / Pesos[toUnit];
            return result;
        }

        public static double ConvertirLongitud(double input, string fromUnit, string toUnit)
        {
            double inputInMeters = input * Longitudes[fromUnit];
            double result = inputInMeters / Longitudes[toUnit];
            return result;
        }
    }
}
