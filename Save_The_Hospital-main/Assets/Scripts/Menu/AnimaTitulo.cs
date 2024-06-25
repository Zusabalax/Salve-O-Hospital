using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaTitulo : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = 0;

        StartCoroutine(Espera());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Espera()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            image.fillAmount +=0.1f;



        }

    

       

    }
}
