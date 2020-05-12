using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotaoJogar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuEscolhaPlayer");
    }
    public void BotaoInstrucoes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInstrucoes");
    }
    public void BotaoSair()
    {
        Application.Quit();
    }
}
