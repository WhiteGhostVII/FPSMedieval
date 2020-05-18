using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public static PhisicalWeapon Instance;
    void Awake()
    {
        Instance = this;
    }    
    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);

    }
    public void DesativeWeapon()
    {
        gameObject.SetActive(false);
    }
}
