using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IAController : MonoBehaviour
{
    public List<GameObject> ias;
    public bool over;
    public int index;
    public Text mortos;
    public bool killsloaded;

    private int iaCount = 10;

    void Start()
    {
        killsloaded = false;
        index = CommomStatus.iakilled;
        GetAllIA();
        VerifyIAKilled();
        mortos.text = "Inimigos Eliminados: " + index;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (CommomStatus.lastPosition.magnitude>1)
            {
                index = CommomStatus.iakilled;
                print(CommomStatus.iakilled);
                killsloaded = true;
            }
            
        }        
    }
    


    // Update is called once per frame
    void Update()
    {   
        if(killsloaded == false)
        {
            VerifyIA();
        }
        VerifyIAKilled();
        mortos.text = "Inimigos Eliminados: " + CommomStatus.iakilled;        
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
            {
                index++;
                CommomStatus.iakilled = index;                
            }
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
    void VerifyIAKilled()
    {
        if(killsloaded)
        {
            CommomStatus.iakilled = index;

            for (int i = 0; i < ias.Count; i++)
            {
                if (ias[i] == null)
                {
                    //index++;
                    CommomStatus.iakilled++;
                }
            }

            if (CommomStatus.iakilled == iaCount)
            {
                over = true;
                Debug.Log("Voce Venceu!!");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
            }
            else
                over = false;
        }
    }
}
