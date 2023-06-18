using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactor : MonoBehaviour {

    public LayerMask interactable;
    public Image interactIcon;
    private PlayerUI playerUI;
    //private bool isHitting = false;

    Interactable interact;
    // Start is called before the first frame update
    void Start() {
        playerUI = GetComponent<PlayerUI>();
    }


    // Update is called once per frame
    void Update() {
        //playerUI.UpdateText(string.Empty);
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactable)){
            // If touches interactable layer, then show icon
            interactIcon.enabled = true;
            //Debug.Log(hit.collider.name);
            if(hit.collider.GetComponent<Interactable>() != null){
                if(interact == null || interact.ID != hit.collider.GetComponent<Interactable>().ID){    
                    
                    interact = hit.collider.GetComponent<Interactable>();
                    //playerUI.UpdateText(interact.promptMessage);
                    //Debug.Log("New");
                } 
                if(Input.GetKeyDown(KeyCode.E)){
                    interact.onInteract.Invoke();
                }
            }
        } else{
            // If not touching layer, disable icon
           interactIcon.enabled = false;
        }
    }
}
