using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool followSingleSelected;
    public bool stopSingleSelected;
    public bool goHereSingleSelected;
    public bool attackSingleSelected;

    public bool followAllSelected;
    public bool stopAllSelected;
    public bool goHereAllSelected;
    public bool attackAllSelected;
    public bool fallBackAllSelected;
    public bool lineUpAllSelected;
    public bool formPositionAllSelected;
    public bool pushForwardAllSelected;
    public bool retreatAllSelected;

    public GameObject attackIndicator;

    private GameObject player;
    GameObject[] ai;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GameObject.FindGameObjectsWithTag("AI");
        attackIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Single

        if (followSingleSelected && player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().selected && player.GetComponent<PlayerMovement>().highlighted)
        {
            player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().state = AI.enumState.Following;
            followSingleSelected = false;
        }

        if (stopSingleSelected && player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().selected && player.GetComponent<PlayerMovement>().highlighted)
        {
            player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().state = AI.enumState.Idle;
            stopSingleSelected = false;
        }

        if (goHereSingleSelected && player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().selected && player.GetComponent<PlayerMovement>().highlighted)
        {
            player.GetComponent<PlayerMovement>().sSelected = true;
           /* if (player.GetComponent<PlayerMovement>().pos_selected == false)
            {
                goHereSingleSelected = false;
            }*/
        }

        if (attackSingleSelected && player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().selected && player.GetComponent<PlayerMovement>().highlighted)
        {
            player.GetComponent<PlayerMovement>().hit.transform.gameObject.GetComponent<AI>().state = AI.enumState.Attacking;
            attackSingleSelected = false;
        }


        // All


        if (followAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.Following;
                followAllSelected = false;
            }
        }

        if (stopAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.Idle;
                stopAllSelected = false;
            }
        }

        if (goHereAllSelected)
        {
            foreach (GameObject go in ai)
            {
                player.GetComponent<PlayerMovement>().aSelected = true;
                /*if (player.GetComponent<PlayerMovement>().pos_selected == false)
                {
                    goHereAllSelected = false;
                }*/
            }
        }

        if (attackAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.Attacking;
                attackAllSelected = false;
            }
        }

        if (fallBackAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.LineUp;
                fallBackAllSelected = false;
            }
        }

        if (lineUpAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.LineUp;
                lineUpAllSelected = false;
            }
        }

        if (formPositionAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.FormPosition;
                formPositionAllSelected = false;
            }
        }

        if (pushForwardAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.PushForward;
                pushForwardAllSelected = false;
            }
        }

        if (retreatAllSelected)
        {
            foreach (GameObject go in ai)
            {
                go.transform.gameObject.GetComponent<AI>().state = AI.enumState.Retreat;
                retreatAllSelected = false;
            }
        }

        // other

        foreach (GameObject go in ai)
        {
            if (go.transform.GetComponent<AI>().attacked)
            {
                Debug.Log("getting attacked");
                attackIndicator.SetActive(true);
                if(player.GetComponent<PlayerMovement>().commandWheel.active == true)
                {
                    attackIndicator.SetActive(false);
                }
            }
            else
            {
                attackIndicator.SetActive(false);
            }
            
        }
    }
}
