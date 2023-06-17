using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour {

    public LayerMask interactable;

    Interactable interact;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactable)){
            Debug.Log(hit.collider.name);
            if(hit.collider.GetComponent<Interactable>() != null){
                if(interact == null || interact.ID != hit.collider.GetComponent<Interactable>().ID){
                    interact = hit.collider.GetComponent<Interactable>();
                    //Debug.Log("New");
                }
                if(Input.GetKeyDown(KeyCode.E)){
                    interact.onInteract.Invoke();
                }
            }
        }
    }
}
