﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBomb : MonoBehaviour
{
    public GameObject target;
    Rigidbody rdb;
    public float bombForce = 1000;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.LookAt(target.transform);
        rdb.AddForce(transform.forward*50);

        if (Vector3.Distance(transform.position, target.transform.position) < 1)
        {
            Explode();
        }

    }


    void Explode()
    {
        GameObject explo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 3);
        print("Explodiu!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    if (!hit.rigidbody.CompareTag("Casas"))
                    {
                        hit.rigidbody.isKinematic = false;
                    }
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                    //hit.collider.gameObject.SendMessage("GetDamage", SendMessageOptions.DontRequireReceiver);
                    hit.collider.gameObject.SendMessage("GetDamageMissile", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
