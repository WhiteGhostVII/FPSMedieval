using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour
{
    // Start is called before the first frame update
    public Light lamp;
    public MeshRenderer lampMat;
    void Start()
    {
        DayCicle dayscript = GameObject.FindObjectOfType<DayCicle>();
        dayscript.myNightCall += TurnOn;
        dayscript.myMorningCall += TurnOff;
    }
    public void TurnOn()
    {
        lamp.enabled = true;
        lampMat.materials[1].EnableKeyword("_EMISSION");
    }
    public void TurnOff()
    {
        lamp.enabled = false;
        lampMat.materials[1].DisableKeyword("_EMISSION");
    }
}
