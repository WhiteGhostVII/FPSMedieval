using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rdb;
    public float bombForce = -5000;
    public GameObject explosionPrefab;
    void Start()
    {
        rdb = GetComponent<Rigidbody>();        
        Invoke("Implode", 2);
        Invoke("ObjDestroy", 2);
    }

    // Update is called once per frame
    void Update()
    {
        rdb.AddTorque(transform.localRotation.eulerAngles);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Grudou");
        rdb.isKinematic = true;
        if (collision.collider.attachedRigidbody)
        {
            transform.parent = collision.collider.transform;
        }
    }
    void Implode()
    {
        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 3);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 1000000, Vector3.up, 10);
        
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody) 
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 100000);
                    hit.collider.gameObject.SendMessage("BlackHoleExplode", SendMessageOptions.DontRequireReceiver);
                    //Objetos grudarem na posição do black hole
                    //hit.rigidbody.transform.LookAt(rdb.transform.position,Vector3.up*1000);  
                    //hit.transform.position = rdb.position;
                    //hit.rigidbody.isKinematic = true;
                }
            }
        }
        
    }
    
    void ObjDestroy()
    {
        Destroy(gameObject);        
    }
    
}
