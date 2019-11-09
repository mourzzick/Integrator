using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Assignment
    {
        public string AssignmentId { get; set; }
        public string AssignmentGrade { get; set; }

        public Assignment()
        {
            AssignmentId = string.Empty;
            AssignmentGrade = string.Empty;
        }
    }
}
