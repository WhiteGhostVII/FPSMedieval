using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTPSPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static ControlTPSPlayer Instance;    
    void Start()
    {
        Instance = this;        
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuSecundario.Instance.tpsapertado)
        {
            if (gameObject != null)
            {
                DesativarGameObjectFPS();
            }
            DesativeIAsFps.Instance.DesativeIAFps();
            DesativePostesFPS.Instance.DesativePostesFps();
        }
    }
    public void AtivarGameObjectTPS()
    {
        gameObject.SetActive(true);       
    }
    public void AutoDesativeTPS()
    {
        gameObject.SetActive(false);
    }
    public void DesativarGameObjectFPS()
    {
        ControlFPSPlayer.Instance.AutoDesativeFPS();
    }   


}
