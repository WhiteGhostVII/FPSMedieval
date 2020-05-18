using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    public Rigidbody rdb;
    public float bombForce = 1000;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        Invoke("Explode", 3);
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
    public void Explode()
    {
        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 3);
        print("Explodiu!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 5);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    if(!hit.rigidbody.CompareTag("Casas"))
                    {
                        hit.rigidbody.isKinematic = false;
                    }                    
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 5);
                    //hit.collider.gameObject.SendMessage("GetDamage", SendMessageOptions.DontRequireReceiver);
                    hit.collider.gameObject.SendMessage("GetDamageC4", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        
    }
}
