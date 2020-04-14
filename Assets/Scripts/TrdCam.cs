﻿using System.Collections;
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
    }
    public GameObject GetReferenceObject()
    {
        return fakeObject;
    }

    // Update is called once per frame
    void Update()
    {
        fakeObject.transform.position = Vector3.Lerp(fakeObject.transform.position,
                                          player.transform.position, Time.deltaTime * 10);
        
        transform.position = fakeObject.transform.position +
                             fakeObject.transform.forward * ajust.z +
                             fakeObject.transform.up * ajust.y;
        transform.LookAt(player.transform.position + ajustlook);

        zajust = Mathf.Clamp(zajust + Input.mouseScrollDelta.y, -6, -1);
        ajust = new Vector3(0, ajust.y, zajust);
        fakeObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        
    }
}
