using Microsoft.AspNetCore.Mvc;

namespace first.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor/CheckTemperature
        [HttpGet]
        public IActionResult CheckTemperature()
        {
            return View();
        }

        // POST: Doctor/CheckTemperature
        [HttpPost]
        public IActionResult CheckTemperature(double? temperature, string scale)
        {
            if (temperature == null)
            {
                ViewBag.Message = "Please enter a temperature value.";
            }
            else
            {
                double tempCelsius = scale == "Fahrenheit" ? (temperature.Value - 32) * 5 / 9 : temperature.Value;
                if (tempCelsius >= 38)
                {
                    ViewBag.Message = "You have a fever.";
                }
                else if (tempCelsius < 35)
                {
                    ViewBag.Message = "You have hypothermia.";
                }
                else
                {
                    ViewBag.Message = "Your temperature is normal.";
                }
            }

            return View();
        }
    }
}
