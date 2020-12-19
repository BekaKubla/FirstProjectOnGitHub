using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SellAutoProject.ViewModels
{
    public class UpdateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string FuelType { get; set; }
        [Required]
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
