using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DM
{
    [Flags]
    public enum TaskStatus
    {
        [Display(Name = "Created")]
        Created = 0,

        [Display(Name = "In progress")]
        InProgress = 1,

        [Display(Name = "Done")]
        Done = 2,
    }
}
