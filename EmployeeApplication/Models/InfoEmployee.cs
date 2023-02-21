using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Models
{
    public class InfoEmployee
    {
        [Key]
        public int EmployeeCodeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime DateofBirth { get; set; }

        public int PhoneNumpur { get; set; }

        public string Address { get; set; }

        public int Salary { get; set; }

    }
}
