using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    public Animator animator;


    public void ToggleBool(string boolname){
        animator.SetBool(boolname,!animator.GetBool(boolname));
    }

    public void SetTrue(string boolname){
        animator.SetBool(boolname, true);
    
        
    }


}
