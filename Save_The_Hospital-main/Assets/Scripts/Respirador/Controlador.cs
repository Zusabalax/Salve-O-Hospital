using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public Image[] alvelos;
    public AudioSource fogos,erro;
    public ParticleSystem[] particles;
    public Image pulmaoPlacar;
    public bool[] notas;
    public SpriteRenderer pulmaoGrande;
    float time;
    int index;
    bool win;
    public static bool gameOn;
    // Start is called before the first frame update
    void Start()
    {
      
        pulmaoPlacar.fillAmount = 0;
        StartCoroutine(GeradorMusica());
       
       

    }
    public IEnumerator GeradorMusica()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 40; i++)
        {
            index = Random.Range(0, 6);
            time = Random.Range(0.8f, 1.1f) ;
            alvelos[index].color = Color.green;
            notas[index] = true;
            yield return new WaitForSeconds(time);
            alvelos[index].color = Color.white;
            notas[index] = false;
            if(win)
            {
                i = 40;
            }

        }
        if(!win) 
        {
            StartCoroutine(Looser());
        }

      
        
    }
    public IEnumerator Winer()
    {
        Falas.indexFala = 1;
        if ((Data_Controler.pacinetGotratament == 0 || Data_Controler.pacinetGotratament == 2) && Data_Controler.raioxOk)
        {
            Data_Controler.respOK = true;
            Falas.indexFala = 0;
        }
        
            yield return new WaitForSeconds(1);
     

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
            fogos.Play();
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Respirador");

    }
    public IEnumerator Looser()
    {
        pulmaoGrande.color = Color.black;
        erro.Play();
      
        Falas.indexFala = 2;


        yield return new WaitForSeconds(0.5f);
        pulmaoGrande.color=Color.white;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Respirador");




    }

    public void TimeNote(int index)
    {
        if (notas[index]) 
        {
            pulmaoPlacar.fillAmount += 0.05f;
            notas[index]= false;
            alvelos[index].color = Color.white;
            if (pulmaoPlacar.fillAmount>=1)
            {
                win = true;
                StartCoroutine(Winer());
            }

        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }

}
