using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativeIAsFps : MonoBehaviour
{
    // Start is called before the first frame update
    public static DesativeIAsFps Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesativeIAFps()
    {
        gameObject.SetActive(false);
    }

}
