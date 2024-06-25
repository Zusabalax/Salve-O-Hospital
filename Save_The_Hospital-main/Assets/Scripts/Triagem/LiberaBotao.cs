using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiberaBotao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoDNA(string cena)
    {
        if(Data_Controler.triagemok)
        {
            Data_Controler.falasEnfermeira = 9;
            SceneManager.LoadScene(cena);
        }
    }
    public void GoSalas(string cena)
    {
        if(Data_Controler.triagemok && Data_Controler.historicoOk)
        {
            SceneManager.LoadScene(cena);
        }

    }

}
