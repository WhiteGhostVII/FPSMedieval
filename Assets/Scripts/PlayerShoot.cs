using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public Text textArma;
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    public GameObject target;
    public GameObject laserpoint;
    void Start()
    {
        textArma.text = "Arma Atual: Sniper";
    }
    void Update()
    {
        //movimento de cabeca
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx, 0, 0));

        if (Input.GetKey(KeyCode.Alpha1))
        {
            indexWeapon = 0;
            textArma.text = "Arma Atual: Sniper";
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            indexWeapon = 1;
            textArma.text = "Arma Atual: Bomb";
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            indexWeapon = 2;
            textArma.text = "Arma Atual: C4";
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            indexWeapon = 3;
            textArma.text = "Arma Atual: Missile";
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            indexWeapon = 4;
            textArma.text = "Arma Atual: Bubble";
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            indexWeapon = 5;
            textArma.text = "Arma Atual: Tornado";
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            indexWeapon = 6;
            textArma.text = "Arma Atual: Mine";
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            indexWeapon = 7;
            textArma.text = "Arma Atual: Shuriken";
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            indexWeapon = 8;
            textArma.text = "Arma Atual: Black Hole";
        }

        
        //se aperta tiro instancia o prefab
        if (Input.GetButtonDown("Fire1"))
        {
            //instancia o objeto e guarda a referencia
            GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], transform.position+(transform.forward*2),
            transform.rotation);

            if (!myprojectile.GetComponent<GuidedBomb>())
            {
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            }
            if (myprojectile.GetComponent<GuidedBomb>())
            {                
                myprojectile.GetComponent<GuidedBomb>().target = laserpoint;
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
            }        
            if (myprojectile.GetComponent<Bullet>())
            {
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100000);
            }
            if (myprojectile.GetComponent<Bubble>())
            {
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 50000);
            }
            if (myprojectile.GetComponent<Shuriken>())
            {
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 50000);
            }

            if (myprojectile.GetComponent<BlackHole>())
            {
                myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
            }
            



        }

        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }

    }


   

}
