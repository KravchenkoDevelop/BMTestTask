using Microsoft.EntityFrameworkCore;
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


                await _context.Tasks.AddAsync(nTask);
                await _context.SaveChangesAsync();

                result = (Guid)nTask.Id;

                Task.Run(() => UpdateState(result, 10, DM.TaskStatus.InProgress));

            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            var result = new TaskModel();

            try
            {
                result = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }

        private async Task UpdateState(Guid id, int timeout, DM.TaskStatus status)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeout));

            try
            {
                var upd = _context.Tasks.First(t => t.Id == id);

                if (upd.Status == DM.TaskStatus.Created || upd.Status == DM.TaskStatus.InProgress)
                {
                    upd.Status = status;
                    upd.ChangeDate = DateTime.Now;
                    _context.Tasks.Update(upd);
                    await _context.SaveChangesAsync();

                    Task.Run(() => UpdateState(id, 120, DM.TaskStatus.Done));
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
