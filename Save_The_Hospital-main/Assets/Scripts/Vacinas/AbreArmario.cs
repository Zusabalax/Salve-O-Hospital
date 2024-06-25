using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbreArmario : MonoBehaviour
{
    public GameObject portaAberta, portaFechada;
    // Start is called before the first frame update
    void Start()
    {

        
    }
    public void Porta()
    {
        if(!TimerVacina.aplicou)
        {
            portaAberta.SetActive(true);
          //  portaFechada.SetActive(false);

        }
            

    
        
    }
    public void VoltaEnfermagem()
    {
        if (!TimerVacina.aplicou)
        {
            SceneManager.LoadScene("Enfermagem");

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
