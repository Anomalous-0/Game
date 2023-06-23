using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {
    
    
    public Camera cam;
    private float xRotation = 0f;
    public float xSense = 30f;
    public float ySense = 30f;

    public void ProcessLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;
        //Calculate the camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySense;
        xRotation = Mathf.Clamp(xRotation, -80, 75f);
        //Apply this to our camera's transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSense); 
    }
    
}