using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float bombForce = 1000;
    Rigidbody rdb;
    //public Material mat1;
    //public Material mat2;
    void Start()
    {
        rdb = GetComponent<Rigidbody>();
        //PlayAudio();
        Invoke("Explode", 3);
        Invoke("ObjDestroy", 11);
        //gameObject.GetComponent<MeshRenderer>().material = mat1;        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rdb.transform.Rotate(Vector3.up, 60);
    }
    void Explode()
    {
        //StopAudio();
        print("Explodiu!"); 
        for(int i = 0; i < 8; i++)
        {            
            
            Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);            
            //gameObject.GetComponent<MeshRenderer>().material = mat2;            

        }
        


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
        killEmAll = GameObject.FindGameObjectsWithTag("Cluster");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            Destroy(killEmAll[i].gameObject);
        }


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
