using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EstaçoesConrler : MonoBehaviour
{
 
  
    public float time, timetochange, maxluz,minluz;
    public int seasonFlag;
    public Light2D luzGlobal;
   
    public  float horas, acressimo;

    bool diacontroler;
    // Start is called before the first frame update
    void Start()
    {
        horas = 0.8f;
        minluz = 0.3f;
        maxluz = 0.8f;
        time = PlayerPrefs.GetFloat("time");

        if(PlayerPrefs.GetInt("seasonFlag")==0)
        {
            seasonFlag = 1;
        }
        else
        {
            seasonFlag = PlayerPrefs.GetInt("seasonFlag");
        }
       


        //  Data_Controler.pacinetGotratament = -1;


       
        StartCoroutine(LupdeLuz());


    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        SeanonControler();
    }
    void LightControler()
    {
       
        if (horas > maxluz)
        {
            diacontroler = true;

        }
        else if (horas < minluz)
        {
            diacontroler = false;

        }
        if (diacontroler)
        {
            horas -= acressimo;
          //  luzGlobal.intensity =horas ;



        }
        else
        {
          //  luzGlobal.intensity += acressimo / 3.5f;

            horas += 0.01f;

        }
        //switch (seasonFlag)
        //{
        //    case 1:

        //        luzGlobal.color = new Color(luzGlobal.intensity, 1, 1, 1);


        //        break;
        //    case 2:
        //        luzGlobal.color = new Color(1, 1, 1, 1);
        //        break;
        //    case 3:
        //        luzGlobal.color = new Color(1, 1, luzGlobal.intensity, 1);

        //        break;
        //    case 4:

        //        luzGlobal.color = new Color(1, luzGlobal.intensity, luzGlobal.intensity, 1);
        //        break;

        //}



    }


    void SeanonControler()
    {
        time += Time.deltaTime;
        PlayerPrefs.SetFloat("time", time);
        if (time >= timetochange)
        {
            seasonFlag++;
            PlayerPrefs.SetInt("seasonFlag", seasonFlag);
            if (seasonFlag >= 5)
            {
                seasonFlag = 1;
            }
            time = 0;
        }

        PlayerPrefs.Save(); 
       
    }
    public IEnumerator LupdeLuz()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            LightControler();

        }

    }
}
