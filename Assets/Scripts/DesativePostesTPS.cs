using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativePostesTPS : MonoBehaviour
{
    // Start is called before the first frame update
    public static DesativePostesTPS Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesativePostesTps()
    {
        gameObject.SetActive(false);
    }
}
