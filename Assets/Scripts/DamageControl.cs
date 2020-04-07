using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifes = 3;
    public IAWalk iawalk;
    private Vector3 pos;
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage()
    {
        iawalk.currentState = IAWalk.IaState.Dying;
        Destroy(gameObject, 3);
    }    
        
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Shuriken"))
        //{
        //    lifes--;
        //    iawalk.currentState = IAWalk.IaState.Damage;
        //}
        
        if (collision.collider.CompareTag("Sniper"))
        {
            lifes--;
            iawalk.currentState = IAWalk.IaState.Damage;
        }
        if(collision.collider.CompareTag("C4"))
        {
            iawalk.currentState = IAWalk.IaState.Damage;            
        }
        if(collision.collider.CompareTag("Bubble"))
        {
            iawalk.currentState = IAWalk.IaState.Stopped;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().mass = 10;            
            GetComponent<Rigidbody>().useGravity = false;
            pos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            transform.LookAt(pos);
            GetComponent<IAWalk>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
        if(lifes < 0)
        {
            iawalk.currentState = IAWalk.IaState.Dying;
            Destroy(gameObject, 3);            
        }

    }
    private void BlackHoleExplode()
    {
        GetComponent<Rigidbody>().mass = 10;
        GetComponent<Rigidbody>().angularDrag = 0;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<IAWalk>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;        
        Destroy(gameObject, 3);
    }
   
}
