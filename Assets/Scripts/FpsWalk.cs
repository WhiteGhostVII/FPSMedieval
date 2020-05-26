using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FpsWalk : MonoBehaviour
{
    public CharacterController chtr;
    Vector3 move, rot;
    PlayerControls controls;
    public int life;
    public MeshRenderer mesh;
    public Text vida;
    public Rigidbody rdb;
    void Awake()
    {
        if(!chtr)
        chtr = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        controls = new PlayerControls();
        controls.Gameplay.Rotate.performed += ctx => MovHeadX();
        life = 200;
        vida.text = "Vida: " + life;
    }

   
    void Update()
    {
        vida.text = "Vida: " + life;
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        
        //captura de rotacao do corpo
        rot.y = Input.GetAxis("Mouse X");        
        //conversao de direcao local pra global 
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);
        MovHeadX();
        if(life <= 0)
        {
            print("Morreu!!!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
       
    }
    void MovHeadX()
    {
        rot.y = Input.GetAxis("GamepadViewX");
        Vector3 globalmove = transform.TransformDirection(move);        
        transform.Rotate(rot);
    }
    //public void DamageAxe()
    //{
    //    StartCoroutine(Blink());
    //    life--;
    //}
    public void DamageAxe()
    {
        StartCoroutine(Blink());
        life--;
    }
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
    private void GetDamageBomb()
    {
        life -= 50;        
    }
    private void GetDamageC4()
    {
        life -= 50;
    }
    private void GetDamageMissile()
    {
        life -= 100;
    }
    private void GetDamageTornado()
    {
        life -= 75;
    }
    private void GetDamageMine()
    {
        life -= 25;
    }
    private void GetDamageShuriken()
    {
        life -= 75;
    }
    private void GetDamageBlackHole()
    {
        life -= 150;
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
