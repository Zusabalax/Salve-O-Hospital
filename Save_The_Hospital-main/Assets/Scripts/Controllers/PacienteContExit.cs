using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacienteContExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnApplicationQuit()
    {
       if(!Falas.noCont)
        {
            Data_Controler.pacientNumeber--;
            PlayerPrefs.SetInt("NP", Data_Controler.pacientNumeber);

        }
            

       
      


    }
}
