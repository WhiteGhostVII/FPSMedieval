using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadControl : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Fire.performed += ctx => Fire();
    }
    void Fire()
    {

    }
}
