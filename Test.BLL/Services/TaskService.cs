using Microsoft.Extensions.Logging;
using Test.DAL;
using Test.DM;

namespace Test.BLL
{
    public class TaskService : ITaskService
    {
        private readonly IRepository _repository;

        public TaskService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateNewTaskAsync()
        {
            var result = new Guid();

            try
            {
                result = await _repository.CreateNewAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public Task<TaskModel> GetTaskByIdAsync(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}
