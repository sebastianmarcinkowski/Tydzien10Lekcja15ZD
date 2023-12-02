﻿using MyTasks.Core.Models.Domains;
using System.Collections.Generic;

namespace MyTasks.Core.ViewModels
{
    public class TaskViewModel
    {
        public string Heading { get; set; }
        public TaskEntity Task { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
