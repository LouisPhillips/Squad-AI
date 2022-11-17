using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAll : MonoBehaviour
{
    public void Stop()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().stopAllSelected = true;
    }
}
