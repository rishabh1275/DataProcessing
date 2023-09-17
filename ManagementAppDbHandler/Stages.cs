using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;

namespace ManagementAppDbHandler
{
    public class Stages
    {
        [Column("Opportunity ID")]
        public string OpportunityID { get; set; }
        public string Stage { get; set; }
    }
}
