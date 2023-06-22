using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    float velocityX = 0.0f;
    float velocityZ = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maxWalkV = 0.5f;
    public float maxRunV = 2.0f;

    int VelocityZHash;
    int VelocityXHash;
    // Start is called before the first frame update
    void Start() {
     animator = GetComponent<Animator>();    
     VelocityXHash = Animator.StringToHash("Velocity X");
     VelocityZHash = Animator.StringToHash("Velocity Z");
    }

    //Handles acceleration and deceleration
    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity){
        if(forwardPressed && velocityZ < currentMaxVelocity){
            velocityZ += Time.deltaTime * acceleration;
        }

        if(backPressed && velocityZ > -currentMaxVelocity){
            velocityZ -= Time.deltaTime * acceleration;
        }

        if(leftPressed && velocityX > -currentMaxVelocity){
            velocityX -= Time.deltaTime * acceleration;
        }
        
         if(rightPressed && velocityX < currentMaxVelocity){
            velocityX += Time.deltaTime * acceleration;
        }

        // Decrease velocityZ
        if(!forwardPressed && velocityZ > 0.0f){
            velocityZ -= Time.deltaTime * deceleration* 3;
        }

        // Increase velocityX if left is not pressed and velocityX < 0; Bring it to idle
        if(!leftPressed && velocityX < 0.0f){
            velocityX += Time.deltaTime * deceleration * 3;
        }
        // Same for right: bring back to center
        if(!rightPressed && velocityX > 0.0f){
            velocityX -= Time.deltaTime * deceleration * 3;
        }
        // Same for backwards       
        if(!backPressed && velocityZ < 0.0f){
            velocityZ += Time.deltaTime * deceleration * 3;
        }
    }

    void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity){

        
        // Reset velocityX
        if(!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f)){
            velocityX = 0.0f;
        }

        //lock forward
        if(forwardPressed && runPressed && velocityZ > currentMaxVelocity){
            velocityZ = currentMaxVelocity;
        // decelerate to walk speed after letting go of sprint
        } else if(forwardPressed && velocityZ > currentMaxVelocity){
            velocityZ -= Time.deltaTime * deceleration;
            // Round to the currentMaxVelocity if within offset
            if(velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05f)){
                velocityZ = currentMaxVelocity;
            }
        // Round to the currentMaxVelocity if within offset
        } else if(forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f)){
            velocityZ = currentMaxVelocity;
        }

        //lock left
        if(leftPressed && runPressed && velocityX < -currentMaxVelocity){
            velocityX = -currentMaxVelocity;
        // decelerate to max walk speed
        } else if(leftPressed && velocityX < -currentMaxVelocity){
            velocityX += Time.deltaTime * deceleration;
            // Round to the currentMaxVelocity if within offset
            if(velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f)){
                velocityX = -currentMaxVelocity;
            }
        // Round to the currentMaxVelocity if within offset
        } else if(leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f)){
            velocityX = -currentMaxVelocity;
        }

        //lock right
        if(rightPressed && runPressed && velocityX > currentMaxVelocity){
            velocityX = currentMaxVelocity;
        
        // decelerate to walk speed after letting go of sprint
        } else if(rightPressed && velocityX > currentMaxVelocity){
            velocityX -= Time.deltaTime * deceleration;
            // Round to the currentMaxVelocity if within offset
            if(velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05f)){
                velocityX = currentMaxVelocity;
            }
        
        // Round to the currentMaxVelocity if within offset
        } else if(rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f)){
            velocityX = currentMaxVelocity;
        }

        //Lock backward
        if(backPressed && runPressed && velocityZ < -currentMaxVelocity){
            velocityZ = -currentMaxVelocity;
        
        // decelerate to max walk speed
        } else if(backPressed && velocityZ < -currentMaxVelocity){
            velocityZ += Time.deltaTime * deceleration;
            // Round to the currentMaxVelocity if within offset
            if(velocityZ < -currentMaxVelocity && velocityZ > (-currentMaxVelocity - 0.05f)){
                velocityZ = -currentMaxVelocity;
            }
        
        // Round to the currentMaxVelocity if within offset
        } else if(backPressed && velocityZ > -currentMaxVelocity && velocityZ < (-currentMaxVelocity + 0.05f)){
            velocityZ = -currentMaxVelocity;
        }
    }

    // Update is called once per frame
    void Update(){
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);
        //Set current maxvelocity
        //Terniary operator: sets variable equal to the first if the run is true, else sets teh second option
        
        float currentMaxVelocity = runPressed ? maxRunV : maxWalkV;
        
        changeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        
        animator.SetFloat(VelocityZHash, velocityZ);
        animator.SetFloat(VelocityXHash, velocityX);

    }
}
