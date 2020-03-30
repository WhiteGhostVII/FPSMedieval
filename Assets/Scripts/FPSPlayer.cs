using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    Vector3 playeraxis;
    public CharacterController cctrl;    
    public GameObject head;
    public GameObject target;
    public GameObject laserpoint;
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playeraxis = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        transform.TransformDirection(playeraxis);
        cctrl.SimpleMove(transform.TransformDirection(playeraxis*5));
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"),0));
        head.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0));

        if (Input.GetKey(KeyCode.Alpha1)) indexWeapon = 0;
        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;
        if (Input.GetKey(KeyCode.Alpha3)) indexWeapon = 2;
        if (Input.GetKey(KeyCode.Alpha4)) indexWeapon = 3;
        if (Input.GetKey(KeyCode.Alpha5)) indexWeapon = 4;
        if (Input.GetKey(KeyCode.Alpha6)) indexWeapon = 5;
        if (Input.GetKey(KeyCode.Alpha7)) indexWeapon = 6;
        if (Input.GetKey(KeyCode.Alpha8)) indexWeapon = 7;


        if (Input.GetButtonDown("Fire1")) 
        {
            GameObject currentball = Instantiate(projectilesPrefab[indexWeapon], head.transform.position + head.transform.forward, Quaternion.identity);

            if (currentball.GetComponent<GuidedBomb>())
            {
                currentball.GetComponent<GuidedBomb>().target = laserpoint;
                
            }

            currentball.GetComponent<Rigidbody>().AddForce(head.transform.forward * 1000);
            

        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
    }
}
