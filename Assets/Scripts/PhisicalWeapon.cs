using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
    }
}
