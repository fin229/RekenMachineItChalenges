using Microsoft.AspNetCore.Mvc;
using Rekenmachine.Models;
using System.Diagnostics;

namespace Rekenmachine.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bereken()
        {
            return View();
        }

        [HttpPost("Boete")]
        public IActionResult Boete(int snelheid)
        {
            double boeteBedrag = 0;
            string resultaat = "Proficiat, u bent een van de weinige die niet te hard rijdt!";

            if (snelheid > 50)
            {
                boeteBedrag = 125;
                for (int i = snelheid; i > 50; i--)
                {
                    boeteBedrag += 25;
                }
                resultaat = $"Foei, u krijgt een boete van €{boeteBedrag}";
            }

            ViewData["BoeteResultaat"] = resultaat;

            return View();
        }

        [HttpPost("Bereken")]
        public IActionResult Bereken(double num1, double num2, string bewerking)
        {
            double resultaat = 0;

            switch (bewerking)
            {
                case "optellen":
                    resultaat = num1 + num2;
                    break;
                case "aftrekken":
                    resultaat = num1 - num2;
                    break;
                case "vermenigvuldigen":
                    resultaat = num1 * num2;
                    break;
                case "delen":
                    if (num2 != 0)
                        resultaat = num1 / num2;
                    else
                        resultaat = double.NaN;
                    break;
            }

            ViewData["Resultaat"] = resultaat;

            return View();

        }
        public IActionResult NaamOmgekeerd()
        {
            return View();
        }

        [HttpPost("NaamOmgekeerd")]
        public IActionResult NaamOmgekeerd(string naam)
        {
            char[] Tekenreeks = naam.ToCharArray();
            Array.Reverse(Tekenreeks);
            string omgekeerdeNaam = new(Tekenreeks);
            ViewData["OmgekeerdeNaam"] = omgekeerdeNaam;
            return View();
        }


    }

}