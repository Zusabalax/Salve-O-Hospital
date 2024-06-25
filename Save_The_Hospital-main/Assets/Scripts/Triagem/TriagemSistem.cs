using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriagemSistem : MonoBehaviour
{
    public  bool mouseOnTermometro, mouseOnPressao, termometroDrop, pressDrop, botao;
    public bool mouseClickP, mouseClickT;

    public Camera cam;
    public Rigidbody2D rb;
    public GameObject termometro, atemdimento, sala, reclama,press1,press2,press3;
    public Transform termometroMesa,termomentroPosition;
    public int temometropress,bombadas;
    public Transform pressaoMesa;
    public AudioSource somTemperatura,somPegar;
    public static TriagemSistem InstanceTriagem;
    public static bool mouseclickPressao, mouseclickTemperatura,block;

    public TextMeshProUGUI tempPc,presPc;
    bool tempUnica;

    private void Awake()
    {

        InstanceTriagem = this;

    }
    void Start()
    {
        bombadas = 0;
        botao = true;
        termometroDrop = true;
        pressDrop = true;
        block = true;
        termometro.transform.position = termometroMesa.position;
        press1.transform.position = pressaoMesa.position;



    }
    //private void OnMouseDown()
    //{

    //    if (mouseOnTermometro&& mouseOnTermometro&& termometroDrop && temometropress == 0)
    //    {
    //        //  mouseOnTermometro = true;
    //        mouseClickT = true;
    //        mouseclickTemperatura = mouseClickT;
    //        mouseclickPressao = false;
    //        Estetoscopio.mouseclik = false;
    //        tempUnica = true;


    //        somPegar.Play();

    //    }
      

    //    if ( mouseOnPressao&& pressDrop && temometropress == 1)
    //    {
    //        //  mouseOnTermometro = true;
    //        mouseClickP = true;
    //        mouseclickPressao = mouseClickP;
    //        mouseclickTemperatura = false;
    //        Estetoscopio.mouseclik = false;
    //        somPegar.Play();

    //    }
       
    //}
    //private void OnMouseUp()
    //{
    //    if (mouseOnTermometro&& termometroDrop && temometropress == 0)
    //    {
    //        //  mouseOnTermometro = true;
    //        mouseClickT = false;
    //        mouseclickTemperatura = mouseClickT;
           
    //        somPegar.Play();


    //    }
    //    if (mouseOnPressao && pressDrop && temometropress == 1)
    //    {
    //        //  mouseOnTermometro = true;
    //        mouseClickP = false;
    //        mouseclickPressao = mouseClickP;
            
    //        somPegar.Play();


    //    }
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
       

            if (temometropress == 0)

            {

                if (collision.gameObject.tag == "termometropoint")
                {
                    Data_Controler.onTermometroPoind = true;
                termometro.transform.position = termomentroPosition.position;

                    Debug.Log("termometroi no lugar correto");


                }



            }
            if (temometropress == 1)
            {
                if (collision.gameObject.tag == "pressaopoint")
                {
                    Data_Controler.onPressPopint = true;
                    






                    Debug.Log("pressao  no lugar correto");


                }

            }

            if (collision.gameObject.tag == "erropoint")
            {
                Debug.Log("pressao no lugar errado");



                reclama.SetActive(true);

                // Data_Controler.onTermometroPoind = false;
            }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       

            if (temometropress == 0)
            {
                if (collision.gameObject.tag == "termomentropoint")
                {
                    Debug.Log("termometroi saiu do lugar correto");
                    Data_Controler.onTermometroPoind = false;
                    block = false;

                }

            }
            if (temometropress == 1)
            {
                if (collision.gameObject.tag == "pressaopoint")
                {
                    Debug.Log("pressao saiu do lugar correto");
                    Data_Controler.onPressPopint = false;
                    block = false;

            }
            }
            if (collision.gameObject.tag == "erropoint")
            {
                Debug.Log("pressao no lugar errado");
                reclama.SetActive(false);

                // Data_Controler.onTermometroPoind = false;
            }





    }
    private void OnMouseOver()
    {
        if (block)
        {

            if (termometroDrop && temometropress == 0)
            {
                //  mouseOnTermometro = true;
                mouseOnTermometro = true;
                //  mouseclickTemperatura = mouseOnTermometro;
                // somPegar.Play();

            }


            if (pressDrop && temometropress == 1)
            {
                //  mouseOnTermometro = true;
                mouseOnPressao = true;
                // mouseclickPressao = mouseOnPressao;
                //  somPegar.Play();

            }

            if (Input.GetMouseButtonDown(0))
            {
                if (mouseOnTermometro && mouseOnTermometro && termometroDrop && temometropress == 0)
                {
                    //  mouseOnTermometro = true;
                    mouseClickT = true;
                    mouseclickTemperatura = mouseClickT;
                    mouseclickPressao = false;
                    Estetoscopio.mouseclik = false;
                    tempUnica = true;


                    somPegar.Play();

                }


                if (mouseOnPressao && pressDrop && temometropress == 1)
                {
                    //  mouseOnTermometro = true;
                    mouseClickP = true;
                    mouseclickPressao = mouseClickP;
                    mouseclickTemperatura = false;
                    Estetoscopio.mouseclik = false;
                    somPegar.Play();

                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (mouseOnTermometro && termometroDrop && temometropress == 0)
                {
                    //  mouseOnTermometro = true;
                    mouseClickT = false;
                    mouseclickTemperatura = mouseClickT;

                    somPegar.Play();


                }
                if (mouseOnPressao && pressDrop && temometropress == 1)
                {
                    //  mouseOnTermometro = true;
                    mouseClickP = false;
                    mouseclickPressao = mouseClickP;

                    somPegar.Play();


                }
            }


        }



    }

    private void OnMouseExit()
    {
        if (termometroDrop && temometropress == 0)
        {
            //  mouseOnTermometro = true;
            mouseOnTermometro = false;
           
          

        }


        if (pressDrop && temometropress == 1)
        {
            //  mouseOnTermometro = true;
            mouseOnPressao = false;
         
          

        }

    }

    void Arrasta()
    {
        if (mouseClickP|| mouseClickT) 
        {
            rb.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));

        }
      
    }

    // Start is called before the first frame update
  
   

    // Update is called once per frame
    void Update()
    {
        Arrasta();
       InstrumentoUse();
    }
    
    public void InstrumentoUse()
    {
        if ((!mouseOnTermometro ) && Data_Controler.onTermometroPoind)
        {
            Data_Controler.falasEnfermeira = 2;
            
            StartCoroutine(LeituraTermomentro((Data_Controler.temperatura * 10) / 42));
            
            

        }
        if ((mouseOnPressao) && Data_Controler.onPressPopint)
        {

            Data_Controler.falasEnfermeira = 3;
            LeituraPressao();
            


        }
    }
    private void OnEnable()
    {
        termometroDrop = true;
        pressDrop = true;
       


    }
   
    IEnumerator LeituraTermomentro(int temeperatura)
    {
        block = false;
      
        if (temometropress==0 && tempUnica)
        {
            mouseClickP = false;
            mouseClickT = false;
            tempUnica = false;
            termometroDrop=false;   
            Debug.Log("entrou no if temperatura");
           
            termometroDrop = false;
            Debug.Log("termometrodrop?");
            for (int k = 0; k < temeperatura; k++)
            {
                Debug.Log("entrou no for temperatura");
                yield return new WaitForSeconds(0.5f);
                termometro.transform.GetChild(1).GetComponent<Image>().fillAmount -=0.08f;
               
              
                somTemperatura.Play(0);  
                Debug.Log(termometro.transform.GetChild(1).GetComponent<Image>().fillAmount);

            }
            tempPc.text = Data_Controler.temperatura.ToString();
            yield return new WaitForSeconds(1.5f);
          
            Data_Controler.tempOk = true;
           
           

            termometro.transform.GetChild(1).GetComponent<Image>().fillAmount = 1;
            termometro.transform.position = termometroMesa.position;
            Data_Controler.onTermometroPoind = false;




            if (Data_Controler.pressOk && Data_Controler.tempOk &&Data_Controler.batimentosOk)
            {
                Data_Controler.triagemok = true;
                Data_Controler.camChange = true;
            }
            termometro.transform.position = termometroMesa.position;
            Data_Controler.onTermometroPoind = false;
            block = true;
            sala.SetActive(true);
            atemdimento.SetActive(false);



        }
       


    }
    void LeituraPressao()
    {
        if(temometropress==1)
        {
            Debug.Log("entrou no if pressao");
            mouseClickP = false;
            mouseClickT = false;
            press1.SetActive(false);
            press1.transform.position = pressaoMesa.position;
            press2.SetActive(true);
            press3.SetActive(true);
        }
       
      
       
    }
    public void BotaoPresao()
    {
        if(botao)
        {
            StartCoroutine(ApertaBotao());
            bombadas++;
        }
        botao = false;

        

    }
   
   public  IEnumerator ApertaBotao()
    {
       
            botao = true;
            press2.transform.localScale += new Vector3(1.02f, 1.02f, 0);

            yield return new WaitForSeconds(0.5f);
            press2.transform.localScale -= new Vector3(1.02f, 1.02f,0);
        if(bombadas==3)
        {
            presPc.text = Data_Controler.pressao;
        }

        else if (bombadas >= 4)
        {

            press1.SetActive(true);
            press2.SetActive(false);
            press3.SetActive(false);
           
            bombadas = 0;
            botao = true;
           
          
            Data_Controler.pressOk = true;
            block = true;
            if (Data_Controler.pressOk && Data_Controler.tempOk && Data_Controler.batimentosOk)
            {
                Data_Controler.triagemok = true;
                Data_Controler.camChange = true;

            }
            press1.transform.position = pressaoMesa.position;
            Data_Controler.onPressPopint = false;    

            atemdimento.SetActive(false);
            sala.SetActive(true);
            
        }
        botao = true;

       

    }




}
