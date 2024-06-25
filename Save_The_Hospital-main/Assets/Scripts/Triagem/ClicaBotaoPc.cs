using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicaBotaoPc : MonoBehaviour
{
    public  Collider2D bootonColider;
    public static   bool flag,limitaBatimentos,leituraBatimentosOk;
    public GameObject[] acertos, erros;
    public GameObject camAtendimento, camTriagem;
    public Transform estetopósition, estetoscopio,p1;
    
    int i;
    bool fimleitura;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        limitaBatimentos = true;
        fimleitura = true;
        leituraBatimentosOk = false;



    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision = bootonColider)
        {
            flag = true;
            Debug.Log("dentroooooooooooooooooo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision2)
    {
        if(collision2=bootonColider)
        {
            flag = false;
            Debug.Log("foraaaaaaaaaaaaaaaaa");
        }
       
    }




    // Update is called once per frame
    void Update()
    {

        
        if(fimleitura)
        {
            ClickBotao();

        }
        



    }
    void ClickBotao()
    {
        if (Input.GetMouseButtonDown(0) && Mouse.clickB && flag)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            if (this.gameObject.activeSelf == true)
            {
                StartCoroutine(ClicOnPc(Color.green));
            }

            if (limitaBatimentos)
            {
                limitaBatimentos = false;
                BatimentosCardiacos.stopCorrotine = true;
                StartCoroutine(BatimentosCardiacos.Instance.MonitorBatimentos());
            }


            if (BatimentosCardiacos.anota)
            {

                if (i < 3)
                {
                    acertos[i].SetActive(true);
                    i++;

                }
                if (i == 3)
                {

                    BatimentosCardiacos.stopCorrotine = false;
                    Data_Controler.batimentosOk = true;
                    TriagemSistem.block = true;
                    Data_Controler.falasEnfermeira = 4;
                    Estetoscopio.mouseclik = true;
                    leituraBatimentosOk = true;
                    estetoscopio.position = estetopósition.position;
                   
                    i = 0;
                    StartCoroutine(FlipFlop());
                    p1.GetChild(0).gameObject.GetComponent<TrailRenderer>().sortingOrder = -1; ;
               
                    if (Data_Controler.pressOk && Data_Controler.tempOk && Data_Controler.batimentosOk)
                    {
                        Data_Controler.triagemok = false;
                        Data_Controler.camChange = true;

                    }
                    StartCoroutine(TrocaCena());
                   

                }
               
              

            }
            else
            {

                this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                StartCoroutine(ClicOnPc(Color.green));

            }


        }

    }
    public IEnumerator FlipFlop()
    {
        fimleitura = false;
        yield return new WaitForSeconds(0.5f);
        fimleitura = true;



    }
    public IEnumerator ClicOnPc(Color cor)
    {
       
        yield return new WaitForSeconds(0.2f);
        if (this.gameObject.activeSelf == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = cor;
        }
        



    }
    public IEnumerator TrocaCena()
    {
      


        yield return new WaitForSeconds(1);
        acertos[0].SetActive(false);
        acertos[1].SetActive(false);
        acertos[2].SetActive(false);
        camAtendimento.SetActive(false);
        camTriagem.SetActive(true);


    }
    private void OnDisable()
    {
        limitaBatimentos = true;

    }

}
