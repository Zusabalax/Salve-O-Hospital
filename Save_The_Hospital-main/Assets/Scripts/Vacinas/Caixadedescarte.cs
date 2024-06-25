using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caixadedescarte : MonoBehaviour
{
    public GameObject vacina;
    public Transform vacinaP;
    public Collider2D vacinaCollider;
    // Start is called before the first frame update
   
    
    private void OnTriggerEnter2D(Collider2D other)
    {

       if (other==vacinaCollider)
        {
            vacina.transform.position=vacinaP.position; 
            vacina.SetActive(false);
            TimerVacina.aplicou = false;
            
            SceneManager.LoadScene("Enfermagem");

        }
    }
}
