using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowS : MonoBehaviour
{
    public void Single()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().followSingleSelected = true;
    }
}
