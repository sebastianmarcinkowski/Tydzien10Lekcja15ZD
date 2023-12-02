using MyTasks.Core;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Services;
using System.Collections.Generic;

namespace MyTasks.Persistence.Services
{
	public class TaskService : ITaskService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TaskService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<TaskEntity> Get(
			string userId,
			bool isExecuted = false,
			int categoryId = 0,
			string title = null)
		{
			return _unitOfWork.Task.Get(
				userId,
				isExecuted,
				categoryId,
				title);
		}

		public TaskEntity Get(int id, string userId)
		{
			return _unitOfWork.Task.Get(id, userId);
		}

		public IEnumerable<Category> GetCategorties(string userId)
		{
			return _unitOfWork.Task.GetCategorties(userId);
		}

		public Category GetCategory(int id, string userId)
        {
			return _unitOfWork.Task.GetCategory(id, userId);
        }

		public void Add(TaskEntity task)
		{
			_unitOfWork.Task.Add(task);
			_unitOfWork.Complete();
		}
		public void AddCategory(Category category)
		{
			_unitOfWork.Task.AddCategory(category);
			_unitOfWork.Complete();
		}

		public void Update(TaskEntity task)
		{
			_unitOfWork.Task.Update(task);
			_unitOfWork.Complete();
		}

		public void UpdateCategory(Category category)
		{
			_unitOfWork.Task.UpdateCategory(category);
			_unitOfWork.Complete();
		}

		public void Delete(int id, string userId)
		{
			_unitOfWork.Task.Delete(id, userId);
			_unitOfWork.Complete();
		}

		public void DeleteCategory(int id, string userId)
		{
			_unitOfWork.Task.DeleteCategory(id, userId);
			_unitOfWork.Complete();
		}

		public void Finish(int id, string userId)
		{
			_unitOfWork.Task.Finish(id, userId);
			_unitOfWork.Complete();
		}
	}
}
