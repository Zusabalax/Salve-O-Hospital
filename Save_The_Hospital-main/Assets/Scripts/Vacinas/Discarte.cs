using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discarte : MonoBehaviour
{
    public GameObject vacinaUsada;
  
    // Start is called before the first frame update
    void Start()
    {

        if (TimerVacina.aplicou)
        {
            vacinaUsada.SetActive(true);
        }
        else
        {
            vacinaUsada.SetActive(false);

        }

    }
    private void OnEnable()
    {
        if(TimerVacina.aplicou)
        {
            vacinaUsada.SetActive(true);
        }
        else
        {
            vacinaUsada.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
