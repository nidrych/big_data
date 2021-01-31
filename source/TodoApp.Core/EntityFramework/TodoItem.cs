using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Core.EntityFramework
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
