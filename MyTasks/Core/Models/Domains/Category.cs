using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyTasks.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Tasks = new Collection<TaskEntity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
