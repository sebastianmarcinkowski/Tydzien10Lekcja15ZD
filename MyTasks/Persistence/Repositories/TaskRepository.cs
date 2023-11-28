using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;

namespace MyTasks.Persistence.Repositories
{
	public class TaskRepository
	{
		public IEnumerable<TaskEntity> Get(
			string userID,
			bool isExecuted = false,
			int categoryId = 0,
			string title = null)
		{
			throw new NotImplementedException();
		}

		public TaskEntity Get(int id, string userId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Category> GetCategorties()
		{
			throw new NotImplementedException();
		}

		internal void Add(TaskEntity task)
		{
			throw new NotImplementedException();
		}

		internal void Update(TaskEntity task)
		{
			throw new NotImplementedException();
		}

		internal void Finish(int id, string userId)
		{
			throw new NotImplementedException();
		}
	}
}
