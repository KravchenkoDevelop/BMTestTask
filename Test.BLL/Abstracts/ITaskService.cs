using Test.DM;

namespace Test.BLL
{
    public interface ITaskService
    {
        /// <summary>
        /// create new task object
        /// </summary>
        /// <returns>guid</returns>
        public Task<Guid> CreateNewTaskAsync();

        /// <summary>
        /// get task object by id
        /// </summary>
        /// <param name="taskId">task id guid type</param>
        /// <returns>task object</returns>
        public Task<TaskModel> GetTaskByIdAsync(Guid taskId);
    }
}
