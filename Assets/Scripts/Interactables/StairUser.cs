using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUser : Interactable {
    
   [SerializeField] 
   private GameObject stairs;
   private bool stairsUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact(){
       stairsUp = !stairsUp;
       stairs.GetComponent<Animator>().SetBool("IsUp", stairsUp);
    }
}
