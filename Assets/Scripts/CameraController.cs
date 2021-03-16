using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Control Properties
    [Header("Controls")]
    public Joystick rightStick;

    public float sensitivity = 1000.0f;
    public Transform playerBody;

    private float XAxisRotation = 0.0f;

    private Vector2 mouse;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Make the cursor dissapeared
    }

    // Update is called once per frame
    void Update()
    {
        // mouse.x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        // mouse.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouse.x = rightStick.Horizontal * sensitivity;
        mouse.y = rightStick.Vertical * sensitivity;

        // Look up and down
        XAxisRotation -= mouse.y;
        XAxisRotation = Mathf.Clamp(XAxisRotation, -90.0f, 90.0f);
        transform.localRotation = Quaternion.Euler(XAxisRotation, 0.0f, 0.0f);

        // Look left and right and rotate around the Y axis
        playerBody.Rotate(Vector3.up * mouse.x);
    }
}
