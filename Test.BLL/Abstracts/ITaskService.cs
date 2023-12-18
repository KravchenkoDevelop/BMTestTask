using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DM;

namespace Test.BLL
{
    public interface ITaskService
    {
        public Task<Guid> CreateNewTaskAsync(TaskModel task);

        public Task<TaskModel> GetTaskByIdAsync(Guid taskId);
    }
}
