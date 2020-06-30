using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFPS : MonoBehaviour
{
    // Start is called before the first frame update    
    void Awake()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("VoidKillFPS", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("VoidKillFPS", SendMessageOptions.DontRequireReceiver);
    }

}
