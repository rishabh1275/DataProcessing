using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;

namespace ManagementAppDbHandler
{
    public class Notes
    {
        public DateTime? InputDate;
        public string InputNote;
        public Notes(DateTime dt, string nt)
        {
            this.InputDate = dt;
            this.InputNote = nt;
        }
    }
}
