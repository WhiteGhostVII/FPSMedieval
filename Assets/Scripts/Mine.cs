using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rdb;
    public float bombForce = 2000;

    
    void Start()
    {
        rdb = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        
    }

    


    //private void OnCollisionEnter(Collision collider)
    //{
    //    Grudar();         
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }


    void Explode()
    {
        print("Explodiu!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
            }
        }
    }
    //private void Grudar()
    //{
    //    print("Grudou!");
    //    rdb.isKinematic = true;
    //}
}
