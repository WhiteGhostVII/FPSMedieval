using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Text textArma;
    public GameObject[] projectilesPrefab;
    int indexWeapon;    
    public GameObject target;
    public GameObject laserpoint;    
    PlayerControls controls;
    public static PlayerShoot Instance;
    void Awake()
    {
        textArma.text = "Arma Atual: Sniper";
        controls = new PlayerControls();
        controls.Gameplay.Fire.performed += ctx => FireGamepad();
        //controls.Gameplay.Rotate.performed += ctx => MovHead();
        //controls.Gameplay.WeaponSelection.performed += ctx => WeaponSelectionGamepad();
        Instance = this;

    }
    void FireGamepad()
    {
        GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], transform.position + (transform.forward * 2),
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
        if (myprojectile.GetComponent<Shuriken>())
        {
            PlayAudio();
        }
    }
    void FireMouse()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //instancia o objeto e guarda a referencia
            GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], transform.position + (transform.forward * 2),
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
            if (myprojectile.GetComponent<Shuriken>())
            {
                PlayAudio();
            }
        }
    }    
    void MovHead()
    {
        float movx = Input.GetAxis("GamepadViewZ");
        transform.Rotate(new Vector3(-movx, 0, 0));
    }
        
    

    void Update()
    {
        //movimento de cabeca
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx, 0, 0));
        

        #region WEAPON SELECTION MOUSE
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
            textArma.text = "Arma Atual: RasenShuriken";
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            indexWeapon = 8;
            textArma.text = "Arma Atual: Black Hole";
        }
        #endregion

        
        MovHead();
        FireMouse();
        WeaponSelectionGamepad();
        //se aperta tiro instancia o prefab


        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
        
    }
    public void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }
    public void StopAudio()
    {
        GetComponent<AudioSource>().Stop();
    }
    void WeaponSelectionGamepad()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            indexWeapon++;
            if(indexWeapon == 0)
            {
                indexWeapon = 0;
                textArma.text = "Arma Atual: Sniper";
            }
            if (indexWeapon == 1)
            {
                indexWeapon = 1;
                textArma.text = "Arma Atual: Bomb";
            }
            if (indexWeapon == 2)
            {
                indexWeapon = 2;
                textArma.text = "Arma Atual: C4";
            }
            if (indexWeapon == 3)
            {
                indexWeapon = 3;
                textArma.text = "Arma Atual: Missile";
            }
            if (indexWeapon == 4)
            {
                indexWeapon = 4;
                textArma.text = "Arma Atual: Bubble";
            }
            if (indexWeapon == 5)
            {
                indexWeapon = 5;
                textArma.text = "Arma Atual: Tornado";
            }
            if (indexWeapon == 6)
            {
                indexWeapon = 6;
                textArma.text = "Arma Atual: Mine";
            }
            if (indexWeapon == 7)
            {
                indexWeapon = 7;
                textArma.text = "Arma Atual: RasenShuriken";
            }
            if (indexWeapon == 8)
            {
                indexWeapon = 8;
                textArma.text = "Arma Atual: Black Hole";
            }
            if(indexWeapon>8)
            {
                indexWeapon = 0;
                textArma.text = "Arma Atual: Sniper";
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            indexWeapon--;
            if (indexWeapon == 0)
            {
                indexWeapon = 0;
                textArma.text = "Arma Atual: Sniper";
            }
            if (indexWeapon == 1)
            {
                indexWeapon = 1;
                textArma.text = "Arma Atual: Bomb";
            }
            if (indexWeapon == 2)
            {
                indexWeapon = 2;
                textArma.text = "Arma Atual: C4";
            }
            if (indexWeapon == 3)
            {
                indexWeapon = 3;
                textArma.text = "Arma Atual: Missile";
            }
            if (indexWeapon == 4)
            {
                indexWeapon = 4;
                textArma.text = "Arma Atual: Bubble";
            }
            if (indexWeapon == 5)
            {
                indexWeapon = 5;
                textArma.text = "Arma Atual: Tornado";
            }
            if (indexWeapon == 6)
            {
                indexWeapon = 6;
                textArma.text = "Arma Atual: Mine";
            }
            if (indexWeapon == 7)
            {
                indexWeapon = 7;
                textArma.text = "Arma Atual: RasenShuriken";
            }
            if (indexWeapon == 8)
            {
                indexWeapon = 8;
                textArma.text = "Arma Atual: Black Hole";
            }
            if (indexWeapon < 0)
            {
                indexWeapon = 8;
                textArma.text = "Arma Atual: Black Hole";
            }
        }
    }

   

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
