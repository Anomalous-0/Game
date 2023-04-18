using UnityEditor;

[CustomEditor(typeof(Interactable), true)] 
public class InteractableEditor : Editor {
    public override void OnInspectorGUI(){
        Interactable interactable = (Interactable)target;
        base.OnInspectorGUI();
        if(interactable.useEvents){
                //we are using events. add the component
            if(interactable.GetComponent<InteractionEvent>() == null){
                    interactable.gameObject.AddComponent<InteractionEvent>();
            }
        } else{
                // remove the component if not using the event
            if(interactable.GetComponent<InteractionEvent>() != null){
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }
    }
}
