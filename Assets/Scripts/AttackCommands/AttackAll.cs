using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAll : MonoBehaviour
{
    public void Attack()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        manager.GetComponent<GameManager>().attackAllSelected = true;
    }
}
