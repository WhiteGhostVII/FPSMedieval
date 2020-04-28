using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer render;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage()
    {
        StartCoroutine(Blink());
        //Destroy(gameObject);
    }
    IEnumerator Blink()
    {
        int blinks = 10;
        while(blinks > 0)
        {
            render.enabled = !render.enabled;
            yield return new WaitForSeconds(0.1f);
            blinks--;
        }
    }
}
