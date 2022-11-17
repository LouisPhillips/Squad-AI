using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAll : MonoBehaviour
{
    public void CallAll()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().followAllSelected = true;
    }

}
