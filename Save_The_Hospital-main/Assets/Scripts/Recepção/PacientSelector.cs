using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PacientSelector : MonoBehaviour
{
    public int pacinetSelected,pacientIllnes;
    public GameObject arrowSelect;
    Transform paciente;
    public AudioSource somSelecionaPaciente, somMouseNoPacienete;
    bool somOk;
    char [] idChar;
    string idstring;
    public float arrowDistance;

 
    void Start()
    {
        idChar = new char[10];
      //  arrowSelect.SetActive(false);
      //  Data_Controler.pacientSelect = -1;
        Data_Controler.movepacient = false;

        //  pacientIllnes = -1;
        somOk = true;
       
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Data_Controler.pacientNumeber>0)
        {
            arrowSelect.gameObject.SetActive(true);
        }
    }
    void OnMouseOver()
    {
        this.transform.localScale = new Vector2(1.09f, 1.09f);
        if(somOk)
        {
            somMouseNoPacienete.Play(0);
            somOk=false;

        }
       


        if (Input.GetMouseButtonUp(0))
        {
            idstring = "";
            
            somSelecionaPaciente.Play(0);   
            arrowSelect.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
          
            Data_Controler.movepacient = true;
            paciente = transform.GetChild(0);
      
            idChar = paciente.name.ToCharArray();
            idstring = idChar[3].ToString() + idChar[4].ToString();
            PlayerPrefs.SetInt("PacienteIndex", pacinetSelected);
            Data_Controler.pacientID = int.Parse(idstring);
            Debug.Log(Data_Controler.pacientID);

          
            if (paciente.tag== "pneumonia")
            {
                Debug.Log("penelmonia");

                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "90 BPM";
                Data_Controler.temperatura = 40;
                Data_Controler.pacinetGotratament = 0;
                pacientIllnes=Data_Controler.pacinetGotratament;
            }
            if (paciente.tag == "peçonha")
            {
                Debug.Log("peçonha");
                Data_Controler.pacinetGotratament = 1;
                pacientIllnes = Data_Controler.pacinetGotratament;
                Data_Controler.pressao = "87/59 mm/Hg";
                Data_Controler.batimentos = "60 BPM";
                Data_Controler.temperatura = 36;
            }
            if (paciente.tag == "gripe")
            {
                Debug.Log("gripe");
                Data_Controler.pacinetGotratament = 2;
                pacientIllnes = Data_Controler.pacinetGotratament;
                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "90 BPM";
                Data_Controler.temperatura = 38;
            }
            if (paciente.tag == "acidente")
            {
                Debug.Log("acidente");
                Data_Controler.pacinetGotratament = 3;
                pacientIllnes = Data_Controler.pacinetGotratament;
                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "110 BPM";
                Data_Controler.temperatura = 37;

            }
            if (paciente.tag == "corte")
            {
                Debug.Log("corte");
                Data_Controler.pacinetGotratament = 4;
                pacientIllnes = Data_Controler.pacinetGotratament;
                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "120 BPM";
                Data_Controler.temperatura = 37;

            }
            if (paciente.tag == "Covid")
            {
                Debug.Log("covid");

                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "112 BPM";
                Data_Controler.temperatura = 39;
                Data_Controler.pacinetGotratament = 5;
                pacientIllnes = Data_Controler.pacinetGotratament;
            }
            if (paciente.tag == "Sarampo")
            {
                Debug.Log("sarampo");

                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "112 BPM";
                Data_Controler.temperatura = 39;
                Data_Controler.pacinetGotratament = 6;
                pacientIllnes = Data_Controler.pacinetGotratament;
            }
            if (paciente.tag == "Tetano")
            {
                Debug.Log("tetano");

                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "112 BPM";
                Data_Controler.temperatura = 39;
                Data_Controler.pacinetGotratament = 7;
                pacientIllnes = Data_Controler.pacinetGotratament;
            }

            if (paciente.tag == "Antrabica")
            {
                Debug.Log("Antrabica");

                Data_Controler.pressao = "90/60 mm/Hg";
                Data_Controler.batimentos = "112 BPM";
                Data_Controler.temperatura = 39;
                Data_Controler.pacinetGotratament = 8;
                pacientIllnes = Data_Controler.pacinetGotratament;
            }
          

            arrowSelect.transform.position = new Vector3(0, arrowDistance,0) + this.transform.position;
            Data_Controler.pacientSelect = pacinetSelected;
            Debug.Log(Data_Controler.pressao + "----" + Data_Controler.temperatura);
            PlayerPrefs.SetInt("PacientID", Data_Controler.pacientID);
            PlayerPrefs.SetString("Pressao", Data_Controler.pressao);
            PlayerPrefs.SetInt("Temperatura", Data_Controler.temperatura);
            PlayerPrefs.SetString("Batimentos", Data_Controler.batimentos);


            PlayerPrefs.Save();

        }
    }

    void OnMouseExit()
    {
        this.transform.localScale = new Vector2(1, 1);
       // arrowSelect.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        somOk = true;

    }
  
}
