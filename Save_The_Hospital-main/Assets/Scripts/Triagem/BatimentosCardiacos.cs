using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatimentosCardiacos : MonoBehaviour
{
    public GameObject coracao;
    public AudioSource somBatidas,monitorCardiaco;
    public static bool anota, estetoPosition,flag1, flag2,flag3,stopCorrotine;
    public GameObject linha;
    public Transform p1, p2,p3,p4,p5,p6;
    float tempoBatidas;
    
    public static BatimentosCardiacos Instance;
    private void Awake()
    {
        Instance = this;
        stopCorrotine = true;
        flag1 = false;
        flag2 = false;
        flag3 =false;
       
        
        estetoPosition = false;

       
    }


    // Start is called before the first frame update
    void Start()
    {
       
       

      

    }

    // Update is called once per frame
    void Update()
    {




        //if (flag1)
        //{
        //    flag1 = false;
        //    StartCoroutine(MonitorBatimentos());

        //}
        //if (estetoPosition)
        //{
        //    StartCoroutine(Batimentos());
        //    estetoPosition=false;
        //}
    }
    public IEnumerator MonitorBatimentos()
    {
       
            monitorCardiaco.Play();

            p1.transform.GetChild(0).DOMoveY(p5.position.y, 0.01f, false);
            yield return new WaitForSeconds(0.02f);
            p1.transform.GetChild(0).DOMoveY(p6.position.y, 0.01f, false);
            yield return new WaitForSeconds(0.02f);
            p1.transform.GetChild(0).DOMoveY(p1.position.y, 0.01f, false);
            yield return new WaitForSeconds(0.02f);

            p1.transform.GetChild(0).DOMoveY(p3.position.y, 0.01f, false);
            yield return new WaitForSeconds(0.02f);
            p1.transform.GetChild(0).DOMoveY(p4.position.y, 0.01f, false);
            yield return new WaitForSeconds(0.02f);
            p1.transform.GetChild(0).DOMoveY(p1.position.y, 0.01f, false);

            yield return new WaitForSeconds(1.5f);
            flag1 = true;
            ClicaBotaoPc.limitaBatimentos = true;

    }
    public IEnumerator GeradorBatimentos()
    {
        
        while(stopCorrotine)
        {
            flag2 = true;

            Instantiate(linha,p1);
            if(ClicaBotaoPc.leituraBatimentosOk)
            {
                Destroy(p1.transform.GetChild(0).gameObject);
            }

           
            yield return new WaitForSeconds(4);
            Destroy(p1.transform.GetChild(0).gameObject); 
        }
        flag2 = false;




    }
    public IEnumerator Batimentos()
    {
       
        while (stopCorrotine) 
        {
            flag3 = true;
            anota = true;
            yield return new WaitForSeconds(0.2f);
            coracao.transform.localScale = coracao.transform.localScale*1.2f;
           // coracao.GetComponent<SpriteRenderer>().color = Color.green;
            somBatidas.Play();
            
           
            yield return new WaitForSeconds(1);
            anota = false;
            somBatidas.Play();
           // coracao.GetComponent<SpriteRenderer>().color = Color.red;
            coracao.transform.localScale = coracao.transform.localScale / 1.2f;
            yield return new WaitForSeconds(1);
            
        }
        flag3 = false;






    }
   






    

}
