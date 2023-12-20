using System.ComponentModel.DataAnnotations;

namespace Test.DM
{
    [Flags]
    public enum TaskStatus
    {
        [Display(Name = "Created")]
        Created = 0,

        [Display(Name = "Runnin")]
        InProgress = 1,

        [Display(Name = "Finished")]
        Done = 2,
    }
}
