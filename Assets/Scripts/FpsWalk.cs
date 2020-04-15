using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FpsWalk : MonoBehaviour
{
    public CharacterController chtr;
    Vector3 move, rot;
    PlayerControls controls;
    void Awake()
    {
        if(!chtr)
        chtr = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        controls = new PlayerControls();
        controls.Gameplay.Rotate.performed += ctx => MovHeadX();
    }

   
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        
        //captura de rotacao do corpo
        rot.y = Input.GetAxis("Mouse X");        
        //conversao de direcao local pra global 
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);
        MovHeadX();
       
    }
    void MovHeadX()
    {
        rot.y = Input.GetAxis("GamepadViewX");
        Vector3 globalmove = transform.TransformDirection(move);        
        transform.Rotate(rot);
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
