using MyTasks.Core.Repositories;

namespace MyTasks.Core
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
        void Complete();
    }
}
