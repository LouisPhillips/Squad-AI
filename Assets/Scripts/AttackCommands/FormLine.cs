using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormLine : MonoBehaviour
{
    public void Push()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().lineUpAllSelected = true;
    }
}
