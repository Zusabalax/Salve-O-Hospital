using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalaSaida : MonoBehaviour
{
    [SerializeField] private AudioSource parabens, triste;
    // Start is called before the first frame update
    void Start()
    {
        if (Falas.indexFala == 0) 
        { 
                parabens.Play();
        }
        else
        {
            triste.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
