using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entity
{
    [Table("Emplyeee")]
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string JobRole { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool FirstAppointment { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [StringLength(250)]
        public string? Notes { get; set; }
    }
}
