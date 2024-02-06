using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerAudits.Domain
{
    internal class Audit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Operation {  get; set; }

        public DateTime When { get; set; }

        public string Who { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}
