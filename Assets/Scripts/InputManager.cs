using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    // Start is called before the first frame update
    
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake() {

        //Instantiating things
        playerInput = new PlayerInput();
        onFoot =  playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>(); 
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => motor.Jump();

        //onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate() {
       //Tell the playermotor to move using the value from our movement action
       motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate(){
        //Tells the playermotor to look using the value from our looking action
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}