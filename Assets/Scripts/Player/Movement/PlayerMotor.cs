using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    // Start is called before the first frame update

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded; 
    public float speed = 3f;
    public float walkSpeed = 3f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    private bool sprinting = false;

    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isBackwardsHash;
    int isJumpingHash;
    int isLeftHash;
    int isRightHash;
    int isBackLeftHash;
    int isBackRightHash;
    int isFrontLeftHash;
    int isFrontRightHash;

    // private bool crouching = false;
    // public float crouchTimer = 1;
    // private bool lerpCrouch = false;
    

    void Start() {
        controller = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();  
        isWalkingHash = Animator.StringToHash("isWalking");  
        isRunningHash = Animator.StringToHash("isRunning");
        isBackwardsHash = Animator.StringToHash("isBackwards");
        isLeftHash = Animator.StringToHash("isLeft");
        isRightHash = Animator.StringToHash("isRight");
        isJumpingHash = Animator.StringToHash("isJumping");

        isBackLeftHash = Animator.StringToHash("isBackLeft");
        isBackRightHash = Animator.StringToHash("isBackRight");
        isFrontLeftHash = Animator.StringToHash("isFrontLeft");
        isFrontRightHash = Animator.StringToHash("isFrontRight");
    }

    // Update is called once per frame
    void Update() {
        isGrounded = controller.isGrounded;


        bool forward = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);

        bool run = Input.GetKey("left shift");
        bool isRunning = animator.GetBool(isRunningHash);

        bool backward = Input.GetKey("s");
        bool isBackwards = animator.GetBool(isBackwardsHash);
        
        bool left = Input.GetKey("a");
        bool isLeft = animator.GetBool(isLeftHash);

        bool right = Input.GetKey("d");
        bool isRight = animator.GetBool(isRightHash);

        bool isBackLeft = animator.GetBool(isBackLeftHash);
        bool isBackRight = animator.GetBool(isBackRightHash);
        bool isFrontLeft = animator.GetBool(isFrontLeftHash);
        bool isFrontRight = animator.GetBool(isFrontRightHash);


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

        
        // Left and right: same principles
        if(!isLeft && left){
            animator.SetBool(isLeftHash, true);
        }

        if(isLeft && !left){
            animator.SetBool(isLeftHash, false);
        }

        if(!isRight && right){
            animator.SetBool(isRightHash, true);
        }

        if(isRight && !right){
            animator.SetBool(isRightHash, false);
        }

        // Diagonal movement torture
        if(!isBackLeft && (left && backward)){
            
            
            animator.SetBool(isBackLeftHash, true);
        }

        if(isBackLeft && (!left || !backward)){
            animator.SetBool(isBackLeftHash, false);
            
        }

        if(!isBackRight && (backward && right)){
            animator.SetBool(isBackRightHash, true);
            
        }

        if(isBackRight && (!right || !backward)){
            animator.SetBool(isBackRightHash, false);
        }

        if(!isFrontLeft && (left && forward)){
            animator.SetBool(isFrontLeftHash, true);
            
        }

        if(isFrontLeft && (!left || !forward)){
            animator.SetBool(isFrontLeftHash, false);
        }

        if(!isFrontRight && (forward && right)){
            animator.SetBool(isFrontRightHash, true);
            
        }

        if(isFrontRight && (!right || !forward)){
            animator.SetBool(isFrontRightHash, false);
        }




        // if not running but shift and w is pressed, then run
        if(!isRunning && forward && run){
            animator.SetBool(isRunningHash, true);
        }

        // if shift is released, or w, then stop
        if(isRunning && (!forward || !run)){
            animator.SetBool(isRunningHash, false);
        }





        // ** Unused crouch code **


        // if(lerpCrouch){
        //     crouchTimer += Time.deltaTime;
        //     float p = crouchTimer / 1;
        //     p *= p;
        //     if(crouching){
        //         speed = crouchSpeed;
        //         controller.height = Mathf.Lerp(controller.height, 1, p);
        //     } else {
        //         speed = walkSpeed;
        //         controller.height = Mathf.Lerp(controller.height, 2, p);
        //     }
        //     if(p > 1){
        //         lerpCrouch = false;
        //         crouchTimer = 0f;
        //     }
        // }

    }

    // public void Crouch(){
    //     //Switch states
    //     crouching = !crouching;  
    //     crouchTimer = 0;
    //     lerpCrouch = true;
    // }

    public void Sprint(){
        //Switch states
        sprinting = !sprinting;
        
        if(isGrounded){
            
            if(sprinting){
                speed = sprintSpeed;
            } else{
                speed = walkSpeed;
            }
        } else{
            // prevent speed from being locked to sprintSpeed
            speed = walkSpeed;
        }
    }

    //recieve the inputs for our InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input) { 
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); 
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
            animator.SetBool(isJumpingHash, false);
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump() { 
        animator.SetBool(isJumpingHash, true);
        if(isGrounded){ 
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}