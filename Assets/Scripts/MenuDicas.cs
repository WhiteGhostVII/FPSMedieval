using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDicas : MonoBehaviour
{
    // Start is called before the first frame update
    public void BotaoVoltar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInstrucoes");
    }
}
