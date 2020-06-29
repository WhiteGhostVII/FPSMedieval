using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFPSPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static ControlFPSPlayer Instance;    
    void Start()
    {
        Instance = this;        
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuSecundario.Instance.fpsapertado)
        {
            if (gameObject != null)
            {
                DesativarGameObjectTPS();
            }
            PhisicalWeapon.Instance.DesativeWeapon();
            Srine.Instance.DesativeSrine();
            DesativeIAS.Instance.DesativeIA();
            DesativePostesTPS.Instance.DesativePostesTps();
        }
    }
    public void AtivarGameObjectFPS()
    {
         gameObject.SetActive(true);        
    }
    public void AutoDesativeFPS()
    {
        gameObject.SetActive(false); 
    }
    public void DesativarGameObjectTPS()
    {
        ControlTPSPlayer.Instance.AutoDesativeTPS();        
    }

}
