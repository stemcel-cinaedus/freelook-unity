using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class Freelook : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public InputAction move;
    public InputAction reorient;
    public float rotateSpeed = 0.5f;
    public float moveSpeed = 0.05f;

    //var keymap = new InputActionMap("Freelook");

    void OnEnable() {
       cam = gameObject.GetComponent<Camera>();
    }


    //See if mouse is connected and if the right button is pressed. If so, change the camera orientation according to the negation of the movement delta (i.e, dragging down moves the camera up)

    void Update() 
    {
        if (Mouse.current != null && Mouse.current.rightButton.isPressed) {
            float x = Mouse.current.delta.x.ReadValue();
            float y = Mouse.current.delta.y.ReadValue();
            Vector3 currRotation = cam.transform.eulerAngles;

             
            cam.transform.rotation = Quaternion.Euler(new Vector3(currRotation.x - y * rotateSpeed, currRotation.y - x * rotateSpeed, 0f));
        }

        if (Keyboard.current != null) {
            Vector3 megatheta = cam.transform.forward;
            Vector3 ultratheta = cam.transform.right;

            if (Keyboard.current.wKey.isPressed)
            cam.transform.position += megatheta * moveSpeed;
            if (Keyboard.current.aKey.isPressed)
            cam.transform.position -= ultratheta * moveSpeed;
            if (Keyboard.current.sKey.isPressed)
            cam.transform.position -= megatheta * moveSpeed;
            if (Keyboard.current.dKey.isPressed)
            cam.transform.position += ultratheta * moveSpeed;
        }


    }
}