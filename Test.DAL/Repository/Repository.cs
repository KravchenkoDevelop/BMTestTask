using Microsoft.Extensions.Logging;
using Test.DM;

namespace Test.DAL
{
    public class Repository : IRepository
    {
        private readonly TaskDBContext _context;

        public Repository(TaskDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateNewAsync()
        {
            var result = new Guid();

            try
            {
                var nTask = new TaskModel();

                using (var context=_context)
                {
                    await context.Tasks.AddAsync(nTask);
                    await context.SaveChangesAsync();
                   
                    result = nTask.Id;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public Task<TaskModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
