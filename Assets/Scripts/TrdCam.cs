using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 ajust;
    public Vector3 ajustlook;
    GameObject fakeObject;
    float zajust;
    void Awake()
    {
        zajust = -3;
        fakeObject = new GameObject();
        fakeObject.transform.rotation = player.transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public GameObject GetReferenceObject()
    {
        if (player != null)
        {
            return fakeObject;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            fakeObject.transform.position = Vector3.Lerp(fakeObject.transform.position,
                                              player.transform.position, Time.deltaTime * 10);

            Vector3 dirback = transform.position - (player.transform.position + ajustlook);
            float distancetohit = 10;

            //if (Physics.Raycast(player.transform.position + ajustlook, dirback, out RaycastHit hit, 10, 65279))
            //{
            //    distancetohit = hit.distance;
            //    Debug.DrawLine(player.transform.position + ajustlook, hit.point);
            //}

            Vector3 backvector = fakeObject.transform.forward * ajust.z;
            backvector = Vector3.ClampMagnitude(backvector, distancetohit);
            transform.position = fakeObject.transform.position +
                                 backvector +
                                 fakeObject.transform.up * ajust.y;
            transform.LookAt(player.transform.position + ajustlook);

            zajust = Mathf.Clamp(zajust + Input.mouseScrollDelta.y, -6, -1);
            ajust = new Vector3(0, ajust.y, zajust);
            fakeObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
            fakeObject.transform.Rotate(new Vector3(0, Input.GetAxis("GamepadViewX")* 2, 0));
        }
    }
}
