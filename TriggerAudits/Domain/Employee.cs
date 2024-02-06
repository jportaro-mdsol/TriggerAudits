using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerAudits.Domain
{
    internal class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}
