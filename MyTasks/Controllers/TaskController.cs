using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Models;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.ViewModels;
using MyTasks.Persistence;
using MyTasks.Persistence.Extensions;
using MyTasks.Persistence.Repositories;
using System;

namespace MyTasks.Controllers
{
	[Authorize]
	public class TaskController : Controller
	{
		private TaskRepository _taskRepository;

		public TaskController(ApplicationDbContext context)
		{
			_taskRepository = new TaskRepository(context);
		}

		public IActionResult Tasks()
		{
			var userId = User.GetUserId();

			var tasks = _taskRepository.Get(userId);
			var categories = _taskRepository.GetCategorties();

			var vm = new TasksViewModel
			{
				FilterTasks = new FilterTasks(),
				Tasks = tasks,
				Categories = categories
			};

			return View(vm);
		}

		[HttpPost]
		public IActionResult Tasks(TasksViewModel vm)
		{
			var userID = User.GetUserId();

			var tasks = _taskRepository.Get(
				userID,
				vm.FilterTasks.IsExecuted,
				vm.FilterTasks.CategoryId,
				vm.FilterTasks.Title);

			return PartialView("_TasksTable", tasks);
		}

		public IActionResult Task(int id = 0)
		{
			var userId = User.GetUserId();

			var task = id == 0 ?
				new TaskEntity
				{
					Id = 0,
					UserId = userId,
					Term = DateTime.Today
				}
				:
				_taskRepository.Get(
					id, userId);

			var vm = new TaskViewModel
			{
				Task = task,
				Heading = id == 0 ?
					"Dodawanie nowego zadania"
					:
					"Edytowanie zadania",
				Categories = _taskRepository.GetCategorties()
			};

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Task(TaskEntity task)
		{
			var userId = User.GetUserId();
			task.UserId = userId;

			if (!ModelState.IsValid)
			{
				var vm = new TaskViewModel
				{
					Task = task,
					Heading = task.Id == 0 ?
					"Dodawanie nowego zadania"
					:
					"Edytowanie zadania",
					Categories = _taskRepository.GetCategorties()
				};

				return View("Task", vm);
			}

			if (task.Id == 0)
				_taskRepository.Add(task);
			else
				_taskRepository.Update(task);

			return RedirectToAction("Tasks");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var userId = User.GetUserId();

				_taskRepository.Delete(
					id,
					userId);
			}
			catch (Exception ex)
			{
				// logging

				return Json(new
				{
					success = false,
					message = ex.Message
				});
			}

			return Json(new { success = true });
		}

		[HttpPost]
		public IActionResult Finish(int id)
		{
			try
			{
				var userId = User.GetUserId();

				_taskRepository.Finish(
					id,
					userId);
			}
			catch (Exception ex)
			{
				// logging

				return Json(new
				{
					success = false,
					message = ex.Message
				});
			}

			return Json(new { success = true });
		}
	}
}
