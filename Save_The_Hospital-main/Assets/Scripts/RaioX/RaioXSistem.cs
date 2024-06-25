using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class RaioXSistem : MonoBehaviour
{
    bool pontoCorreto;
    public GameObject barraDeCarga,focoImagem,limitetv;
    public Light2D luz;
    public AudioSource xray1,xray2;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "xray")
        {
           

            Debug.Log("entrou lugar raiox certo");
            pontoCorreto = true;
         

           if (MoveXrayEmissor.mouseOncollisor) 
            {
               

                StartCoroutine(TempoDeRAioX());

            }
                
          
           
            
            


        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        barraDeCarga.GetComponent<Image>().fillAmount = 1;
        StopCoroutine(TempoDeRAioX());
        if (collision.gameObject.tag == "xray")
        {
            Debug.Log("saiu lugar raiox certo");
            pontoCorreto = false;
            barraDeCarga.GetComponent<Image>().fillAmount = 1;
            StopCoroutine(TempoDeRAioX());

          
           

        }

    }
    public IEnumerator TempoDeRAioX()
    {
        MoveXrayEmissor.mouseOncollisor = false;
       MoveXrayEmissor.podeclicar = false;
        barraDeCarga.GetComponent<Image>().fillAmount = 1;
        if (pontoCorreto) 
        {
            for (int i = 0; i < 10; i++)
            {
               

                yield return new WaitForSeconds(0.5f);
                barraDeCarga.GetComponent<Image>().fillAmount -= 0.1f;

               xray1.Play();
            }
            
            xray1.Stop();   
            StartCoroutine(EfeitoluzxRay());
        }

        else
        {
            barraDeCarga.GetComponent<Image>().fillAmount = 1;
        }

       
    }

    public IEnumerator EfeitoluzxRay()
    {

        luz.intensity = 100;
        xray2.Play();
        yield return new WaitForSeconds(1.5f);

        luz.intensity = 1;
      
        focoImagem.SetActive(true);
        luz.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        focoImagem.SetActive(false);
        limitetv.SetActive(false);
        Data_Controler.raioxOk = true;
        Data_Controler.camChange = true;
        Debug.Log("pppqq" + Data_Controler.pacinetGotratament);
        if(Data_Controler.pacinetGotratament==0)
        {
            Data_Controler.falasEnfermeira = 6;
            ImagemRaiox.index = 2;

        }
        else if (Data_Controler.pacinetGotratament == 3)
        {
            Data_Controler.falasEnfermeira = 7;
            ImagemRaiox.index = 1;
        }
        else 
        {
            Data_Controler.falasEnfermeira = 8;
            ImagemRaiox.index = 3;
        }
      
        SceneManager.LoadScene("Triagem");


    }
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
