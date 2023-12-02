using MyTasks.Core;
using MyTasks.Core.Repositories;
using MyTasks.Persistence.Repositories;

namespace MyTasks.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;

            Task = new TaskRepository(context);
        }

        public ITaskRepository Task { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
