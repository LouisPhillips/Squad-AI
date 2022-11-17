using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    InputSystem controls;
    private Vector2 look;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    public Transform player;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new InputSystem();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        look = controls.Player.Camera.ReadValue<Vector2>();

        float mouseX = look.x * mouseSensitivity * Time.deltaTime;
        float mouseY = look.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
