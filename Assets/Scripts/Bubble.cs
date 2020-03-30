using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 20);
    }
    private void OnCollisionEnter(Collision collision)
    {        
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 1, Vector3.up, 1);

        if (hits.Length > 0)
        {
            
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.useGravity = false;
   
                }              
          
            }
        }
    }
    


}


