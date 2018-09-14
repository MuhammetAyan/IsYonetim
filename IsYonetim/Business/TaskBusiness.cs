using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using IsYonetim.Models;

namespace IsYonetim.Business
{
    public static class TaskBusiness
    {

        public static void NewTask(NewTaskModel task)
        {
            var db = DatabaseEntities.IsYonetim;
            Database.Task dbTask = new Database.Task
            {
                Title = task.Title,
                Text = task.Text,
                BeginTime = DateTime.Now,
                EndTime = task.EndTime,
                State = task.State,
                ParentTaskId = task.ParentId,
            };
        }

        public static TaskModel GetTaskRecurive(int? id)
        {
            var db = DatabaseEntities.IsYonetim;
            
        }
    }
}
