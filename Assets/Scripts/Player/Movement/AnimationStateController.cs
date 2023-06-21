using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour {
    
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    private PlayerMotor playerMotor;
   

    void Start() {
        animator = GetComponent<Animator>();  
        isWalkingHash = Animator.StringToHash("isWalking");  
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update() {
        bool forward = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);

        bool run = Input.GetKey("left shift");
        bool isRunning = animator.GetBool(isRunningHash);

        if(!isWalking && forward){
            animator.SetBool(isWalkingHash, true);
        }

        if(isWalking && !forward){
            animator.SetBool(isWalkingHash, false);
        } 

        if(!isRunning && forward && run){
            animator.SetBool(isRunningHash, true);
        }

        if(isRunning && (!forward || !run)){
            animator.SetBool(isRunningHash, false);
        }

     
        
    }
}
