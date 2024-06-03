using System.ComponentModel.DataAnnotations;

namespace first.Models
{
    public class TemperatureCheck
    {
        [Required]
        [Display(Name = "Temperature (°F)")]
        public double Temperature { get; set; }

        public string Message { get; set; }

        public void CheckTemperature()
        {
            if (Temperature >= 100.4)
            {
                Message = "You have a fever.";
            }
            else if (Temperature < 90)
            {
                Message = "You have hypothermia.";
            }
            else
            {
                Message = "Your temperature is normal.";
            }
        }
    }
}
//using System.ComponentModel.DataAnnotations;

//namespace first.Models
//{
//    public class TemperatureCheck
//    {
//        [Required(ErrorMessage = "Temperature is required.")]
//        public double? Temperature { get; set; }

//        [Required(ErrorMessage = "Scale is required.")]
//        public required string Scale { get; set; }

//        public required string ResultMessage { get; set; }

//        public void EvaluateTemperature()
//        {
//            if (Temperature == null)
//            {
//                ResultMessage = "Please enter a temperature value.";
//                return;
//            }

//            double tempCelsius = Scale == "Fahrenheit" ? (Temperature.Value - 32) * 5 / 9 : Temperature.Value;

//            if (tempCelsius >= 38)
//            {
//                ResultMessage = "You have a fever.";
//            }
//            else if (tempCelsius < 35)
//            {
//                ResultMessage = "You have hypothermia.";
//            }
//            else
//            {
//                ResultMessage = "Your temperature is normal.";
//            }
//        }
//    }
//}
