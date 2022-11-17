using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{
    public void RetreatF()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().retreatAllSelected = true;
    }
}
