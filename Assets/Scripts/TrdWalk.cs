using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public float jumpforce = 1000;
    float jumptime = 0.5f;
    public bool ikActive;
    public int life = 150;
    public SkinnedMeshRenderer mesh;
    public static TrdWalk Instance;
    public Text vida;    

    Vector3 direction;
    GameObject referenceObject;    
    void Start()
    {
        CommomStatus.currentlife = life;
        StartCoroutine(Idle());
        Instance = this;
        vida.text = "Vida: " + life;
        //referenceObject = Camera.main.GetComponent<TrdCam>().GetReferenceObject();
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if(CommomStatus.lastPosition.magnitude>1)
            {
                transform.position = CommomStatus.lastPosition;                
            }
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vida.text = "Vida: " + life;
        referenceObject = Camera.main.GetComponent<TrdCam>().GetReferenceObject();
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = referenceObject.transform.TransformDirection(move);
        if (move.magnitude>0)
        {
            direction = move;
        }
        transform.forward = Vector3.Lerp(transform.forward,direction,Time.fixedDeltaTime*20);
        
        rdb.AddForce(move * (movforce/(rdb.velocity.magnitude + 1)));

        rdb.AddForce(-rdb.velocity.x * 250, rdb.velocity.y * 2, -rdb.velocity.z * 250);

        //Vector3 velocityWoY = new Vector3(rdb.velocity.x, 0, rdb.velocity.z);
        //rdb.AddForce(-velocityWoY * 500);

        if (Physics.Raycast(transform.position + Vector3.up*.5f, Vector3.down, out RaycastHit hit, 65279))
        {
            anim.SetFloat("GroundDistance", hit.distance);
        }
        if(life <= 0)
        {
            //Destroy(gameObject, 3);
            CommomStatus.lastPosition = Vector3.zero;
            //IAController.Instance.mortos.text = "Inimigos Eliminados: " + IAController.Instance.index;
            //IAController.Instance.killsloaded = false;
            //CommomStatus.iakilled = 0;
            //IAController.Instance.index = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
    private void Update()
    {
        CommomStatus.currentlife = life;        
        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
        if(Gamepad.all.Count > 0)
        {
            if (Gamepad.current.rightTrigger.isPressed)
            {
                StartCoroutine(Attack());
            }
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            jumptime = 0;
        }
    }    
    //void MovHeadX()
    //{
    //    direction.y = Input.GetAxis("GamepadViewX");
    //    Vector3 globalmove = transform.TransformDirection(move);
    //    transform.Rotate(direction);
    //}
    public void DamageAxe()
    {
        StartCoroutine(Blink());
        life--;
        print("Player Hitted");
    }
    //public void DamageAxeTPS()
    //{
    //    StartCoroutine(Blink());
    //    life--;
    //    print("Player Hitted");
    //}
    IEnumerator Blink()
    {
        
        int blinks = 10;
        while (blinks > 0)
        {
            mesh.enabled = !mesh.enabled;
            yield return new WaitForSeconds(0.1f);
            blinks--;
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
        jumptime = 0.5f;
        if (Physics.Raycast(transform.position + Vector3.up * .5f, Vector3.down, out RaycastHit hit, 65279))
        {
            if(hit.distance > 0.6f)
            {
                StartCoroutine(Idle());
            }
        }
            //rdb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        while (state == States.jump)
        {
            rdb.AddForce(Vector3.up * jumpforce * jumptime);
            jumptime -= Time.fixedDeltaTime;
            //rdb.angularDrag = 0;
            //rdb.drag = 0;

            if(jumptime < 0)
            {
                StartCoroutine(Idle());
            }
            //anim.SetFloat("GroundDistance", 3); 
            


            //if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hit, 65279))
            //{
            //    if(hit.distance < 0.2f && rdb.velocity.y <= 0)
            //    {
            //        StartCoroutine(Idle());
            //    }
            //}
            //else
            //{
            //    anim.SetFloat("GroundDistance", 5);
            //}
           yield return new WaitForFixedUpdate();
        }
        
     
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if(ikActive)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out RaycastHit hit, 10, 65279))
            {
                anim.SetIKPosition(AvatarIKGoal.LeftHand, hit.point);
            }
        }
    }
}
