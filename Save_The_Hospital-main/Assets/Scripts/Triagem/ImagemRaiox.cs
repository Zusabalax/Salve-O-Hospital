using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ImagemRaiox : MonoBehaviour
{
    public Image imagem;
    public Sprite [] sprites;
    public Toggle gessoToggle, suturaToggle, peconhaToggle,raioxToggle,respiradorTogle;
    public Toggle anttetanicaTogle, gripeTogle, covidTogle, sarampoTogle, antrabicaTogle;
    public static bool gesso, sutura, peconha, raiox;
    public static int index;
    // Start is called before the first frame update
    void Start()
    {
        if(Data_Controler.raioxOk && (Data_Controler.pacinetGotratament==0 || Data_Controler.pacinetGotratament == 2 
            || Data_Controler.pacinetGotratament == 3 || Data_Controler.pacinetGotratament == 4))
        {
            raioxToggle.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.green;
        }
        else if((Data_Controler.raioxOk && (Data_Controler.pacinetGotratament != 0 || Data_Controler.pacinetGotratament != 2
            || Data_Controler.pacinetGotratament != 3 || Data_Controler.pacinetGotratament != 4)))
        {
            raioxToggle.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.red;
        }
        if (Data_Controler.pacinetGotratament == 0)
        {
            raioxToggle.isOn = true;
            respiradorTogle.isOn = true;    
           

        }

        if (Data_Controler.pacinetGotratament==1)
        {
            peconhaToggle.isOn = true;
          
        }

       

        if (Data_Controler.pacinetGotratament == 2)
        {
            raioxToggle.isOn = true;
           gripeTogle.isOn = true;

        }

        if (Data_Controler.pacinetGotratament==3)
        {
            gessoToggle.isOn = true;
            raioxToggle.isOn = true;
        }
        if (Data_Controler.pacinetGotratament==4)
        {
            suturaToggle.isOn = true;
            raioxToggle.isOn = true;

        }

        if (Data_Controler.pacinetGotratament == 5)
        {
            covidTogle.isOn = true;

        }
        if (Data_Controler.pacinetGotratament == 6)
        {
            sarampoTogle.isOn = true;

        }
        if (Data_Controler.pacinetGotratament == 7)
        {
            anttetanicaTogle.isOn = true;

        }
        if (Data_Controler.pacinetGotratament == 8)
        {
            antrabicaTogle.isOn = true;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        imagem.sprite = sprites[index]; 
        
    }
}
