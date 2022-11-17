 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHereS : MonoBehaviour
{
    public void Single()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().goHereSingleSelected = true;

    }
}
