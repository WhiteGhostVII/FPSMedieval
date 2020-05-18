﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float bombForce = 1000;
    Rigidbody rdb;    
    //private Shuriken shu;    
    void Start()
    {        
        rdb = GetComponent<Rigidbody>();        
        Invoke("Explode", 3);        
        Invoke("ObjDestroy", 11);        
        //gameObject.GetComponent<MeshRenderer>().material = mat1;    
        //PlayAudio();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rdb.transform.Rotate(Vector3.up, 60);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Inimigo"))
        {
            collision.collider.gameObject.SendMessage("GetDamageShurikenIA", SendMessageOptions.DontRequireReceiver);
        }
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.SendMessage("GetDamageShuriken", SendMessageOptions.DontRequireReceiver);
        }



    }
    
    void Explode()
    {
        //StopAudio();
                
        print("Explodiu!"); 
        for(int i = 0; i < 5; i++)
        {        
            Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
        }
        
        //Instantiate(gameObject, gameObject.transform.position + Vector3.forward, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.left, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.right, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);



        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
        //gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);            
        //gameObject.GetComponent<Material>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);

        //Instantiate(gameObject, gameObject.transform.position + Vector3.forward, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.left, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.right, gameObject.transform.rotation);
        //Instantiate(gameObject, gameObject.transform.position + Vector3.back, gameObject.transform.rotation);

    }
    void ObjDestroy()
    {
        GameObject[] killEmAll;
        killEmAll = GameObject.FindGameObjectsWithTag("Shuriken");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            Destroy(killEmAll[i].gameObject);
        }
        PlayerShoot.Instance.StopAudio();

    }
    //void PlayAudio()
    //{
    //    GetComponent<AudioSource>().Play();
    //}
    //void StopAudio()
    //{
    //    GetComponent<AudioSource>().Stop();        
    //}
}
