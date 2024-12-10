using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    internal interface ITaskService
    {
        Task SaveTaskAsync(Tasks task);
        Task<List<Tasks>> LoadTasksAsync();
    }
}
