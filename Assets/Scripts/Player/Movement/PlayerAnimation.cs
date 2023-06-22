using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    public float acceleration = 2.0f;
    public float decceleration = 2.0f;
    // Start is called before the first frame update
    void Start() {
     animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update(){
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backPressed = Input.GetKey("s");

        if(forwardPressed){
            velocityX += Time.deltaTime * acceleration;
        }

        if(backPressed){
            velocityX -= Time.deltaTime * acceleration;
        }

        if(leftPressed){
            velocityZ -= Time.deltaTime * acceleration;
        }
        
         if(leftPressed){
            velocityZ += Time.deltaTime * acceleration;
        }

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);

    }
}
