using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CmGameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CmTaskSystem taskSystem = new CmTaskSystem();

        Debug.Log(taskSystem.RequestNextTask());
        CmTaskSystem.Task task = new CmTaskSystem.Task();
        taskSystem.AddTask(task);
        Debug.Log(taskSystem.RequestNextTask());
        Debug.Log(taskSystem.RequestNextTask());


    }

}
