using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialVdeo : MonoBehaviour
{
    [SerializeField] private int cena;
    [SerializeField] private VideoPlayer player;
    [SerializeField] private GameObject tutorial;
   
    
    // Start is called before the first frame update
    void Start()
    {
        StartTutorial();

    }

    // Update is called once per frame
    private void OnEnable()
    {
        StartCoroutine(FechaVideo());
        TriagemSistem.block = false;

    }

    public void StartTutorial()
    {
        switch (cena)
        {
            case 1:
                if (!Data_Controler.ttTriagem)
                {
                    tutorial.SetActive(false);

                }
                else
                {
                    StartCoroutine(FechaVideo());
                    Data_Controler.ttTriagem = false;
                }
                break;

            case 2:
                if (!Data_Controler.ttDna)
                {
                    tutorial.SetActive(false);
                }
                else
                {
                    StartCoroutine(FechaVideo());
                    RandonPositions.startGame = true;
                    Time.timeScale = 1;

                    Data_Controler.ttDna = false;
                }

                break;

            case 3:
                if (!Data_Controler.ttRaiox)
                {
                    tutorial.SetActive(false);

                }
                else
                {
                    StartCoroutine(FechaVideo());
                    Data_Controler.ttRaiox = false;
                }
                break;
            case 4:
                if (!Data_Controler.ttEnfermagem)
                {
                    tutorial.SetActive(false);
                }
                else
                {
                    StartCoroutine(FechaVideo());
                    Data_Controler.ttEnfermagem = false;
                }
                break;
            case 5:
                if (!Data_Controler.ttVacina)
                {
                    tutorial.SetActive(false);
                }
                else
                {
                    StartCoroutine(FechaVideo());
                    Data_Controler.ttVacina = false;
                }

                break;
            case 6:

                if (!Data_Controler.ttRespirador)
                {
                    tutorial.SetActive(false);
                }
                else
                {
                    StartCoroutine(FechaVideo());
                    Data_Controler.ttRespirador = false;
                }

                break;

        }
    }
    public IEnumerator FechaVideo()
    {
        yield return new WaitForSeconds((float)player.length);
        TriagemSistem.block = true;
        Time.timeScale = 1.0f;
        tutorial.SetActive(false);
       
    }
    public void FechaTT()
    {
        TriagemSistem.block = true;
        Time.timeScale = 1.0f;
        tutorial.SetActive(false);
    }
}
