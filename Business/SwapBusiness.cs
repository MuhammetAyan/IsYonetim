using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Models;

namespace Business
{
    public static class SwapBusiness
    {
        public static void Task(ref Task dbtask, TaskModel taskModel)
        {
            dbtask = new Task
            {
                Title = taskModel.Title,
                Text = taskModel.Text,
                BeginTime = taskModel.BeginTime,
                EndTime = taskModel.EndTime,
                ParentTaskId = taskModel.ParentId,
                State = taskModel.State,
            };
        }
    }
}
