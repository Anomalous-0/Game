using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour {
    
    private Camera cam;
    [SerializeField]
    private float distance = 3f; 
    // Start is called before the first frame update
    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private InputManager inputManager;

    void Start() {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update() {
        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // stores collision info
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.message);
                if(inputManager.onFoot.Interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
    }
}