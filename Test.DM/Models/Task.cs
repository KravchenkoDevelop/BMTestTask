using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DM
{
    /// <summary>
    /// task object
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// task id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// task header
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// task description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// task start date
        /// </summary>
        public DateTime Start { get; set; } = DateTime.Now;

        /// <summary>
        /// task end date
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// task status
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}
