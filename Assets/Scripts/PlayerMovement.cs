using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputSystem controls;
    private Vector2 movement;

    public float movementSpeed;
    public float jumpHeight;

    public Transform cameraTransform;

    public GameObject commandWheel;
    public GameObject sCommandWheel;

    public GameObject AttackWheel;
    public GameObject FollowWheel;
    public GameObject aiTab;

    public bool commandWheelOpen;
    private Vector2 mousepos;
    private float currentAngle;
    public int selection;
    public bool highlighted;
    public bool pos_selected;
    public bool aSelected;
    public bool sSelected;

    public GameObject ping;
    bool pinged = false;
    float ping_delay;

    float attackDelay;
    float attackTime = 2;
    bool canAttack = true;
    bool attacking;

    public int health = 10;

    public GameObject gameManager;

    private Vector2 scrollWheel;
    public RaycastHit hit;
    public RaycastHit hitEnemy;
    public RaycastHit hitData;

    public Transform lastLookedAt;

    GameObject[] ai;

    bool grounded;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager");
        Cursor.lockState = CursorLockMode.Locked;
        commandWheel.SetActive(false);
        sCommandWheel.SetActive(false);
        FollowWheel.SetActive(true);
        AttackWheel.SetActive(false);
        aiTab.SetActive(false);
        ping.SetActive(false);

        commandWheelOpen = false;

        controls = new InputSystem();

        controls.Player.Walk.performed += context => movement = context.ReadValue<Vector2>();

        controls.Player.Walk.canceled += context => movement = Vector2.zero;

        /*controls.Player.Select.performed += context => highlighted = true;

        controls.Player.Select.canceled += context => highlighted = false;*/

        //controls.Player.Ping.performed += context => pos_selected = true;

        //controls.Player.SelectionWheel.performed += context => commandWheel.SetActive(true);
        controls.Player.SelectionWheel.performed += context => commandWheelOpen = true;
        controls.Player.SelectionWheel.performed += context => Cursor.visible = true;
        controls.Player.SelectionWheel.performed += context => Cursor.lockState = CursorLockMode.None;
        controls.Player.SelectionWheel.performed += context => cameraTransform.GetComponent<CameraLook>().enabled = false;

        //controls.Player.SelectionWheel.canceled += context => commandWheel.SetActive(false);
        controls.Player.SelectionWheel.canceled += context => commandWheelOpen = false;
        controls.Player.SelectionWheel.canceled += context => Cursor.visible = false;
        controls.Player.SelectionWheel.canceled += context => Cursor.lockState = CursorLockMode.Locked;
        controls.Player.SelectionWheel.canceled += context => cameraTransform.GetComponent<CameraLook>().enabled = true;

        controls.Player.Tab.performed += context => aiTab.SetActive(true);
        controls.Player.Tab.canceled += context => aiTab.SetActive(false);

        controls.Player.MenuSelect.performed += context => scrollWheel = context.ReadValue<Vector2>();

        ai = GameObject.FindGameObjectsWithTag("AI");
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }


    void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 7, Color.red);
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 10))
        {
            if (hit.transform.gameObject.tag == "AI")
            {
                hit.transform.gameObject.GetComponent<AI>().selected = true;
                controls.Player.Select.performed += context => highlighted = true;
            }
            else
            {
                foreach (GameObject sel_ai in ai)
                {
                    sel_ai.GetComponent<AI>().selected = false;
                    highlighted = false;
                }
            }
            // set child as false from ais cant do hit because hit isnt anything outside of raycast
        }
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitEnemy, 3))
        {
            if (hitEnemy.transform.gameObject.tag == ("Enemy"))
            {
                controls.Player.Select.performed += context => attacking = true;
                if (canAttack && attacking)
                {
                    GetComponent<Animator>().SetInteger("AttackIndex", Random.Range(0, 4));
                    GetComponent<Animator>().SetTrigger("Attack");
                    hitEnemy.transform.gameObject.GetComponent<Enemy>().health -= 1;
                    canAttack = false;
                    attacking = false;
                }

            }
        }

        if (!canAttack)
        {
            attackDelay += Time.deltaTime;
            if (attackDelay < attackTime)
            {
                canAttack = false;
            }
            else
            {
                canAttack = true;
                attackDelay = 0f;
            }

        }

        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hitData, Mathf.Infinity))
        {
            if (hit.transform.gameObject.tag == "AI")
            {
                lastLookedAt = hit.transform;
            }
            
            if(gameManager.GetComponent<GameManager>().goHereAllSelected)
            {
                if(controls.Player.Ping.triggered)
                {
                    pos_selected = true;
                }

                if(pos_selected)
                {
                    foreach(GameObject singleAI in ai)
                    {
                        singleAI.GetComponent<AI>().state = AI.enumState.Position;
                        singleAI.GetComponent<AI>().GoToPos = hitData.point;

                        ping.SetActive(true);
                        ping.transform.position = hitData.point;
                        pinged = true;
                        ping_delay = 0;
                    }
                    pos_selected = false;
                    gameManager.GetComponent<GameManager>().goHereAllSelected = false;
                }
            }

            else if (gameManager.GetComponent<GameManager>().goHereSingleSelected)
            {
                if(controls.Player.Ping.triggered)
                {
                    pos_selected = true;
                }

                if(pos_selected)
                {
                    lastLookedAt.transform.GetComponent<AI>().state = AI.enumState.Position;
                    lastLookedAt.transform.GetComponent<AI>().GoToPos = hitData.point;

                    ping.SetActive(true);
                    ping.transform.position = hitData.point;
                    pinged = true;
                    ping_delay = 0;

                    pos_selected = false;
                    gameManager.GetComponent<GameManager>().goHereSingleSelected = false;
                }
            }
        }

       /* if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hitData, Mathf.Infinity))
        {
            if (aSelected && !commandWheel.activeSelf && !sCommandWheel.activeSelf)
            {
                controls.Player.Ping.performed += context => pos_selected = true;
                if (pos_selected == true)
                {
                    foreach (GameObject thisObject in ai)
                    {
                        ping.SetActive(true);
                        ping.transform.position = hitData.point;
                        pinged = true;
                        ping_delay = 0;
                        thisObject.GetComponent<AI>().GoToPos = hitData.point;
                        thisObject.GetComponent<AI>().state = AI.enumState.Position;
                    }
                }
                pos_selected = false;
                aSelected = false;
            }

            if (sSelected && !commandWheel.activeSelf && !sCommandWheel.activeSelf)
            {
                controls.Player.Ping.performed += context => pos_selected = true;
                if (pos_selected == true)
                {
                    ping.SetActive(true);
                    ping.transform.position = hitData.point;
                    pinged = true;
                    ping_delay = 0;
                    hit.transform.GetComponent<AI>().GoToPos = hitData.point;
                    hit.transform.GetComponent<AI>().state = AI.enumState.Position;
                }
                pos_selected = false;
                sSelected = false;
            }
            //
            //
            // for single if hit.ai doesnt work make a last looked at transform which will send that one to where the player sent them, when done set the last looked at to null.
            //
            //

        }
*/


        /*if (scrollWheel.y > 0)
        {
            FollowWheel.SetActive(true);
            AttackWheel.SetActive(false);
        }
        else if (scrollWheel.y < 0)
        {
            FollowWheel.SetActive(false);
            AttackWheel.SetActive(true);
        }*/
        if (commandWheelOpen && hit.transform.gameObject.tag == "AI")
        {
            commandWheel.SetActive(false);
            sCommandWheel.SetActive(true);
        }

        else if (commandWheelOpen && hit.transform.gameObject.tag != "AI")
        {
            commandWheel.SetActive(true);
            sCommandWheel.SetActive(false);
        }
        else if (!commandWheelOpen)
        {
            commandWheel.SetActive(false);
            sCommandWheel.SetActive(false);
        }

        if (pinged)
        {
            ping_delay += Time.deltaTime;
            if (ping_delay > 5)
            {
                ping.SetActive(false);
                pinged = false;
            }
        }
    }
    void Move()
    {
        Vector3 playerDirection = (movement.y * transform.forward) + (movement.x * transform.right);
        transform.position += playerDirection * movementSpeed * Time.deltaTime;
    }

    void Attack()
    {


    }
}
