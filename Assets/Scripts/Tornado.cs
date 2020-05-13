using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rdb;
    public float time;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        Invoke("ObjDestroy", time);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rdb.transform.Rotate(Vector3.up, 20);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            return;
            //other.transform.position = Vector3.Lerp(rdb.transform.position, other.transform.position,Time.fixedDeltaTime);

        }
        if (other.attachedRigidbody)
        {
            other.transform.parent = transform;            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("GetDamageTornado", SendMessageOptions.DontRequireReceiver);
        
    }
    void ObjDestroy()
    {        
        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 3);        
        Destroy(gameObject);
    }
}
