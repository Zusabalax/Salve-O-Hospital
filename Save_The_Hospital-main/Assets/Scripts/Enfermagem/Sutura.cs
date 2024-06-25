using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sutura : MonoBehaviour
{
    public  LineRenderer linhasutura;
    public Camera cam;
    Vector3 previosPosition;
    public GameObject enfermagem, zoom;
    public  float midDistance;
    public Collider2D colisorEsquerdo, colisorDireito;
    bool mouseOnCollider;
    public GameObject allColliders;
    public AudioSource sutura,fogossom,tone1,tone2,erro;

    public static  bool vitoria;
    public GameObject agulha,agulha2;
    public ParticleSystem fogos;
    Vector3 mouseposition;
    public Transform clone;
    public List<GameObject> allClones;
    public int nPontos,notaSequancia,nRepete;
    public  List<int> sequenciaJogo, sequenciaPlayer;
    public bool lado;
   

  


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == colisorEsquerdo)
        {
            mouseOnCollider = true;
            lado = true;
           

        }
       else  if (collision == colisorDireito)
        {
            mouseOnCollider = true;
            lado = false;
           
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == colisorEsquerdo)
        {
            mouseOnCollider = false;
          

        }
        else if (collision == colisorDireito)
        {
            mouseOnCollider = false;
        }
    }









    // Start is called before the first frame update
    void Start()
    {
        allClones = new List<GameObject>();
        sequenciaJogo=new List<int> ();

        mouseOnCollider = false;
        nPontos = 0; 


      
        previosPosition =transform.position;
    }

    // Update is called once per frame
    void Update()
    {

      ClickSutura();
      

    }
    private void OnMouseUp()
    {
        StartCoroutine(Agulhada());
    }
    private IEnumerator Agulhada()
    {
      
            this.transform.rotation = Quaternion.Euler(0, 0, 45);

            yield return new WaitForSeconds(0.2f);
            this.transform.rotation = Quaternion.Euler(0, 0, -45);

       




    }


    void ClickSutura()
    {
        mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        if (linhasutura.positionCount > 0)
        {
            linhasutura.SetPosition(linhasutura.positionCount - 1, mouseposition);
        }
       


        if (Input.GetMouseButtonUp(0) && mouseOnCollider)
        {



            StartCoroutine(Agulhada());
            mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseposition.z = 0;
            if (Vector3.Distance(previosPosition, mouseposition) > midDistance)
            {
                nPontos++;
                if(lado)
                {
                    sequenciaPlayer.Add(1);
                }
                else
                {
                    sequenciaPlayer.Add(0);
                }
                Debug.Log("Npontos : "+nPontos);
                if (nPontos == 6)
                {
                    vitoria = true;
                    if (TesteVitoria())
                    {
                        StartCoroutine(Vitoria());
                    }
                    else
                    {
                        StartCoroutine(Derrota());

                    }
                   
                }
               
            
                linhasutura.positionCount++;
                linhasutura.SetPosition(linhasutura.positionCount - 1, mouseposition);
                previosPosition = mouseposition;

                if(linhasutura.positionCount==3) 
                {

                    agulha2 = Instantiate(agulha,Vector3.zero, Quaternion.identity);
                    
                    agulha2.GetComponent<LineRenderer>().positionCount = 1;
                    linhasutura = agulha2.GetComponent<LineRenderer>();
                    allClones.Add(agulha2.gameObject);
                }
               

            }


           
        }
  
    }

    private IEnumerator Derrota()
    {
        erro.Play();    
        colisorDireito.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        Debug.Log(colisorDireito.gameObject.transform.GetChild(0).gameObject.name);
        colisorEsquerdo.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        Debug.Log(colisorEsquerdo.gameObject.transform.GetChild(0).gameObject.name);
       yield return new WaitForSeconds(0.2f);

        colisorDireito.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
       .color = new Color(0.09433961f, 0.01637593f, 0.01637593f, 0.5607843f);

        colisorEsquerdo.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color =
            new Color(0.09433961f, 0.01637593f, 0.01637593f, 0.5607843f);
        yield return new WaitForSeconds(0.2f);

        Falas.indexFala = 2;
        Data_Controler.suturaOK = false;
        zoom.SetActive(false);
        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);
    }

    bool TesteVitoria()
    {
        for (int k  = 0; k < sequenciaJogo.Count; k++)
        {
            if (sequenciaJogo[k] != sequenciaPlayer[k])
            {
                vitoria = false;
            }
        }
        return vitoria; 
    }
    private IEnumerator Vitoria()
    {
         fogos.Play();
      
        fogossom.Play();    
        this.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        if(Data_Controler.pacinetGotratament==4 && Data_Controler.esterelizaOk  && Data_Controler.raioxOk)
        {
            Falas.indexFala = 0;
            Data_Controler.suturaOK = true;

        }
        else
        {
            Falas.indexFala = 1;
        }
       

        zoom.SetActive(false);
        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);
       
       
       
       
    }
    private void OnEnable()
    {
        allColliders.SetActive(true);
       
        linhasutura = this.GetComponent<LineRenderer>();
        StartCoroutine(SequenciaGame());
      
       

        linhasutura.positionCount = 1;

    }
    private void OnDisable()
    {
      
        nPontos = 0;
        allColliders.SetActive(false);
        vitoria= false;
       
        sequenciaJogo.Clear();
        sequenciaPlayer.Clear();
        foreach (var apaga in allClones)
        {
            Destroy(apaga);

        }
        allClones.Clear();


    }
    

    private IEnumerator SequenciaGame()
    {
        colisorDireito.enabled = false;
        colisorEsquerdo.enabled = false;

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 6; i++)
        {
            nRepete = Random.Range(0, 2);

            if(i%2!=0)
            {
                do
                {
                    nRepete = Random.Range(0, 2);

                } while (nRepete == notaSequancia);
            }
          
            
           
            notaSequancia = nRepete;
               
           sequenciaJogo.Add(notaSequancia);
            if(notaSequancia == 0)
            {
               
                tone1.Play();
                colisorDireito.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                yield return new WaitForSeconds(0.2f);
                colisorDireito.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
               .color = new Color(0.09433961f, 0.01637593f, 0.01637593f, 0.5607843f);

                
            }
            else
            {
               
                tone2.Play();
                colisorEsquerdo.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                yield return new WaitForSeconds(0.2f);
                colisorEsquerdo.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>()
                .color = new Color(0.09433961f, 0.01637593f, 0.01637593f, 0.5607843f);

            }
            yield return new WaitForSeconds(0.5f);



        }
        colisorDireito.enabled = true;
        colisorEsquerdo.enabled = true;
        yield return new WaitForSeconds(1);

      



    }


}
