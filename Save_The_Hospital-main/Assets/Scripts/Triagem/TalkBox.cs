using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour
{
    // Start is called before the first frame update
    [TextAreaAttribute] 
    public string[] talks, talkEnfermeira;
    //  public string [] ;
    public TextMeshProUGUI talkBox, tableTolk;
    public float textSpeed;
    public Sprite[] spritesRostos;
    public Sprite rostoEnfermeira;
    public GameObject rostos;
    public TextMeshProUGUI tableTemperatura, tablePressao,batimentos;
    public GameObject camtriagem, camatendimento,caixaDeFala,ficha,ficha2;
   
   

    


    void Start()
    {
        //Falas.indexFala = 4;
        Data_Controler.recepOK = true;
        if (Data_Controler.historicoOk)
        {
            ficha2.SetActive(true);
            ficha.SetActive(false);
        }

        //Data_Controler.falasEnfermeira = 0;
        if (Data_Controler.falasEnfermeira==0)
        {
           
            StartCoroutine(TalkToBoard(Data_Controler.pacinetGotratament));
        }
        else if(Data_Controler.falasEnfermeira>=6) 
        {
           
            StartCoroutine(FalaFinal());
            tableTemperatura.text = Data_Controler.temperatura.ToString() + "ºC";
            tablePressao.text = Data_Controler.pressao;
            batimentos.text = Data_Controler.batimentos;
            tableTolk.text = talks[Data_Controler.pacinetGotratament];
        }
       
 

    }

    // Update is called once per frame
   
    public IEnumerator FalaFinal()
    {
      
        rostos.GetComponent<SpriteRenderer>().sprite = rostoEnfermeira;

        yield return new WaitForSeconds(1);
        foreach (char d in talkEnfermeira[Data_Controler.falasEnfermeira].ToCharArray())
        {
            talkBox.text += d;

            yield return new WaitForSeconds(1 / textSpeed);
        }
        
    }


    public IEnumerator TalkToBoard(int index)
    {
       
        rostos.GetComponent<SpriteRenderer>().sprite = rostoEnfermeira;
        foreach (char d in talkEnfermeira[0].ToCharArray())
        {
            talkBox.text += d;

            yield return new WaitForSeconds(1 / textSpeed);
        }

        yield return new WaitForSeconds(2);
        talkBox.text = "";

        rostos.GetComponent<SpriteRenderer>().sprite = spritesRostos[Data_Controler.pacientID];
        foreach (char c in talks[index].ToCharArray())
        {
            talkBox.text += c;
            tableTolk.text += c;
            yield return new WaitForSeconds(1 / textSpeed);
        }
        yield return new WaitForSeconds(3);
        talkBox.text = "";
        rostos.GetComponent<SpriteRenderer>().sprite = rostoEnfermeira;

        foreach (char f in talkEnfermeira[1].ToCharArray())
        {
            talkBox.text += f;

            yield return new WaitForSeconds(1 / textSpeed);
        }

        yield return new WaitForSeconds(2);
        talkBox.text = "";

       
        Data_Controler.falasEnfermeira = 2;
        
        camatendimento.SetActive(true);
        camtriagem.SetActive(false);

    }

    public IEnumerator TextoEnfermeira(string txt)
    {
       
        rostos.gameObject.GetComponent<SpriteRenderer>().sprite = rostoEnfermeira;

        talkBox.text = "";
        yield return new WaitForSeconds(1 / textSpeed);

        foreach (char f in txt.ToCharArray())
        {
            talkBox.text += f;

            yield return new WaitForSeconds(1 / textSpeed);
        }

        yield return new WaitForSeconds(1);
        if(Data_Controler.falasEnfermeira==2)
        {
            talkBox.text += Data_Controler.temperatura.ToString() + "ºC";
            tableTemperatura.text = Data_Controler.temperatura.ToString()+"ºC";
            yield return new WaitForSeconds(1);
            talkBox.text = "";


            if (Data_Controler.pressOk && Data_Controler.tempOk && Data_Controler.batimentosOk)
            {
                Data_Controler.triagemok = true;
               
            }


            if (!Data_Controler.triagemok)
            {
                camatendimento.SetActive(true);
                camtriagem.SetActive(false);

            }
            else
            {
                Data_Controler.falasEnfermeira = 5;
                caixaDeFala.SetActive(true);
               
                StartCoroutine(TextoEnfermeira(talkEnfermeira[Data_Controler.falasEnfermeira]));
               

            }




        }
        else if (Data_Controler.falasEnfermeira==3)
        {
            tablePressao.text = Data_Controler.pressao;
            talkBox.text += Data_Controler.pressao;
            yield return new WaitForSeconds(1);
            talkBox.text = "";


           
              
            if(Data_Controler.pressOk&&Data_Controler.tempOk && Data_Controler.batimentosOk)
            {
                Data_Controler.triagemok = true;
            }


            if(!Data_Controler.triagemok)
            {
                camatendimento.SetActive(true);
                camtriagem.SetActive(false);

            }
            else
            {
                Data_Controler.falasEnfermeira = 5;
                StartCoroutine(TextoEnfermeira(talkEnfermeira[Data_Controler.falasEnfermeira]));
              

            }
                

        }
        else if (Data_Controler.falasEnfermeira == 4)
        {
            batimentos.text = Data_Controler.batimentos;
            talkBox.text += Data_Controler.batimentos;
            yield return new WaitForSeconds(1);
            talkBox.text = "";




            if (Data_Controler.pressOk && Data_Controler.tempOk&& Data_Controler.batimentosOk)
            {
                Data_Controler.triagemok = true;
                
            }
            if (!Data_Controler.triagemok)
            {
                camatendimento.SetActive(true);
                camtriagem.SetActive(false);

            }
            else
            {
                Data_Controler.falasEnfermeira = 5;
                StartCoroutine(TextoEnfermeira(talkEnfermeira[Data_Controler.falasEnfermeira]));
                

            }


        }





        //talkBox.text = "";


    }
    private void OnEnable()
    {
       
        if (Data_Controler.falasEnfermeira>1 && Data_Controler.falasEnfermeira <=5)
        {
          
            StartCoroutine(TextoEnfermeira(talkEnfermeira[Data_Controler.falasEnfermeira]));
        }
        
       
       

    }





}
