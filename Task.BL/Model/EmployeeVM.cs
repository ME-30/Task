using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BL.Model
{
    public class EmployeeVM
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Enter your Name")]
        [StringLength(50, ErrorMessage ="Max Len 50")]
        [MinLength(2, ErrorMessage ="Min len 2")]
        public string Name { get; set; }

        [Required]
        public string JobRole { get; set; }

        [Required]
        public string Gender { get; set; }

        public bool FirstAppointment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string? Notes { get; set; }
    }
}
