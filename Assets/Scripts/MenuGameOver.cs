﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameOver : MonoBehaviour
{
    // Start is called before the first frame update        
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotaoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");   
       
    }
    
    
}
