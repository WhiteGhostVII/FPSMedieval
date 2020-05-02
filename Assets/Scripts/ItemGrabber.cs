using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform handposition;
    public GameObject weaponOnHand;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WeaponDroped"))
        {
            if(weaponOnHand)
            {
                weaponOnHand.transform.parent = null;
                weaponOnHand.GetComponent<Rigidbody>().isKinematic = false;
                weaponOnHand.transform.Translate(-transform.up);
                weaponOnHand.layer = 0;                
            }            
            weaponOnHand = other.gameObject;
            other.transform.parent = handposition;
            other.transform.localPosition = Vector3.zero;
            weaponOnHand.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.localRotation = Quaternion.identity;
            other.transform.gameObject.layer = transform.gameObject.layer;            
            
        }
    }
}
