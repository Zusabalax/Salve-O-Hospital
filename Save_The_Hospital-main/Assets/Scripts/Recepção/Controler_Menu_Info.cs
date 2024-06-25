using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Controler_Menu_Info : MonoBehaviour
{
    public TextMeshProUGUI season,numberLost;
    public GameObject winter, sumer, autunm, spring,sky;
    public float time,timetochange;
    public int seasonFlag;
    public SpriteRenderer [] bonecosContagem;

    public Light2D[] luzLampada;
 
    bool diacontroler;
    public float acressimo, maxLuz, minLuz, horas;
    // Start is called before the first frame update
    void Start()
    {

        seasonFlag = PlayerPrefs.GetInt("seasonFlag");
        time = PlayerPrefs.GetFloat("time");

        //  Data_Controler.pacinetGotratament = -1;


      
        StartCoroutine(LupdeLuz());
        switch (Data_Controler.pacientsLost)
        {
            case 0:

                bonecosContagem[0].color = Color.black;
                bonecosContagem[1].color = Color.black;
                bonecosContagem[2].color = Color.black;
                bonecosContagem[3].color = Color.black;
                bonecosContagem[4].color = Color.black;
                break;

            case 1:

                bonecosContagem[0].color = Color.black;
                bonecosContagem[1].color = Color.black;
                bonecosContagem[2].color = Color.black;
                bonecosContagem[3].color = Color.black;
                bonecosContagem[4].color = Color.white;
                break;

            case 2:
                bonecosContagem[0].color = Color.black;
                bonecosContagem[1].color = Color.black;
                bonecosContagem[2].color = Color.black;
                bonecosContagem[3].color = Color.white;
                bonecosContagem[4].color = Color.white;

                break;

            case 3:
                bonecosContagem[0].color = Color.black;
                bonecosContagem[1].color = Color.black;
                bonecosContagem[2].color = Color.white;
                bonecosContagem[3].color = Color.white;
                bonecosContagem[4].color = Color.white;
                break;

            case 4:
                bonecosContagem[0].color = Color.black;
                bonecosContagem[1].color = Color.white;
                bonecosContagem[2].color = Color.white;
                bonecosContagem[3].color = Color.white;
                bonecosContagem[4].color = Color.white;
                break;


            case 5:
                bonecosContagem[0].color = Color.white;
                bonecosContagem[1].color = Color.white;
                bonecosContagem[2].color = Color.white;
                bonecosContagem[3].color = Color.white;
                bonecosContagem[4].color = Color.white;
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {


      
     //   numberLost.text=Data_Controler.pacientsLost.ToString();
    


    }
    private void FixedUpdate()
    {
        SeanonControler();
    }
    void LightControler()
    {
      
        if(horas>maxLuz)
        {
           diacontroler = true;
           
        }
        else if(horas<minLuz) 
        {
           diacontroler=false;

        }
        if(diacontroler)
        {
            horas -= acressimo;
           

           

        }
        else
        {
            

            horas += acressimo;
         
        }
        sky.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, horas+0.5f);
        foreach  (Light2D luz in luzLampada)
        {
            //luz.intensity = horas;
        }


    }

       
    void SeanonControler()
    {
        time += Time.deltaTime;
        if (time >= timetochange)
        {
            seasonFlag++;
            if (seasonFlag == 5)
            {
                seasonFlag = 1;
            }
            time = 0;
        }
        switch (seasonFlag) 
        {
            case 1:
             

                Data_Controler.currentSeason = 0;
                season.text = "INVERNO";
              
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(false);
                winter.SetActive(true);
               

                break;
            case 2:
                Data_Controler.currentSeason = 1;
                season.text = "PRIMAVERA";
              
                winter.SetActive(false);
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(true);
               
                break;
            case 3:
                Data_Controler.currentSeason = 2;
                season.text = "VERÃO";
             

                autunm.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                sumer.SetActive(true);
               
                break;
            case 4:
                Data_Controler.currentSeason = 3;
                season.text = "OUTONO";
               
                sumer.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                autunm.SetActive(true);
               

                break;

        }
    }
    public IEnumerator LupdeLuz()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1) ;
            LightControler();
           
        }
        
    }
}
