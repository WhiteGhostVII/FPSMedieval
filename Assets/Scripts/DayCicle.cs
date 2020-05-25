using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCicle : MonoBehaviour
{
    // Start is called before the first frame update
    public float daytime;
    float lightdegrees = 0;
    public float timeScale = 360;
    public TimeSpan mytime;
    string mytimeHour;
    string mytimeMinute;
    string mytimeDay;
    public Light sun;
    Color fogcolor;
    public Gradient ambientGradient;
    public Text TimeTPS;
    public Text TimeFPS;
    public delegate void MorningCall();
    public delegate void NightCall();

    public MorningCall myMorningCall;
    public NightCall myNightCall;
    bool day = false;
    void Start()
    {
        fogcolor = RenderSettings.fogColor;
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if (mytime.Hours >= 0 && mytime.Hours < 6)
        {
            TimeTPS.text = "Hora da Madrugada: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;
            TimeFPS.text = "Hora da Madrugada: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;

        }
        else if (mytime.Hours >= 6 && mytime.Hours < 18)
        {
            TimeTPS.text = "Hora do Dia: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;
            TimeFPS.text = "Hora do Dia: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;
        }
        else if (mytime.Hours >= 18 && mytime.Hours < 24)
        {
            TimeTPS.text = "Hora da Noite: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;
            TimeFPS.text = "Hora da Noite: " + mytimeHour + ":" + mytimeMinute + "\nDia " + mytimeDay;
        }


        daytime += UnityEngine.Time.deltaTime * timeScale;
        mytime = TimeSpan.FromSeconds(daytime);
        mytimeDay = mytime.Days.ToString();
        mytimeHour = mytime.Hours.ToString();
        mytimeMinute = mytime.Minutes.ToString();
        //print(mytime.ToString());


        lightdegrees = 360 * (daytime / 86400);
        transform.rotation = Quaternion.Euler(lightdegrees - 90, 180, 0);
        float normalsun = Vector3.Dot(transform.forward, Vector3.down);
        sun.intensity = normalsun * 1.2f;
        RenderSettings.ambientLight = ambientGradient.Evaluate(normalsun + 0.4f);
        RenderSettings.fogColor = fogcolor * normalsun;
        if(normalsun > 0)
        {
            if(!day)
            {
                myMorningCall();
                day = true;
            }
        }
        else
        {
            if(day)
            {
                myNightCall();
                day = false;
            }
        }

    }
}
