using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSecundario : MonoBehaviour
{
    // Start is called before the first frame update   
    public static MenuSecundario Instance;
    public bool fpsapertado;
    public bool tpsapertado;
    void Start()
    {
        Instance = this;
        fpsapertado = false;
        tpsapertado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotaoVoltar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }
    public void BotaoFPS()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MenuEscolhaPlayer");
        fpsapertado = true;
        //ControlFPSPlayer.Instance.DesativarGameObjectTPS();
        //gameObject.SendMessage("DesativarGameObjectTPS", SendMessageOptions.DontRequireReceiver);
    }
    public void BotaoTPS()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MenuEscolhaPlayer");
        tpsapertado = true;
        //ControlTPSPlayer.Instance.DesativarGameObjectFPS();
        //gameObject.SendMessage("DesativarGameObjectFPS", SendMessageOptions.DontRequireReceiver);
    }
    
}
