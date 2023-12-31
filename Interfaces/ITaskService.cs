﻿using StudyTrackerSystem.Models;

namespace StudyTrackerSystem.Interfaces;

public interface ITaskService
{
    #region Methoods
    TaskModel Create(TaskModel task);
    TaskModel GetById(int id);
    TaskModel Update(int id, TaskModel task);
    bool Delete(int id);
    List<TaskModel> GetAll();
    List<TaskModel> GetTasksOrderByDeadline();
    #endregion
}
