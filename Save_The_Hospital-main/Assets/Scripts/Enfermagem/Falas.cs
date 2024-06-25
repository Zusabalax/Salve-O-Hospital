using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falas : MonoBehaviour
{
    public  List<string> talkEnfermeira = new List<string>();
    public TextMeshProUGUI talkBox;
    public float textSpeed;
    public static int indexFala;
    public static bool noCont;
    public Sprite rosto;
    public SpriteRenderer rostoRenderer;
    public Transform pacientePosition;
    string falaAdicional;

    public bool teste;
    // Start is called before the first frame update
    void Start()
    {
        //if(teste)
        //{
        //    Falas.indexFala = 4;
        //}
        
    }

    // Update is called once per frame
   
    private void OnEnable()
    {
        if(!Data_Controler.recepOK)
        {
          
           StartCoroutine(FalaFinal(indexFala));


                  
           

        }
       
        Data_Controler.recepOK = false;   
        
    }
    public IEnumerator FalaFinal(int nFala)
    {
        talkBox.text = "";
        rostoRenderer.sprite = rosto;

        yield return new WaitForSeconds(1); 
       
        foreach (char d in talkEnfermeira[nFala].ToCharArray())
        {
            talkBox.text += d;

            yield return new WaitForSeconds(1 / textSpeed);
        }
        if (nFala >0 && nFala<3)
        {
            falaAdicional = "";
            falaAdicional = " restam " + (2 - Data_Controler.contaErro) + " tentativas.";
            foreach (char w in falaAdicional.ToCharArray())
            {
                talkBox.text += w;

                yield return new WaitForSeconds(1 / textSpeed);
            }
           
           
        }
        yield return new WaitForSeconds(1);
         

        if(indexFala==0)
        {
            noCont = true;
            
            pacientePosition.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<ChangeSprite>().TrocaSprite();
           
          
            Data_Controler.pacientNumeber--;
            Data_Controler.contaErro = 0;
            PlayerPrefs.SetInt("NP", Data_Controler.pacientNumeber);
            PlayerPrefs.Save();
            Data_Controler.Atendimentook = true;
            Debug.Log("porqueee");
            Debug.Log(indexFala);
            SceneManager.LoadScene("Saida");
          

        }

        else if(indexFala >= 4)
        {

        }
       
        else
        {
            if(indexFala>0 && indexFala <3)
            {
                Data_Controler.contaErro++;
            }
           
            if(Data_Controler.contaErro>=3)
            {
              
                Data_Controler.pacientNumeber--;
                Data_Controler.pacientsLost++;
                Data_Controler.Atendimentook = false;

                PlayerPrefs.SetInt("NP", Data_Controler.pacientNumeber);
                PlayerPrefs.SetInt("LOST", Data_Controler.pacientsLost);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Saida");

            }

        }
        this.transform.gameObject.SetActive(false);
    }
}
