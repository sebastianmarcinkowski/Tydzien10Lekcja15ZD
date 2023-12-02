using MyTasks.Core.Models.Domains;
using System.Collections.Generic;

namespace MyTasks.Core.Repositories
{
	public interface ITaskRepository
	{
		IEnumerable<TaskEntity> Get(
			string userId,
			bool isExecuted = false,
			int categoryId = 0,
			string title = null);
		TaskEntity Get(int id, string userId);
		IEnumerable<Category> GetCategorties(string userId);
		Category GetCategory(int id, string userId);
		void Add(TaskEntity task);
		void AddCategory(Category category);
		void Update(TaskEntity task);
		void UpdateCategory(Category category);
		void Delete(int id, string userId);
		void DeleteCategory(int id, string userId);
		void Finish(int id, string userId);
	}
}
