using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DM;

namespace Test.BLL
{
    public class TaskService : ITaskService
    {
        public Task<Guid> CreateNewTaskAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetTaskByIdAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}
