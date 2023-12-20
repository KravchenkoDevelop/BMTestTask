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
        /// task start date
        /// </summary>
        public DateTime ChangeDate { get; set; } = DateTime.Now;


        /// <summary>
        /// task status
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}
