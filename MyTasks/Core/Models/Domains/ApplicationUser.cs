using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyTasks.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Categories = new Collection<Category>();
            Tasks = new Collection<TaskEntity>();
        }

        public ICollection<Category> Categories { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
