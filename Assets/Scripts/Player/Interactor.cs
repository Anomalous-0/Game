using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour {

    public LayerMask interactable;

    UnityEvent onInteract;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactable)){
            Debug.Log(hit.collider.name);
            if(hit.collider.GetComponent<Interactable>() != null){
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if(Input.GetKeyDown(KeyCode.E)){
                    onInteract.Invoke();
                }
            }
        }
    }
}
