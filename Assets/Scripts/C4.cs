using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    Rigidbody rdb;
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
        
    }
    void Explode()
    {
        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 3);
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                }
            }
        }        
    }
}
