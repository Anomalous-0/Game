using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    public Animator animator;


    public void ToggleBool(string boolname){
        animator.SetBool(boolname,!animator.GetBool(boolname));
    }

    public void PushButton(string name){
        animator.SetBool(name,!animator.GetBool(name));
        Invoke("ToggleBool", 2.0f);
    }


}
