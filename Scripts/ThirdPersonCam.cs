using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    private VariableJoystick joystick;
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    public float rotationSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        joystick = GameUIManager.instance.joystick;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        /*float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inputDir != Vector3.zero)
        {
            player.forward = Vector3.Slerp(playerObj.forward, inputDir, rotationSpeed * Time.deltaTime);
        }*/
    }
}
