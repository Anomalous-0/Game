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

    int isJumpingHash;
    Animator animator;

    PlayerAnimation playerAnimation;
    // private bool crouching = false;
    // public float crouchTimer = 1;
    // private bool lerpCrouch = false;
    

    void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("isJumping");  
    }

    // Update is called once per frame
    void Update() {
        bool space = Input.GetKey(KeyCode.Space);
        isGrounded = controller.isGrounded;
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