using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Models;

namespace Business
{
    public static class TaskBusiness
    {

        public static void NewTask(NewTaskModel task)
        {
            var db = IsYonetim.DataBase;
            Task dbTask = new Task
            {
                Title = task.Title,
                Text = task.Text,
                BeginTime = DateTime.Now,
                EndTime = task.EndTime,
                State = task.State,
                ParentTaskId = task.ParentId,
            };
            db.Tasks.Add(dbTask);
            db.SaveChanges();
        }

        public static List<TaskModel> GetTaskChilds(int parentId)
        {
            List<TaskModel> taskModels = new List<TaskModel>();
            var db = IsYonetim.DataBase;
            List<Task> dbTasks = db.Tasks.Where(x => x.ParentTaskId == parentId).ToList();
            foreach (var dbTask in dbTasks)
            {
                TaskModel taskModel = new TaskModel
                {
                    Id = dbTask.id,
                    BeginTime = dbTask.BeginTime,
                    ParentId = dbTask.ParentTaskId,
                    EndTime = dbTask.EndTime,
                    State = dbTask.State,
                    Text = dbTask.Text,
                    Title = dbTask.Title,
                    ChildTasks = null
                };
                taskModels.Add(taskModel);
            }
            return taskModels;
        }
    }

}
