using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vacinas : MonoBehaviour
{
    public Collider2D colliderv;
    public Slider slider;
    public GameObject embolo;
    public Image seringaCheia;
    public GameObject relogio;
    public GameObject allcolliders;
    public GameObject alvo;
    public AudioSource agulhada,emboloSond;
    public  bool flag;
    Transform originalPosition;
    public int vacinaNumber;


    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        originalPosition = embolo.transform;
        
    }
    private void OnEnable()
    {
        allcolliders.SetActive(true);
        alvo.SetActive(true);
        flag = true;
        originalPosition = embolo.transform;
       

    }
    private void OnDisable()
    {
        StopAllCoroutines();
        allcolliders.SetActive(false);
        alvo.SetActive(false);
        embolo.transform.position = originalPosition.position;
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision = colliderv)
        {
         
            EnfermagemSistem.clicou = false;
            EnfermagemSistem.moveAlvo = false;
            slider.gameObject.SetActive(true);
            relogio.gameObject.SetActive(true);
           alvo.SetActive(true) ;
            agulhada.Play();
            TimerVacina.iniciacontagem = true;
            Data_Controler.vacinaSelected = vacinaNumber;

        }

            


    }
    public IEnumerator WaitEndSond(AudioSource sond)
    {
        flag = false;
        sond.Play();

        yield return new WaitForSeconds(sond.clip.length);
        flag = true;
    }

        // Update is called once per frame
    void Update()
    {
        
       
    }
    public void MoveEmbolp()
    {
        if (vacinaNumber==Data_Controler.vacinaSelected)
        {
            embolo.transform.localPosition = new Vector3(slider.value + 0.182f, 0, 0);
            seringaCheia.fillAmount = 1 + (slider.value * (25f));
            if (flag)
            {
                StartCoroutine(WaitEndSond(emboloSond));
            }
        }
       
       
    }

}
