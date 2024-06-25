
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AplicaGesso : MonoBehaviour
{
   
    
    public  Transform[] colliderD,colliderE;
    public Transform [] guardPosition;
    public Sprite []bracoGesso;
    public Image gessoImage;
    public  int randonNumber;
   
    public int cont;
    public Collider2D braco;
    private LineRenderer faixa;
    public Camera cam;
    Vector3 previosPosition;
    public GameObject enfermagem, zoom;
    public float midDistance;
    public Collider2D[] colisorEsquerdo, colisorDireito;
   
    public bool mouseOnCollider,coresIguais;
    Color lastCor;
    List<Color> colorList; 
    public int pontos;
    public ParticleSystem fogos;
    public AudioSource acertou, errou,click;
    public GameObject allColliders;
    public Transform pacientePosition;


    private void OnTriggerStay2D(Collider2D collision)
    {
        


        for (int i = 0; i < colisorDireito.Length; i++)
        {
            cont = 1;
            if (collision == colisorEsquerdo[i])
            {
                mouseOnCollider = true;
               


                lastCor = colisorEsquerdo[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color;


            }
            else if (collision == colisorDireito[i])
            {
                mouseOnCollider = true;
               

                lastCor = colisorDireito[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            }
        } 
        
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int k = 0; k < colisorEsquerdo.Length; k++)
        {
            if (collision == colisorEsquerdo[k])
            {
                mouseOnCollider = false;
               


            }
            else if (collision == colisorDireito[k])
            {
                mouseOnCollider = false;
               
            }

        }
       
    }









    // Start is called before the first frame update
    void Start()
    {
        mouseOnCollider = false;

        colorList = new List<Color>();
        faixa = GetComponent<LineRenderer>();
        previosPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonUp(0) && mouseOnCollider)
        {
            click.Play();

            Vector3 mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseposition.z = 0;

            if (Vector3.Distance(previosPosition, mouseposition) > midDistance)
            {
               


                faixa.positionCount++;
                faixa.SetPosition(faixa.positionCount - 1, mouseposition);
                previosPosition = mouseposition;
                colorList.Add(lastCor);
                faixa.gameObject.GetComponent<SpriteRenderer>().color = lastCor;
                CoresIguais();


                if (faixa.positionCount % 2 == 0)
                {

                    for (int p = 0; p < colliderD.Length; p++)
                    {
                        colisorDireito[p].enabled = true;
                        colisorEsquerdo[p].enabled = false;
                    }
                }
                else
                {

                    for (int u = 0; u < colliderD.Length; u++)
                    {
                        colisorDireito[u].enabled = false;
                        colisorEsquerdo[u].enabled = true;
                    }
                }





            }



        }

        if (faixa.positionCount >= (colisorEsquerdo.Length * 2))
        {

            faixa.positionCount = 0;



            faixa.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            StartCoroutine(FinalizaGesso());



        }
    }
    void CoresIguais()
    {
        if(colorList.Count%2 == 0 && colorList.Count>=2)
        {
            if (colorList[colorList.Count - 1] == colorList[colorList.Count-2])
            {
                Debug.Log("cores  iguais");
                gessoImage.fillAmount -= 0.2f;
                fogos.Play();
                acertou.Play();

            }
            else
            {
                Debug.Log("cores nao iguais");
                errou.Play(); 
                StartCoroutine(Errouu());
                Falas.indexFala = 2;

            }
        }
       
    }
    public IEnumerator Errouu()
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.black, 0.0f), new GradientColorKey(Color.black, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(1, 1.0f) }
        );
        faixa.colorGradient = gradient;
       
        yield return new WaitForSeconds(0.2f);
        gradient.SetKeys(
           new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
           new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(1, 1.0f) });

        faixa.colorGradient = gradient;

    }
    public IEnumerator FinalizaGesso()
    {
        yield return new WaitForSeconds(1);
       
        zoom.SetActive(false);
        gessoImage.fillAmount = 1;
       
        colorList.Clear();
        for (int d = 0; d < colliderD.Length; d++)
        {
            colliderE[d].gameObject.SetActive(true);
            colliderD[d].gameObject.SetActive(true);
        }
        for (int u = 0; u < colliderD.Length; u++)
        {
            colisorDireito[u].enabled = true;
            colisorEsquerdo[u].enabled = false;
        }
        if(Falas.indexFala!=2)
        {
            if(Data_Controler.pacinetGotratament==3 && Data_Controler.esterelizaOk && Data_Controler.raioxOk)
            {
                Data_Controler.gessoOk = true;
                Falas.indexFala = 0;

            }
            else 
            {
                Falas.indexFala = 1; 
            }
            
           

        }
       
       

        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);
        
      


       // Destroy(pacientePosition.GetChild(0).gameObject);
       // SceneManager.LoadScene("Triagem");
    }
    public void RandonCores() 
    {
       


        for (int i = 0; i <12; i++)
        {
            randonNumber = Random.Range(0, colliderD.Length);
            guardPosition[0].position = colliderD[randonNumber].position;
            colliderD[randonNumber].position = colliderD[0].position;
            colliderD[0].position = guardPosition[0].position;
           
            randonNumber = Random.Range(0, colliderE.Length);
            guardPosition[0].position = colliderE[randonNumber].position;
            colliderE[randonNumber].position = colliderE[0].position;
            colliderE[0].position = guardPosition[0].position;
           
        }
           


      

       

       



    }
     void OnEnable()
    {
       
        RandonCores();
        cont = 0;
        allColliders.SetActive(true);
      

    }
    private void OnDisable()
    {
        allColliders.SetActive(false );
    }

}
