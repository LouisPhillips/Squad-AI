using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBack : MonoBehaviour
{
    public void GoToPlayer()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().fallBackAllSelected = true;
    }
}
