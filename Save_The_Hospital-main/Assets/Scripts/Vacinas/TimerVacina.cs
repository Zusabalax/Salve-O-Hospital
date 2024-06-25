using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerVacina : MonoBehaviour
{
    public Image contador;
    public TextMeshProUGUI texto;
    public Slider barraguia, barraPlayer;
    public ParticleSystem []ganhou;
    bool flag,flag2,check1,check2,check3;
    float range;
    public AudioSource ticTimer, goSond, erroSond,ganhouSond;
    Color corOriginal;
    public SpriteRenderer []vacina;
    public Transform obj, obj2, p1, p2, p3;
    public GameObject camzum, cam,ArmarioA,armarioF, allColiders ,panel;
    public GameObject[] vacinamao;
   

    public static bool iniciacontagem,aplicou;
   
    // Start is called before the first frame update
    void Start()
    {

        iniciacontagem = true;
        aplicou = false;
      
       
    }
    private void OnEnable()
    {

        flag = true;
        texto.enabled = false;
        flag = true;
        flag2 = true;
        check1 = true;
        check2 = true;
        check3 = true;
        barraguia.interactable = false;
        contador.fillAmount = 1;
        barraPlayer.interactable = true;




    }
    private void OnDisable()
    {
        panel.SetActive(false);
        barraguia.value = barraguia.maxValue;
        barraPlayer.value = barraPlayer.maxValue;
        p1.gameObject.GetComponent<Image>().color = Color.green;
        p2.gameObject.GetComponent<Image>().color = Color.green;
        p3.gameObject.GetComponent<Image>().color = Color.green;

        vacinamao[EnfermagemSistem.vacinaSelect].transform.Translate(10f, 0f, 0f);
        armarioF.SetActive(true);
        ArmarioA.SetActive(false);
        contador.gameObject.SetActive(false);
        barraPlayer.gameObject.SetActive(false);
        barraguia.gameObject.SetActive(false);
      

    


    }

    // Update is called once per frame
    void Update()
    {
       // InjetouDemais();
        Checkpoints();  
        if(iniciacontagem)
        {
            panel.SetActive(true);
            barraPlayer.gameObject.SetActive(true);
            barraguia.gameObject.SetActive(true);

            StartCoroutine(ContagemRegressiva());

            iniciacontagem =false;

        }
           

    }
    void Checkpoints()
    {
        if(obj.position.x<=p1.position.x&&check1)
        {
            StartCoroutine(WChek(obj2, p1));
            check1 = false;
        }
        if (obj.position.x <= p2.position.x&&check2)
        {
            StartCoroutine(WChek(obj2, p2));
            check2 = false; 
        }
        if (obj.position.x <= p3.position.x&&check3)
        {
            StartCoroutine(WChek(obj2, p3));
            check3 = false;
        }
    }
    public IEnumerator WChek(Transform obj,Transform point)
    {
        yield return new WaitForSeconds(0.5f);
        if (obj.position.x <= point.position.x  )
        {
            if (flag) 
            {
                point.gameObject.GetComponent<Image>().color = Color.yellow;

            }
            else
            {
                point.gameObject.GetComponent<Image>().color = Color.black;
                StartCoroutine(ErroVacina());

            }



        }
        else
        {
            point.gameObject.GetComponent<Image>().color = Color.black;
            StartCoroutine(ErroVacina());
        }

    }

    void InjetouDemais()
    {
        if(barraPlayer.value<=-0.04f)
        {
            barraPlayer.interactable=false;
        }
       if(barraPlayer.value<barraguia.value-0.004f)
        {
            flag = false;
            if(flag2)
            StartCoroutine(ErroVacina());

        }
    }
    public IEnumerator WaitEndSond(AudioSource sond)
    {
        flag2 = false;
        sond.Play();

        yield return new WaitForSeconds(sond.clip.length);
       
    }
    public IEnumerator WaitEnd(GameObject obj)
    {
       

        yield return new WaitForSeconds(0.5f);
        obj.SetActive(false);

    }

    public IEnumerator ContagemRegressiva()
    {
       
        for (int i = 0; i < 10; i++)
        {
            ticTimer.Play();
            contador.fillAmount -= 0.1f;
            yield return new WaitForSeconds(0.5f);


        }
        

        yield return new WaitForSeconds(0.5f);

        goSond.Play();
        texto.enabled = true;
        yield return new WaitForSeconds(1);
        texto.enabled = false;
        range = Random.Range(0.2f, 0.4f);

        StartCoroutine(MovimentoEmbolo(range));
       


    }
    public IEnumerator Acompanha(float tempo)
    {
        
        yield return new WaitForSeconds(tempo);

        if (p1.gameObject.GetComponent<Image>().color==Color.yellow && p2.gameObject.GetComponent<Image>().color == Color.yellow && p3.gameObject.GetComponent<Image>().color == Color.yellow)
        {

           
            StartCoroutine(EsperaGanhou(1));
        }
        else
        {
            StartCoroutine(Esperaperdeu(1));
        }

    }
    public IEnumerator ErroVacina()
    {
        corOriginal = vacina[EnfermagemSistem.vacinaSelect].color;
        vacina[EnfermagemSistem.vacinaSelect].color = Color.black;
        StartCoroutine(WaitEndSond(erroSond));
        
        yield return new WaitForSeconds(0.2f);
        vacina[EnfermagemSistem.vacinaSelect].color = corOriginal;
    }
    

        public IEnumerator MovimentoEmbolo(float tempo)
        {
            for (int i = 0;i < 10;i++)
            {
                tempo=Random.Range(0.5f, 0.9f);
           
                barraguia.value -= 0.004f;
            Debug.Log(Vector2.Distance(obj.position,obj2.position));
                yield return new WaitForSeconds(tempo);
            }
            StartCoroutine(Acompanha(3));

        }
    public IEnumerator EsperaGanhou(float tempo)
    {
        ganhou[EnfermagemSistem.vacinaSelect].Play();
        ganhouSond.Play();
       




        yield return new WaitForSeconds(tempo);
        Data_Controler.vacinaOk = true;


        switch (Data_Controler.vacinaSelected)
        {
            case 0:

                if (Data_Controler.pacinetGotratament == 1 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

            case 1:

                if (Data_Controler.pacinetGotratament == 2 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

            case 2:

                if (Data_Controler.pacinetGotratament == 5 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

            case 3:

                if (Data_Controler.pacinetGotratament == 6 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

            case 4:
                if (Data_Controler.pacinetGotratament == 7 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

            case 5:
                if (Data_Controler.pacinetGotratament == 8 && Data_Controler.esterelizaOk)
                {
                    Falas.indexFala = 0;
                }
                else
                {
                    Falas.indexFala = 1;
                }

            break;

        }

        
        aplicou = true;
        armarioF.SetActive(true);
        ArmarioA.SetActive(false);

        cam.SetActive(true);
        camzum.SetActive(false);
        barraguia.value = barraguia.maxValue;
        barraPlayer.value = barraPlayer.maxValue;
        p1.gameObject.GetComponent<Image>().color = Color.green;
        p2.gameObject.GetComponent<Image>().color = Color.green;
        p3.gameObject.GetComponent<Image>().color = Color.green;

        vacinamao[EnfermagemSistem.vacinaSelect].transform.Translate(10f, 0f, 0f);
        contador.gameObject.SetActive(false);
        barraPlayer.gameObject.SetActive(false);
        barraguia.gameObject.SetActive(false);
        vacinamao[EnfermagemSistem.vacinaSelect].SetActive(false);
        allColiders.SetActive(false);
        EnfermagemSistem.clicou = true;
        contador.gameObject.SetActive(false);
        



    }
    
    public IEnumerator Esperaperdeu(float tempo)
    {
        StartCoroutine(ErroVacina());
        yield return new WaitForSeconds(tempo);
        aplicou = true;
        
        armarioF.SetActive(true);
        ArmarioA.SetActive(false);
        flag = false;
        Falas.indexFala = 2;
        Data_Controler.vacinaOk = true;
        barraguia.value = barraguia.maxValue;
        barraPlayer.value = barraPlayer.maxValue;
        p1.gameObject.GetComponent<Image>().color = Color.green;
        p2.gameObject.GetComponent<Image>().color = Color.green;
        p3.gameObject.GetComponent<Image>().color = Color.green;

        vacinamao[EnfermagemSistem.vacinaSelect].transform.Translate(10f, 0f, 0f);
        contador.gameObject.SetActive(false);
        barraPlayer.gameObject.SetActive(false);
        barraguia.gameObject.SetActive(false);
       
        cam.SetActive(true);
        camzum.SetActive(false);
        vacinamao[EnfermagemSistem.vacinaSelect].SetActive(false);
        allColiders.SetActive(false);
        EnfermagemSistem.clicou = true;
       



    }

}

