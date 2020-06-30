using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesativeSrines : MonoBehaviour
{
    // Start is called before the first frame update
    public static DesativeSrines Instance;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DesativeSrinesTPS()
    {
        gameObject.SetActive(false);
    }
    
}
