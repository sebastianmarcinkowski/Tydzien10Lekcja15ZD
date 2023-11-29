using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Models;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Services;
using MyTasks.Core.ViewModels;
using MyTasks.Persistence.Extensions;
using System;

namespace MyTasks.Controllers
{
	[Authorize]
	public class TaskController : Controller
	{
		private readonly ITaskService _taskService;

		public TaskController(ITaskService taskService)
		{
			_taskService = taskService;
		}

		public IActionResult Tasks()
		{
			var userId = User.GetUserId();

			var tasks = _taskService.Get(userId);
			var categories = _taskService.GetCategorties();

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

			var tasks = _taskService.Get(
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
				_taskService.Get(id, userId);

			var vm = new TaskViewModel
			{
				Task = task,
				Heading = id == 0 ?
					"Dodawanie nowego zadania"
					:
					"Edytowanie zadania",
				Categories = _taskService.GetCategorties()
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
					Categories = _taskService.GetCategorties()
				};

				return View("Task", vm);
			}

			if (task.Id == 0)
				_taskService.Add(task);
			else
				_taskService.Update(task);

			return RedirectToAction("Tasks");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var userId = User.GetUserId();

				_taskService.Delete(id, userId);
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

				_taskService.Finish(id, userId);
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
