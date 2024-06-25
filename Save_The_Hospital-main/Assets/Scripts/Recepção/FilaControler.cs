
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class FilaControler : MonoBehaviour
{
    public List<string> pacinetJason;
    
    public GameObject[] pacinetWait, pacientList;
 
 
  

    public SpriteRenderer enfermeira;
    public int[] emptyChair;
    public string  empty, idstring2;
    public char[] idChar2;
    

    int firstPositionVoid, counter, positionLoc;
    public int[] randonVector, randonVector2, randonVector3, randonVector4;
    public int randomNUmber;
    public int teste;
    public static string  SavePath => Path.Combine(Application.persistentDataPath, "SalveJason.json");
    public  float timeSpam;
   

    [System.Serializable]
    public class FilaValores 
    {
        public List<string> Pacientes;
        public int[] LocaisVazios;
        public GameObject lalala;
        public FilaValores(FilaControler filaController)
        {
            LocaisVazios = filaController.emptyChair;
            Pacientes = filaController.pacinetJason;
           
         
        }
    }
    void Awake()
    {


        Debug.Log("aaaaa");
        Debug.Log(Falas.noCont);

        Falas.noCont = false;
        Data_Controler.falasEnfermeira = 0;
        Data_Controler.gessoOk=false;
        Data_Controler.suturaOK=false;
        Data_Controler.vacinaOk=false;
        Data_Controler.raioxOk=false;
   
        Data_Controler.tempOk = false;
        Data_Controler.pressOk = false;
       
        Data_Controler.movepacient=false;
        Data_Controler.camChange = false;
        Data_Controler.Atendimentook = false;    
        ImagemRaiox.index = 0;
        ImagemRaiox.gesso = false;
        ImagemRaiox.sutura = false;
        ImagemRaiox.peconha = false;

        Data_Controler.ttTriagem = true;


        Data_Controler.ttDna = true;
        RandonPositions.startGame = true;




        Data_Controler.ttRaiox = true;

        Data_Controler.ttEnfermagem = true;


        Data_Controler.ttVacina = true;

        Data_Controler.ttRespirador = true;




        Data_Controler.pacientSelect = -1;
        Data_Controler.triagemok = false;
        Data_Controler.tempOk = false;
        Data_Controler.batimentosOk = false;
        Data_Controler.respOK = false;
        Data_Controler.historicoOk = false;
        Falas.indexFala = 4;
        Data_Controler.contaErro = 0;

        Data_Controler.pressOk = false;
        Data_Controler.esterelizaOk = false;
        Data_Controler.recepOK = false;
        Data_Controler.pacientNumeber = PlayerPrefs.GetInt("NP");
        Data_Controler.pacientsLost = PlayerPrefs.GetInt("LOST");
        
       
        firstPositionVoid = 0;
        emptyChair= new int[pacinetWait.Length];

       
        for (int i = 0; i < emptyChair.Length; i++)
        {
            emptyChair[i] = 0;
           
            pacinetWait[i].SetActive(false);
        }
        if(Data_Controler.pacientsLost>=5)
        {
            SceneManager.LoadScene("GameOver");

        }
    }
    void Start()
    {

        LoadData();
        if (pacinetJason==null) 
        {
            Debug.Log("entrou ijuhgsdkjgs");
            StartCoroutine(LocPacinetsSpam(timeSpam));
        }
        else
        {
           
            PuxaSalve();

        }
        StartCoroutine(EnfermeiraFlip());

    }
    public void SaveData()
    {
        FilaValores filaValores = new FilaValores(this);
        string json = JsonUtility.ToJson(filaValores);
        File.WriteAllText(SavePath, json);
        Debug.Log(json);
        Debug.Log("Savo");
        
    }
    public void DeleteData()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
        }
    }
    public void LoadData()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Debug.Log(json);
            FilaValores filaValores = JsonUtility.FromJson<FilaValores>(json);
            emptyChair = filaValores.LocaisVazios;
            pacinetJason = filaValores.Pacientes;
           
        }
        else
        {
            Debug.Log("file SalvePath naop existe");
        }
    }
    public void PuxaSalve()
    {

        
        int index = 0;
        int posicao = 0;
        foreach (int item in emptyChair)
        {
          
            if (item == 0)
            {
                pacinetWait[index].SetActive(false);

            }
            else if (item == 1)
            {
                pacinetWait[index].SetActive(true);
                Debug.Log(pacinetJason);
                Debug.Log(int.Parse(pacinetJason[posicao]));

                Instantiate(pacientList[int.Parse(pacinetJason[posicao])], pacinetWait[index].transform);
                if (index > 5)
                {

                    pacinetWait[index].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
                }


                posicao++;
            }
            index++;
          

        }
       
   
  
        StartCoroutine(LocPacinetsSpam(timeSpam));

    }

    // Update is called once per frame
    void Update()
    {
        teste = Data_Controler.pacientNumeber;

      


    }
    public void RandonIllnes()
    {
        if (Data_Controler.currentSeason == 0)
        {
            randomNUmber = Random.Range(0, pacientList.Length);
            Data_Controler.pacientRandon = randonVector[randomNUmber];
        }
        else if (Data_Controler.currentSeason == 1)
        {
            randomNUmber = Random.Range(0, pacientList.Length);
            Data_Controler.pacientRandon = randonVector2[randomNUmber];
        }
        else if (Data_Controler.currentSeason == 2)
        {
            randomNUmber = Random.Range(0, pacientList.Length);
            Data_Controler.pacientRandon = randonVector3[randomNUmber];
        }
        else if (Data_Controler.currentSeason == 3)
        {
            randomNUmber = Random.Range(0, pacientList.Length);
            Data_Controler.pacientRandon = randonVector4[randomNUmber];
        }
    }
    public void LocPacients()
    {
       
        if ( Data_Controler.pacientNumeber>=0 && Data_Controler.pacientNumeber <pacinetWait.Length)
        {
           
            positionLoc = FindVoidPosition();
            
            emptyChair[positionLoc] = 1;
           
           
           
            RandonIllnes();
            PacienNumber();

          
     
            pacinetWait[positionLoc].SetActive(true);

            Instantiate(pacientList[Data_Controler.pacientRandon], pacinetWait[positionLoc].transform);

            idChar2 = pacinetWait[positionLoc].transform.GetChild(0).name.ToCharArray();
            idstring2 = idChar2[3].ToString() + idChar2[4].ToString();
            pacinetJason.Add(idstring2);

            SaveData();

            if (positionLoc>5)
            {
                pacinetWait[positionLoc].transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder=15;
            }
        }
        

    }

   
    public int FindVoidPosition()
    {
        counter = 0;
      
        while(counter<emptyChair.Length)
        {
            if (emptyChair[counter] == 0)
            {
               
                    firstPositionVoid = counter;
                
                        counter = 1000;
  
            }

            counter++;
        }
        return firstPositionVoid;
    }

  
    public void PacienNumber()
    {
        if (Data_Controler.pacientNumeber < pacinetWait.Length)
        {
            Data_Controler.pacientNumeber++;
            PlayerPrefs.SetInt("NP", Data_Controler.pacientNumeber);

        }
        else
        {
            Data_Controler.pacientsLost++;
          
            PlayerPrefs.SetInt("LOST", Data_Controler.pacientsLost);
          
        }
    }
    public void MovePacient(string cena)
    {
        if(Data_Controler.movepacient)
        {
            Destroy(pacinetWait[Data_Controler.pacientSelect].transform.GetChild(0).gameObject);
            emptyChair[Data_Controler.pacientSelect] = 0;
            pacinetJason.RemoveAt(Data_Controler.pacientSelect);
            SaveData();
            Data_Controler.recepOK = true;
           
            SceneManager.LoadScene(cena);

        }


    }


    public IEnumerator LocPacinetsSpam(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            LocPacients();



        }

    }
    public IEnumerator EnfermeiraFlip()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,6));


            enfermeira.flipX = (enfermeira.flipX == true) ? false : true;

        }

    }
    private void OnApplicationQuit()
    {
          SaveData();
       // PlayerPrefs.DeleteAll();

       // DeleteData();



    }

}
