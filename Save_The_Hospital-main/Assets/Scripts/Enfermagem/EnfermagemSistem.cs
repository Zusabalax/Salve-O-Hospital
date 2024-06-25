using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EnfermagemSistem : MonoBehaviour
{
    public Camera [] cam ;
    public GameObject[] objetoDaMesa;
  
    public static bool mouseOncollisor, clicou,moveAlvo;
    public AudioSource click,seleciona;
    public Rigidbody2D[] rb;
    public int objetoSelecionado;
    public static int vacinaSelect;
   public  bool scaleFlag;
     private Vector3 escala;
  


     void Awake()
    {
        escala = this.transform.localScale;
        scaleFlag = true;
    }

    void OnMouseOver()
    {
        if(scaleFlag)
        {
            this.transform.localScale = this.transform.localScale * 1.2f;
            scaleFlag = false;

        }
       


        if (Input.GetMouseButtonDown(0))
        {
            click.Play();
         
            TimerVacina.aplicou = false;
            AmpliaVacina.jafoi = false;
           
            
            vacinaSelect = objetoSelecionado;
            clicou = true;
            moveAlvo = true;
            for (int i = 0; i < objetoDaMesa.Length; i++)
            {
               
                if (i==objetoSelecionado) 
                {
                    objetoDaMesa[objetoSelecionado].SetActive(true);

                }
                else
                {
                    objetoDaMesa[i].SetActive(false);
                }
                
            }
           

           
           cam[0].gameObject.SetActive(false);
            cam[1].gameObject.SetActive(true);

           
                


        }
        else if (Input.GetMouseButtonUp(0)) { clicou = false; }
    }
    private void OnMouseEnter()
    {
        seleciona.Play();
        
    }
    void OnMouseExit()
    {
        if (!scaleFlag) 
        {
            this.transform.localScale = escala;
            scaleFlag = true;
        }
      
        // arrowSelect.gameObject.GetComponent<SpriteRenderer>().color = Color.white;


    }
    // Start is called before the first frame update
    void Start()
    {
        moveAlvo = true;
        if(!Data_Controler.gessoOk && !Data_Controler.suturaOK && !Data_Controler.vacinaOk )
        {
            Falas.indexFala = 4;
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        Arrasta();
        
    }
    void Arrasta()
    {
        if (clicou)
        {
            rb[objetoSelecionado].MovePosition(cam[1].ScreenToWorldPoint(Input.mousePosition));
           

        }
       

           

    }



    
   
}



