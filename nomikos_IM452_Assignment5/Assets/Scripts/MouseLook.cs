/*
* William Nomikos
* MouseLook.cs
* Assignment 5
* Script handles player rotation when the mouse is moved.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public Image crossHair;
    public Sprite crossHairUnselected;
    public Sprite crossHairSelected;

    public LayerMask enemyLayer;
    public LayerMask buttonLayer;

    public float interactionDistance = 1f;
    public float shootDistance = 1f;

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
        
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDistance, buttonLayer))
        {
            crossHair.sprite = crossHairSelected;

            //Debug.DrawRay(ray, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.GetComponent<ButtonController>() != null)
                {
                    hit.collider.GetComponent<ButtonController>().ClickButton();
                }
            }
        }
        else if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootDistance, enemyLayer))
        {
            crossHair.sprite = crossHairSelected;

            //Debug.DrawRay(ray, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //if (hit.collider.GetComponent<ButtonController>() != null)
                //{
                //    hit.collider.GetComponent<ButtonController>().PushButton();
                //}
            }
        }
        else
        {
            crossHair.sprite = crossHairUnselected;
        }
    }
}
