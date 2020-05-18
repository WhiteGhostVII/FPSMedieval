using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Awake()
    {
        
    }
    private void OnCollisionEnter (Collision collision)
    {
          
         collision.gameObject.SendMessage("DamageAxe", SendMessageOptions.DontRequireReceiver);
            
        
        
    }    

}
