using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Models
{
    public class infoEmployeeSub
    {
        [Key]
        public int aseriesId { get; set; }

        public string EmployeeCode { get; set; }

        public DateTime holidaydate { get; set; }

        public int Thenumberofdays { get; set; }

        public string Isitvacation { get; set; }

        public string Statement { get; set; }
    }
}
