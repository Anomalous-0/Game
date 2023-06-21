using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour {
    
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isBackwardsHash;
    int isJumpingHash;
    // int isLeftHash;
    // int isRightHash;
    // private PlayerMotor playerMotor;
   

    void Start() {
        animator = GetComponent<Animator>();  
        isWalkingHash = Animator.StringToHash("isWalking");  
        isRunningHash = Animator.StringToHash("isRunning");
        isBackwardsHash = Animator.StringToHash("isBackwards");
        // isLeftHash = Animator.StringToHash("isLeft");
        // isRightHash = Animator.StringToHash("isRight");
        isJumpingHash = Animator.StringToHash("isJumping");

    }

    // Update is called once per frame
    void Update() {
        bool forward = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);

        bool run = Input.GetKey("left shift");
        bool isRunning = animator.GetBool(isRunningHash);

        bool backward = Input.GetKey("s");
        bool isBackwards = animator.GetBool(isBackwardsHash);

        

        // bool left = Input.GetKey("a");
        // bool isLeft = animator.GetBool(isLeftHash);

        // bool right = Input.GetKey("d");
        // bool isRight = animator.GetBool(isRightHash);

        

        // if not walking and press w, walk
        if(!isWalking && forward){
            animator.SetBool(isWalkingHash, true);
        }

        // if walking but not pressing w, stop
        if(isWalking && !forward){
            animator.SetBool(isWalkingHash, false);
        } 


        // if not backwards and press s, walk
        if(!isBackwards && backward){
            animator.SetBool(isBackwardsHash, true);
        }

        // if backwards but not pressing s, stop
        if(isBackwards && !backward){
            animator.SetBool(isBackwardsHash, false);
        } 

        
        // // Left and right: same principles
        // if(!isLeft && left){
        //     animator.SetBool(isLeftHash, true);
        // }

        // if(isLeft && !left){
        //     animator.SetBool(isLeftHash, false);
        // }

        // if(!isRight && right){
        //     animator.SetBool(isRightHash, true);
        // }

        // if(isRight && !right){
        //     animator.SetBool(isRightHash, false);
        // }


        // if not running but shift and w is pressed, then run
        if(!isRunning && forward && run){
            animator.SetBool(isRunningHash, true);
        }

        // if shift is released, or w, then stop
        if(isRunning && (!forward || !run)){
            animator.SetBool(isRunningHash, false);
        }

     
        
    }
}
