using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Persistence.Services
{
	public class TaskService
	{
		private readonly UnitOfWork _unitOfWork;

		public TaskService(UnitOfWork unitOfWork)
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

		public IEnumerable<Category> GetCategorties()
		{
			return _unitOfWork.Task.GetCategorties();
		}

		public void Add(TaskEntity task)
		{
			_unitOfWork.Task.Add(task);
			_unitOfWork.Complete();
		}

		public void Update(TaskEntity task)
		{
			_unitOfWork.Task.Update(task);
			_unitOfWork.Complete();
		}

		public void Delete(int id, string userId)
		{
			_unitOfWork.Task.Delete(id, userId);
			_unitOfWork.Complete();
		}

		public void Finish(int id, string userId)
		{
			_unitOfWork.Task.Finish(id, userId);
			_unitOfWork.Complete();
		}
	}
}
