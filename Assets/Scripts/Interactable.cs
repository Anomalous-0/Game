using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    
    //Add or remove an InteractionEvent component to this game object
    public bool useEvents;
    [SerializeField]
    public string message;


    public virtual string OnLook(){
        return message;
    }
    
    //Called from player
    public void BaseInteract() {
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact(); 
    }

    protected virtual void Interact() {
        //template function to be overridden by our subclasses

    }
}