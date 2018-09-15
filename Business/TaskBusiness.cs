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

        public static void Create(NewTaskModel task)
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

        public static List<TaskModel> GetTaskChilds(int? parentId)
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

        public static void Update(TaskModel newModel)
        {
            var db = IsYonetim.DataBase;
            var dbTask = db.Tasks.FirstOrDefault(x=>x.id == newModel.Id);
            SwapBusiness.Task(ref dbTask, newModel);
            db.Tasks.Add(dbTask);
            db.SaveChanges();
        }

        public static void DeleteTask(int id)
        {
            try
            {
                var db = IsYonetim.DataBase;
                var dbTask = db.Tasks.FirstOrDefault(x => x.id == id);
                db.Tasks.Remove(dbTask);
                db.SaveChanges();
            }
            catch
            {
            }
        }

        public static void DeleteTasks(int[] ids)
        {
            try
            {
                var db = IsYonetim.DataBase;
                var dbTask = db.Tasks.Where(x => ids.Contains(x.id));
                db.Tasks.RemoveRange(dbTask);
                db.SaveChanges();
            }
            catch
            {
            }
        }
    }

}
