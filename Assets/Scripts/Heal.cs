using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public bool inside = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        inside = true;
        Debug.Log("Insude");
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }
}
