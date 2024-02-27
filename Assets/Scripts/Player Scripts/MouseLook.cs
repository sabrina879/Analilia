using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public static float mouseSensitivity = 1f;

    public Transform playerBody;

    float xRotation = 0f;
    float velocityX;
    float velocityY;
    const float snappiness = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void SensStored (float sensIndex)
    {
        mouseSensitivity = sensIndex;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        velocityX = Mathf.Lerp(velocityX, mouseX, snappiness * Time.time);
        velocityY = Mathf.Lerp(velocityY, mouseY, snappiness * Time.time);


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 38f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(0, velocityX, 0);


    }


}
