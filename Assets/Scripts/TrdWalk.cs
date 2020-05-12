using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public enum States
    {
        idle,
        walk,
        jump,
        die,
        attack,
    }
    public States state;
    public Animator anim;
    public Rigidbody rdb;
    private Vector3 move;
    public float movforce = 100;

    Vector3 direction;
    public GameObject referenceObject;    
    void Awake()
    {
        StartCoroutine(Idle());
        //referenceObject = Camera.main.GetComponent<TrdCam>().GetReferenceObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = referenceObject.transform.TransformDirection(move);
        if (move.magnitude>0)
        {
            direction = move;
        }
        transform.forward = Vector3.Lerp(transform.forward,direction,Time.fixedDeltaTime*20);
        
        rdb.AddForce(move * (movforce/(rdb.velocity.magnitude + 1)));

        rdb.AddForce(-rdb.velocity * 250);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }
    }
    IEnumerator Idle()
    {
        state = States.idle;

        while (state == States.idle)
        {
            anim.SetFloat("Velocity", 0);
            if(rdb.velocity.magnitude>0.1f)
            {
                StartCoroutine(Walk());
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Walk()
    {
        state = States.walk;

        while (state == States.walk)
        {
            anim.SetFloat("Velocity", rdb.velocity.magnitude);
            if (rdb.velocity.magnitude < 0.1f)
            {
                StartCoroutine(Idle());
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Attack()
    {
        state = States.attack;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Idle());
        
    }

    IEnumerator Jump()
    {
        state = States.jump;
        rdb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        while (state == States.jump)
        {
            if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hit, 65279))
            {
                anim.SetFloat("GroundDistance", hit.distance);           
                if(hit.distance < 0.2f && rdb.velocity.y <= 0)
                {
                    StartCoroutine(Idle());
                }
            }
            else
            {
                anim.SetFloat("GroundDistance", 5);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
