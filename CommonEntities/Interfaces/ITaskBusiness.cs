using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntities.Interfaces
{
    public interface ITaskBusiness
    {
        bool AddTask(TaskModel task);
        List<TaskModel> GetParentTasks();
        List<TaskModel> getTasks(string sortingParameter);

        bool endTask(TaskModel Task);
    }
}
