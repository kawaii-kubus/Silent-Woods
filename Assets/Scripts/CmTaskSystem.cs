using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmTaskSystem 
{
    public class Task
    {

    }

    private List<Task> taskList;
    public CmTaskSystem()
    {
        taskList = new List<Task>();
    }

    public Task RequestNextTask()
    {
        if(taskList.Count > 0) 
        {
            Task task = taskList[0];
            taskList.RemoveAt(0);
            return task;
        }
        else
        {
            return null;
        }
    }

    public void AddTask(Task task)
    {
        taskList.Add(task);
    }
}
