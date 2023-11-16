using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTasks.Persistence
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<TaskEntity> Tasks { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
