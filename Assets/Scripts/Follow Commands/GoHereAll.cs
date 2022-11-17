using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHereAll : MonoBehaviour
{
    public bool HereSelected;

    public void Selected()
    {
        HereSelected = true;
    }

    public void Completed()
    {
        Debug.Log("Completed");
        HereSelected = false;
    }

    public void Single()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().goHereAllSelected = true;
    }
}
