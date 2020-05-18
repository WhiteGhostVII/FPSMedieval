using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAController : MonoBehaviour
{
    public List<GameObject> ias;
    public bool over;
    public int index;
    public Text mortos;

    private int iaCount = 10;

    void Start()
    {
        GetAllIA();
        mortos.text = "Inimigos Eliminados: " + index;
    }

    // Update is called once per frame
    void Update()
    {
        VerifyIA();
        mortos.text = "Inimigos Eliminados: " + index;
    }

    void GetAllIA()
    {
        IAWalk[] temp = new IAWalk[iaCount];

        temp = GetComponentsInChildren<IAWalk>();

        for (int i = 0; i < temp.Length; i++)
            ias.Add(temp[i].gameObject);
    }

    void VerifyIA()
    {
        index = 0;
        for (int i = 0; i < ias.Count; i++)
        {
            if (ias[i] == null)
                index++;
        }

        if (index == iaCount)
        {
            over = true;
            Debug.Log("Voce Venceu!!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
        else
            over = false;
    }
}
