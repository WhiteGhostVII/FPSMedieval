using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DamageControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int life = 100;
    //public int kills = 0;
    public IAWalk iawalk;
    private Vector3 pos;
    public GameObject obj;
    public SkinnedMeshRenderer mesh;
    public int hits;
    public TextMeshPro vida; 
    void Start()
    {
        vida.text = "" + life;
    }

    // Update is called once per frame
    void Update()
    {
        vida.text = "" + life;
        if (life <= 0)
        {
            iawalk.currentState = IAWalk.IaState.Dying;
            life = 0;
            Destroy(gameObject, 3);            
        }
        //if(hits>=3)
        //{
        //    iawalk.currentState = IAWalk.IaState.Dying;
        //    Destroy(gameObject, 3);
        //}
        
    }
    public void GetDamage()
    {        
        iawalk.currentState = IAWalk.IaState.Dying;
        life = 0;
        Destroy(gameObject, 3);
    }
    
    public void Damage()
    {
        StartCoroutine(Blink());        
        //Destroy(gameObject);
    }
    private void GetDamageC4()
    {
        life -= 50;
        iawalk.currentState = IAWalk.IaState.Damage;
    }
    private void GetDamageBomb()
    {
        life -= 50;
        iawalk.currentState = IAWalk.IaState.Damage;
    }
    private void GetDamageMissile()
    {
        iawalk.currentState = IAWalk.IaState.Damage;
        life -= 75;
    }
    private void GetDamageMine()
    {
        life -= 25;
        iawalk.currentState = IAWalk.IaState.Damage;
    }
    private void GetDamageShurikenIA()
    {
        life = 0;
    }
    IEnumerator Blink()
    {
        iawalk.currentState = IAWalk.IaState.Damage;
        life -= 30;
        //hits++;
        int blinks = 10;
        while (blinks > 0)
        {
            mesh.enabled = !mesh.enabled;
            yield return new WaitForSeconds(0.1f);
            blinks--;
        }
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
            life-=30;
            iawalk.currentState = IAWalk.IaState.Damage;
        }        
        if (collision.collider.CompareTag("C4"))
        {            
            //iawalk.currentState = IAWalk.IaState.Damage;            
        }
        if(collision.collider.CompareTag("Bubble"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().mass = 10;            
            GetComponent<Rigidbody>().useGravity = false;
            pos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);            
            iawalk.currentState = IAWalk.IaState.Stopped;
            transform.LookAt(pos);
            GetComponent<IAWalk>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
        if (collision.collider.CompareTag("Tornado"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; 
        }

    }
    
    private void BlackHoleExplode()
    {
        GetComponent<IAWalk>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().mass = 10;
        GetComponent<Rigidbody>().angularDrag = 0;
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<Rigidbody>().useGravity = true;
        life = 0;
        //Destroy(gameObject, 3);
    }
   
}
