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
