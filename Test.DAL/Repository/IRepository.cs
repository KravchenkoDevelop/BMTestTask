using Test.DM;

namespace Test.DAL
{
    public interface IRepository
    {
        public Task<Guid> CreateNewAsync();

        public Task<TaskModel> GetByIdAsync(Guid id);
    }
}
