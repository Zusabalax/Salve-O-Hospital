using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeCam : MonoBehaviour
{
    public GameObject[] cam;
  

    // Start is called before the first frame update
  
    public void ChangeSene(string sene)
    {
        SceneManager.LoadScene(sene);
    }
    public void Changecam(int k)
    {

        if(Data_Controler.camChange)
        {
            for (int j = 0; j < cam.Length; j++)
            {
                if (k == j)
                {

                    cam[k].SetActive(true);
                }
                else
                {

                    cam[j].SetActive(false);

                }
            }
        }

       
       
        
        
    }
    public void MarkBox(Toggle box)
    {
        box.interactable = false;
        Data_Controler.camChange = true;
    }
    public void Sair()
    {
        Application.Quit();

    }
}

