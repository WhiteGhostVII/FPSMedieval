using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativePostesFPS : MonoBehaviour
{
    // Start is called before the first frame update
    public static DesativePostesFPS Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesativePostesFps()
    {
        gameObject.SetActive(false);
    }
}
