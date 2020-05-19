using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bombForce = 0;
    void Start()
    {
        GetComponent<AudioSource>().Play();
        Invoke("Explode", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Explode()
    {
        Destroy(gameObject);        
    }    
}
