
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Estereliza : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer tampacorte;
    public TrailRenderer trail;
    public Image barra,barra2;
    public Collider2D colisorCima, colisorBaixo, algopdao, braco;
    bool flag1, flag2, onbraco;
    public int i,nmax;
    public GameObject zuum, enfermagem;
    public Transform clones;

    public AudioSource limpa,perdeu,ganhou;
    public GameObject allColliders;

    private void OnEnable()
    {
        allColliders.SetActive(true);
        StartCoroutine(TempoEstereliza());
        tampacorte.color = Color.red;
       
    


    }
    private void OnDisable()
    {
        allColliders.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == braco)
        {
            onbraco = true;
            trail.enabled = true;
        }
        if (collision == colisorCima)
        {


            flag1 = true;
        }
        else if (collision == colisorBaixo)
        {
            algopdao.enabled = true;
            flag2 = true;
        }
        if (flag1 && !flag2 && onbraco&& i<nmax)
        {
            i++;
            Debug.Log(i);
            flag1 = false;
            flag2 = false;
            tampacorte.color -= new Color(0, 0, 0, 0.05f);
            limpa.Play();


        }
        if(i>=nmax && i<100)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            ganhou.Play();
            StartCoroutine(Ganhou());
            i = 200;
        }

    }
    public IEnumerator Ganhou()
    {
        Data_Controler.esterelizaOk=true;
        Falas.indexFala = 3;
        yield return new WaitForSeconds(0.5f);
        zuum.SetActive(false);
        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);
        barra2.fillAmount = 0;
        i = 0;
        tampacorte.color -= new Color(0, 0, 0, 1);
        StopCoroutine(TempoEstereliza());

    }

    public IEnumerator Derrota()
    {
        Data_Controler.esterelizaOk = false;
        Falas.indexFala = 1;
        yield return new WaitForSeconds(1);
       
        barra2.fillAmount = 0;
        i = 0;
       // tampacorte.color = new Color(0.5754717f, 0.4726515f, 0.3604842f, 0);
        zuum.SetActive(false);
        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);

    }


    public  IEnumerator TempoEstereliza()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            barra2.fillAmount += 0.1f;

        }
        perdeu.Play();
       
        tampacorte.color = Color.black;

        yield return new WaitForSeconds(0.2f);
        tampacorte.color = new Color(0.5754717f, 0.4726515f, 0.3604842f, 0);
        yield return new WaitForSeconds(0.5f);
        if(!Data_Controler.esterelizaOk)
        {
            Data_Controler.esterelizaOk = false;
            Falas.indexFala = 1;

        }
       

        zuum.SetActive(false);
        enfermagem.SetActive(true);
        this.gameObject.SetActive(false);
        barra2.fillAmount = 0;
        i = 0;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == braco)
        {
            onbraco = false;
            trail.enabled = false;
        }
        if (collision == colisorCima)
        {
            flag1 = false;



        }
        else if (collision == colisorBaixo)
        {
            flag2 = false;
        }
        if (!flag1 && flag2 && onbraco && i<nmax)
        {
            i++;
            Debug.Log(i);
            flag1 = false;
            flag2 = false;
            tampacorte.color -= new Color(0, 0, 0, 0.05f);
            limpa.Play();
        }
        if (i >= nmax && i<100)
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            ganhou.Play();
            StartCoroutine(Ganhou());
            i = 200;
        }

    }





}
