using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    // Start is called before the first frame update
    public float daytime;
    float lightdegrees = 0;
    public float timeScale = 1;
    public TimeSpan mytime;
    public Light sun;
    Color fogcolor;
    public Gradient ambientGradient;
    void Start()
    {
        fogcolor = RenderSettings.fogColor;
    }

    // Update is called once per frame
    void Update()
    {
        daytime += Time.deltaTime * timeScale;
        mytime = TimeSpan.FromSeconds(daytime);
        print(mytime.ToString());


        lightdegrees = 360 * (daytime / 86400);
        transform.rotation = Quaternion.Euler(lightdegrees - 90, 180, 0);
        float normalsun = Vector3.Dot(transform.forward, Vector3.down);
        sun.intensity = normalsun * 1.2f;
        RenderSettings.ambientLight = ambientGradient.Evaluate(normalsun + 0.4f);
        RenderSettings.fogColor = fogcolor * normalsun;
    }
}
