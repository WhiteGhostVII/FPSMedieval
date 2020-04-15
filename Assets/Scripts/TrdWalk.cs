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
    }
    public States state;
    public Animator anim;
    public Rigidbody rdb;
    private Vector3 move;
    public float movforce = 100;

    Vector3 direction;
    GameObject referenceObject;
    void Start()
    {
        StartCoroutine(Idle());
        referenceObject = Camera.main.GetComponent<TrdCam>().GetReferenceObject();
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
}
